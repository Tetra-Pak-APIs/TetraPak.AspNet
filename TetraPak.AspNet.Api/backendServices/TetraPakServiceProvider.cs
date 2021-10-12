using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TetraPak.AspNet.Auth;

#nullable enable

namespace TetraPak.AspNet.Api
{
    // todo consider merging the code in ServiceInfo into TetraPakServiceFactory
    class TetraPakServiceProvider : ITetraPackServiceProvider
    {
        static IDictionary<string, BackendService<ServiceEndpoints>>? s_genericServicesIndex;
        static IDictionary<Type, IBackendService>? s_typedServicesIndex;
        static IDictionary<Type, ServiceEndpoints>? s_typedEndpointsIndex;

        public Outcome<IBackendService> ResolveService(Type serviceType, string? serviceName = null)
        {
            if (serviceType == typeof(BackendService<ServiceEndpoints>))
            {
                // requesting arbitrary service AND endpoints; a service name is required ...
                if (string.IsNullOrWhiteSpace(serviceName))
                    return Outcome<IBackendService>.Fail(
                        new InvalidOperationException("Cannot resolve arbitrary backend service when service name is omitted"));
                
                if (!s_genericServicesIndex!.TryGetValue(serviceName, out var arbitraryService))
                    return Outcome<IBackendService>.Fail(
                        new ArgumentOutOfRangeException(nameof(serviceName), $"Service is not configured: '{serviceName}'"));
                    
                return Outcome<IBackendService>.Success(arbitraryService);
            }
            
            // requesting a typed backend service ...
            IBackendService? typedService;
            if (serviceType.TryGetGenericBase(typeof(BackendService<>), out var genericBase, false))
            {
                // only the endpoints is typed ...
                var endpointsType = genericBase.GetGenericArguments()[0];
                if (!s_typedEndpointsIndex!.TryGetValue(endpointsType, out var endpoints))
                    return Outcome<IBackendService>.Fail(
                        new InvalidOperationException($"Cannot resolve typed backend service endpoints: {endpointsType}"));

                typedService = (IBackendService)Activator.CreateInstance(typeof(BackendService<>), endpoints)!;
                // todo consider caching generic service with typed endpoints for better performance 
                return Outcome<IBackendService>.Success(typedService);
            }
            
            if (!s_typedServicesIndex!.TryGetValue(serviceType, out typedService))
                return Outcome<IBackendService>.Fail(
                    new InvalidOperationException($"Cannot resolve typed backend service: {serviceType}"));
            
            return Outcome<IBackendService>.Success(typedService);
        }

        internal static void InitializeServices(IServiceCollection serviceCollection, params Assembly[]? assemblies)
        {
            var p = serviceCollection.BuildServiceProvider();
            var tetraPakConfig = p.GetRequiredService<TetraPakConfig>();
            var serviceAuthConfig = p.GetRequiredService<IServiceAuthConfig>();
            var httpServiceProvider = p.GetRequiredService<IHttpServiceProvider>();
            
            var servicesIndex = indexGenericServicesFromConfiguration(
                tetraPakConfig,
                serviceAuthConfig, 
                httpServiceProvider);
            if (servicesIndex is null)
                throw new ConfigurationException("Backend services was not configured");

            Assembly[] asm = assemblies is null || !assemblies.Any()
                ? new[] { Assembly.GetEntryAssembly()! }
                : assemblies;

            var indexResult = indexTypedServices(asm, servicesIndex);
            indexResult.GenericServicesIndex = servicesIndex;
            configureTypedServices(serviceCollection, indexResult);
            s_genericServicesIndex = indexResult.GenericServicesIndex;
            s_typedEndpointsIndex = indexResult.TypedEndpointsIndex;
            s_typedServicesIndex = indexResult.TypedServicesIndex;
        }

