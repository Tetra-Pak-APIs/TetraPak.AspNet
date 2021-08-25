using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    // todo consider merging the code in ServiceInfo into TetraPakServiceFactory
    static class ServiceResolver
    {
        static readonly IDictionary<string, IServiceAuthConfig> s_serviceAuthConfigs 
            = new Dictionary<string, IServiceAuthConfig>();

        static readonly IDictionary<ServiceKey, IBackendService> s_services =
            new Dictionary<ServiceKey, IBackendService>();
        
        static readonly MultiStringValue s_baseServiceAuthConfigPath = ServiceAuthConfig.GetServiceConfigPath();

        internal static Outcome<IBackendService> ResolveService(Type controllerType, ControllerContext context, string serviceName = null)
        {
            serviceName ??= controllerType.GetCustomAttribute<BackendServiceAttribute>()?.ServiceName 
                            ?? assumeSameAsControllerName(controllerType);

            var key = new ServiceKey(controllerType, serviceName);
            lock (s_services)
            {
                if (s_services.TryGetValue(key, out var service))
                    return Outcome<IBackendService>.Success(service);
            }
            
            // note: We're resolving the service non-blocking, risking doing it twice in parallel threads but the performance makes it worth it
            var outcome = controllerType.TryGetGenericBase(typeof(ApiGatewayController<>), out var apiGatewayControllerType) 
                ? resolveFromTypedController(apiGatewayControllerType, context, serviceName) 
                : resolveFromArbitraryController<ServiceEndpoints.UntypedServiceEndpoints>(context, serviceName);

            if (!outcome)
                return outcome;

            lock (s_services)
            {
                // yes, we might have resolved the service in vain, ending up using a service resolved in a different thread
                if (s_services.TryGetValue(key, out var service))  
                    return Outcome<IBackendService>.Success(service);
                
                s_services.Add(key, outcome.Value);
                return outcome;
            }
        }

        static Outcome<IBackendService> resolveFromTypedController(
            Type apiGatewayControllerType, 
            ActionContext context,
            string serviceName)
        {
            var provider = context.HttpContext.RequestServices;
            var serviceType = apiGatewayControllerType.GetGenericArguments().First();
            var service = (IBackendService) provider.GetService(serviceType);
            if (service is { } && isInitialized(service, out var endpoints))
                return Outcome<IBackendService>.Success(service);

            if (!serviceType.TryGetGenericBase(typeof(BackendService<>), out var baseServiceType))
            {
                service = (IBackendService) provider.GetService(serviceType);
                if (isInitialized(service, out endpoints))
                    return Outcome<IBackendService>.Success(service);
            }

            try
            {
                var endpointsType = baseServiceType.GetGenericArguments().First();
                var httpServiceProvider = provider.GetRequiredService<IHttpServiceProvider>();
                endpoints = createEndpoints(endpointsType, provider, serviceName);
                if (service is { })
                    return initialize(service, endpoints, httpServiceProvider);
                
                var ctors = serviceType.GetConstructors();
                object[] parameters = null;
                var ctor = ctors.FirstOrDefault(ci =>
                {
                    // prefer the empty ctor; otherwise go for one that supports TEndpoints and IHttpServiceProvider params...
                    var parameterInfos = ci.GetParameters();
                    if (parameterInfos.Length == 0)
                    {
                        parameters = Array.Empty<object>();
                        return true;
                    }
                    
                    var paramList = new List<object>();
                    foreach (var info in parameterInfos)
                    {
                        if (typeof(ServiceEndpoints).IsAssignableFrom(info.ParameterType))
                        {
                            paramList.Add(endpoints);
                            continue;
                        }
                        if (typeof(IHttpServiceProvider).IsAssignableFrom(info.ParameterType))
                        {
                            paramList.Add(httpServiceProvider);
                            continue;
                        }
                        if (info.IsOptional)
                            break;
                        
                        paramList.Add(provider.GetService(info.ParameterType));
                    }

                    if (paramList.Count < 2)
                        return false;
                    
                    parameters = paramList.ToArray();
                    return true;
                });
                
                if (ctor is null)
                    throw new TypeLoadException("Unsupported ctor signature");

                service = (IBackendService) ctor.Invoke(parameters);
                return parameters.Length != 0 // check whether we used parameters for creating service (if so, it is already initialized)
                    ? Outcome<IBackendService>.Success(service) // : new ServiceInfo(service, endpoints)  obsolete
                    : initialize(service, endpoints, httpServiceProvider);
            }
            catch (Exception ex)
            {
                // todo log error
                Console.WriteLine(ex);
                throw;
            }
        }
        
        static Outcome<IBackendService> resolveFromArbitraryController<TEndpoints>(
            ControllerContext context,
            string serviceName)
        where TEndpoints : ServiceEndpoints
        {
            var provider = context.HttpContext.RequestServices;
            // todo consider supporting declaration of service and endpoints type in attribute

            var endpoints = (TEndpoints) createEndpoints(typeof(TEndpoints), provider, serviceName);
            var httpServiceProvider = provider.GetRequiredService<IHttpServiceProvider>();
            var service = new BackendService<TEndpoints>(endpoints, httpServiceProvider);
            return Outcome<IBackendService>.Success(service); 
        }

        static bool isInitialized(IBackendService service, out ServiceEndpoints endpoints)
        {
            var serviceType = service.GetType();
            var isInitializeMethod = serviceType.GetMethod("IsInitialized", BindingFlags.Instance | BindingFlags.NonPublic);
            if (isInitializeMethod is null)
                throw new TypeLoadException("No (internal) 'IsInitialized' method found");
                
            var obj = isInitializeMethod.Invoke(service, Array.Empty<object>());
            if (obj is not Outcome<ServiceEndpoints> outcome) 
                throw new TypeLoadException($"Unexpected result from (internal) 'IsInitialized' method: {obj}. Expected boolean");

            if (outcome)
            {
                endpoints = outcome.Value;
                return true;
            }

            endpoints = null;
            return false;
        }

        static Outcome<IBackendService> initialize(IBackendService service, ServiceEndpoints endpoints, IHttpServiceProvider httpServiceProvider)
        {
            var initializeMethod = service.GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic);
            if (initializeMethod is null)
                throw new TypeLoadException("No (internal) 'Initialize' method found");
                
            initializeMethod.Invoke(service, new object[] {endpoints, httpServiceProvider});
            return Outcome<IBackendService>.Success(service);
            // return new ServiceInfo(service, endpoints); obsolete
        }

        static ServiceEndpoints createEndpoints(
            // Type controllerType, obsolete
            Type endpointsType, 
            IServiceProvider provider, 
            string serviceName)
        {
            var serviceEndpoints = endpointsType != typeof(ServiceEndpoints)
                ? (ServiceEndpoints) provider.GetService(endpointsType)
                : null;
            if (serviceEndpoints is { })
                return serviceEndpoints;

            try
            {
                // serviceName ??= controllerType.GetCustomAttribute<BackendServiceAttribute>()?.ServiceName  obsolete
                //                   ?? assumeSameAsControllerName(controllerType);

                var serviceConfigPath = ServiceAuthConfig.GetServiceConfigPath(serviceName);
                var serviceAuthConfig = getServiceAuthConfig(serviceConfigPath, provider);
                object[] parameters = null;
                var paramList = new List<object>();
                var ctors = endpointsType.GetConstructors();
                var ctor = ctors.FirstOrDefault(ctorInfo =>
                {
                    var paramInfos = ctorInfo.GetParameters();
                    foreach (var info in paramInfos)
                    {
                        if (typeof(IServiceAuthConfig).IsAssignableFrom(info.ParameterType))
                        {
                            paramList.Add(serviceAuthConfig);
                            continue;
                        }

                        if (typeof(string).IsAssignableFrom(info.ParameterType) && info.Name == "sectionIdentifier")
                        {
                            paramList.Add(serviceName);
                            continue;
                        }
                    
                        if (info.IsOptional)
                            break;

                        paramList.Add(provider.GetService(info.ParameterType));
                    }

                    parameters = paramList.ToArray();
                    return parameters.Length >= 2;
                });

                if (ctor is null)
                    throw new TypeLoadException($"Could not find correct ctor (must support parameters for {typeof(IServiceAuthConfig)} and 'sectionIdentifier' ({typeof(string)})");

                return (ServiceEndpoints) ctor.Invoke(parameters);
            }
            catch (Exception ex)
            {
                var exception = new Exception($"Failed to activate backend service endpoints {endpointsType}", ex);
                var logger = provider.GetService<ILogger<TetraPakControllerFactory>>();
                logger.Error(exception);
                throw exception;
            }
        }

        static IServiceAuthConfig getServiceAuthConfig(ConfigPath servicePath, IServiceProvider provider)
        {
            if (servicePath == s_baseServiceAuthConfigPath)
                return provider.GetRequiredService<IServiceAuthConfig>();

            var parentConfig = servicePath.Count - 1 > s_baseServiceAuthConfigPath.Count
                ? getServiceAuthConfig((ConfigPath) servicePath.TrimLast(), provider)
                : provider.GetRequiredService<IServiceAuthConfig>();
            
            var ambientData = provider.GetRequiredService<AmbientData>();
            lock (s_serviceAuthConfigs)
            {
                if (s_serviceAuthConfigs.TryGetValue(servicePath, out var config))
                    return config;
                
                config = new ServiceAuthConfig(ambientData, parentConfig, provider, servicePath.CopyLast());
                s_serviceAuthConfigs.Add(servicePath, config);
                return config;
            }
        }

        static string assumeSameAsControllerName(Type controllerType)
        {
            const string ControllerQualifier = "Controller";

            return controllerType.Name.EndsWith(ControllerQualifier) 
                ? controllerType.Name[..^ControllerQualifier.Length] 
                : controllerType.Name;
        }
    }
}