        static ServicesIndexResult indexTypedServices(
            IEnumerable<Assembly> assemblies, 
            IDictionary<string,BackendService<ServiceEndpoints>> servicesIndex)
        {
            var endpointsIndex = new Dictionary<Type, ServiceEndpoints>();
            var serviceTypes = new List<Type>();
            foreach (var assembly in assemblies) 
            {
                var allTypes = assembly.GetTypes().ToArray();
                for (var i = 0; i < allTypes.Length; i++)
                {
                    var type = allTypes[i];
                    if (type == typeof(BackendService<ServiceEndpoints>) || type == typeof(ServiceEndpoints))
                        continue;

                    if (type.IsGenericBase(typeof(BackendService<>)))
                    {
                        // we'll initialize typed services after we're done with typed endpoints ...
                        serviceTypes.Add(type);
                        continue;
                    }
                    
                    if (!typeof(ServiceEndpoints).IsAssignableFrom(type))
                        continue;

                    if (type.IsAbstract)
                        throw new InvalidOperationException(
                            $"Invalid backend service type: {type}. Backend collection type cannot be abstract");
                    
                    var serviceName = getAttributedServiceName(type)  
                                      ?? resolveFromTypeName(type, "Endpoints");
                    
                    if (!servicesIndex.TryGetValue(serviceName, out var service))
                        throw new ConfigurationException($"Cannot configure service endpoints {type}. Service '{serviceName}' was not configured");

                    endpointsIndex[type] = ServiceEndpoints.MakeTypedEndpoints(type, service.Endpoints);
                }                
                
                static string? getAttributedServiceName(Type type)
                {
                    while (true)
                    {
                        var attribute = type.GetCustomAttribute<BackendServiceAttribute>(true);
                        if (attribute is { }) 
                            return attribute.ServiceName;

                        if (type.DeclaringType is null) 
                            return null;
                
                        type = type.DeclaringType;
                    }
                }
            }

            var serviceIndex = indexServices();
            
            return new ServicesIndexResult
            {
                TypedEndpointsIndex = endpointsIndex,
                TypedServicesIndex = serviceIndex
            };

            IDictionary<Type, IBackendService> indexServices()
            {
                var index = new Dictionary<Type, IBackendService>();
                for (var i = 0; i < serviceTypes.Count; i++)
                {
                    var type = serviceTypes[i];
                    if (!type.TryGetGenericBase(typeof(BackendService<>), out var baseServiceType))
                        continue; // note this should never happen!

                    if (type.IsAbstract)
                        throw new InvalidOperationException(
                            $"Invalid backend service type: {baseServiceType}. Service Type cannot be abstract");
                    
                    var endpointsType = baseServiceType.GetGenericArguments()[0];
                    var serviceName = type.GetCustomAttribute<BackendServiceAttribute>()?.ServiceName 
                                      ?? resolveFromTypeName(type, "Service");

                    if (!endpointsIndex.TryGetValue(endpointsType, out var configuredEndpoints))
                    {
                        if (!servicesIndex.TryGetValue(serviceName, out var configuredService))
                            throw new ConfigurationException($"Cannot configure service {type}. Service '{serviceName}' was not configured");

                        configuredEndpoints = ServiceEndpoints.MakeTypedEndpoints(endpointsType, configuredService.Endpoints);
                    }

                    index[type] = (IBackendService)Activator.CreateInstance(type, configuredEndpoints)!;
                }

                return index;
            }
        }

        

        class ServicesIndexResult
        {
            public IDictionary<string,BackendService<ServiceEndpoints>>? GenericServicesIndex { get; set; }
            public IDictionary<Type, ServiceEndpoints>? TypedEndpointsIndex { get; set; }
            public IDictionary<Type, IBackendService>? TypedServicesIndex { get; set; }
        }

        static IDictionary<string, BackendService<ServiceEndpoints>> indexGenericServicesFromConfiguration(
            TetraPakConfig tetraPakConfig,
            IServiceAuthConfig config, 
            IHttpServiceProvider httpServiceProvider)
        {
            var children = config.Configuration.GetChildren();
            var serviceConfigs = children.Where(s => !config.IsAuthIdentifier(s.Key));
            var index = new Dictionary<string, BackendService<ServiceEndpoints>>();
            foreach (var section in serviceConfigs)
            {
                var endpoints = new ServiceEndpoints(tetraPakConfig, config, httpServiceProvider, section.Key);
                var service = new BackendService<ServiceEndpoints>(endpoints);
                index.Add(service.ServiceName, service);
            }

            return index;
        }

        static void configureTypedServices(IServiceCollection c, ServicesIndexResult indexResult)
        {
            foreach (var typedEndpoints in indexResult.TypedEndpointsIndex!.Values)
            {
                c.TryAddSingleton(typedEndpoints.GetType(), _ => typedEndpoints);
            }

            foreach (var typedService in indexResult.TypedServicesIndex!.Values)
            {
                c.TryAddSingleton(typedService.GetType(), _ => typedService);
            }
        }

        static string resolveFromTypeName(Type controllerType, string suffix)
        {
            // const string ControllerQualifier = "Controller";

            return controllerType.Name.EndsWith(suffix) 
                ? controllerType.Name[..^suffix.Length] 
                : controllerType.Name;
        }
    }

    /// <summary>
    ///   Classes implementing this contract are able to resolve backend services.
    /// </summary>
    public interface ITetraPackServiceProvider
    {
        /// <summary>
        ///   Resolves a service, based on its type and (optionally) service name
        /// </summary>
        /// <param name="serviceType">
        /// </param>
        /// <param name="serviceName">
        ///   Specifies a configured service. This is required if <paramref name="serviceType"/>
        ///   if just a generic backend service. 
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="IBackendService"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        Outcome<IBackendService> ResolveService(Type serviceType, string? serviceName = null);
    }
}