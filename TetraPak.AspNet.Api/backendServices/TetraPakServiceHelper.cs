using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.DataTransfers;
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Assists in configuring support for Tetra Pak managed services consumption.
    /// </summary>
    public static class TetraPakServiceHelper
    {
        // static readonly IDictionary<ServiceKey, IBackendService> s_services 
        //     = new Dictionary<ServiceKey, IBackendService>();

        /// <summary>
        ///   (fluent API)<br/>
        ///   Adds services needed to support consumption of "downstream" Tetra Pak managed services. 
        /// </summary>
        /// <param name="collection">
        ///   The service collection.
        /// </param>
        /// <returns>
        ///   The <paramref name="collection"/>.
        /// </returns>
        public static IServiceCollection AddTetraPakServices(this IServiceCollection collection) 
        {
            collection.AddTetraPakConfiguration();
            collection.TryAddSingleton<IServiceAuthConfig>(p =>
            {
                var parentConfig = p.GetRequiredService<TetraPakConfig>();
                return new ServiceAuthConfig(parentConfig, p.GetRequiredService<AmbientData>());
            });
            collection.AddAmbientData();
            collection.AddTetraPakTokenExchangeService();
            collection.AddTetraPakClientCredentialsService();
            
            collection.TryAddSingleton<TetraPakBackendServiceProvider>();
            collection.TryAddSingleton<IBackendServiceProvider,TetraPakBackendServiceProvider>();
            collection.AddTetraPakHttpClientProvider();
            collection.AddTetraPakAuthorizationService<TetraPakApiAuthorizationService>();
            TetraPakBackendServiceProvider.InitializeServices(collection);
            // if (addBackendServices)
            // {
            //     // register all API gateway controllers and corresponding services,
                // then replace controller factory to automatically activate non-custom (derived) services and endpoints
                // c.AddControllerBackendServices();
                // var p = c.BuildServiceProvider(); // todo Consider re-introducing custom controller factory when needed
                // var defaultControllerFactory = p.GetService<IControllerFactory>();
                // c.Replace(new ServiceDescriptor(typeof(IControllerFactory), 
                //     _ => new TetraPakControllerFactory(defaultControllerFactory), 
                //     ServiceLifetime.Singleton));
            // }

            return collection;
        }
        
        // public static IServiceCollection AddTetraPakServiceEndpointTypes(this IServiceCollection c) obsolete
        // {
        //     c.TryAddTransient<AmbientData>();
        //     c.TryAddTransient<ServiceInvalidEndpoint>();
        //     return c;
        // }

        // public static void AddControllerBackendServices(this IServiceCollection c, params Assembly[] assemblies) obsolete
        // {
        //     throw new NotImplementedException();
        //     // assemblies = assemblies.Any() ? assemblies : new[] { Assembly.GetEntryAssembly() };
        //     // foreach (var assembly in assemblies)
        //     // {
        //     //     var types = assembly.GetTypes().Where(i => i.GetCustomAttribute<ApiControllerAttribute>() is {}).ToArray();
        //     //     HashSet<Type> registered = new();
        //     //     for (var i = 0; i < types.Length; i++)
        //     //     {
        //     //         var type = types[i];
        //     //         if (!type.TryGetGenericBase(typeof(ApiGatewayController<>), out var apiGatewayControllerType))
        //     //             continue;
        //     //         
        //     //         var serviceType = apiGatewayControllerType.GetGenericArguments().First();
        //     //         if (registered.Contains(serviceType))
        //     //             continue;
        //     //         
        //     //         if (!serviceType.TryGetGenericBase(typeof(BackendService<>), out var backendServiceType))
        //     //             throw new Exception(
        //     //                 $"Unexpected error: Generic service type {serviceType} does not inherit from {typeof(BackendService<>)}");
        //     //
        //     //         var endpointsType = backendServiceType.GetGenericArguments().First();
        //     //         if (serviceType.IsAbstract)
        //     //             throw new InvalidOperationException(
        //     //                 $"Invalid backend service type: {serviceType}. Type cannot be abstract");
        //     //
        //     //         // non-custom (derived) service and endpoints will be handled by custom controller factory
        //     //         // (see TetraPakControllerFactory)
        //     //         if (serviceType == typeof(BackendService<ServiceEndpoints>))
        //     //             continue;
        //     //         
        //     //         c.TryAddSingleton(serviceType);
        //     //         c.TryAddSingleton(endpointsType);
        //     //         registered.Add(serviceType);
        //     //     }
        //     // }
        // }
        
        /// <summary>
        ///   (fluent API)<br/>
        ///   Injects middleware that diagnoses and logs statistics for "downstream" services.  
        /// </summary>
        /// <param name="applicationBuilder">
        ///   The application builder instance. 
        /// </param>
        /// <returns>
        ///   The <paramref name="applicationBuilder"/>   
        /// </returns>
        public static IApplicationBuilder UseTetraPakServicesDiagnostics(this IApplicationBuilder applicationBuilder)
        {
            const string TotalName = "*";
            
            var config = applicationBuilder.ApplicationServices.GetService<TetraPakConfig>();
            if (!(config?.EnableDiagnostics ?? false))
                return applicationBuilder;

            applicationBuilder.Use(async (context, func) =>
            {
                var logger = applicationBuilder.ApplicationServices.GetService<ILogger<ServiceDiagnostics>>();
                var diagnostics = context.BeginDiagnostics(logger);
                context.Response.OnStarting(() =>
                {
                    if (diagnostics is null)
                        return Task.CompletedTask;

                    diagnostics.End();
                    var timers = diagnostics.GetValues(ServiceDiagnostics.TimerPrefix).ToArray();
                    var timerNameIndex = ServiceDiagnostics.TimerPrefix.Length + 1;
                    var sb = new StringBuilder();
                    var timer = (ServiceDiagnostics.Timer) timers[0].Value;
                    var key = timers[0].Key;
                    var name = key.Length == ServiceDiagnostics.TimerPrefix.Length 
                        ? TotalName 
                        : key[timerNameIndex..];
                    sb.Append($"{name}={timer.ElapsedMs().ToString()}");
                    for (var i = 1; i < timers.Length; i++)
                    {
                        sb.Append(", ");
                        timer = (ServiceDiagnostics.Timer) timers[i].Value;
                        key = timers[i].Key;
                        name = key.Length == ServiceDiagnostics.TimerPrefix.Length 
                            ? TotalName 
                            : key[timerNameIndex..];
                        sb.Append($"{name}={timer.ElapsedMs().ToString()}");
                    }

                    var timerValues = sb.ToString();
                    context.Response.Headers.Add(ServiceDiagnostics.TimerPrefix, timerValues);
                    return Task.CompletedTask;
                });

                await func();
            });

            return applicationBuilder;
        }
        
        /// <summary>
        ///   Obtains and returns a configured backend service (<see cref="IBackendService"/>).
        /// </summary>
        /// <param name="controller">
        ///   The extended controller.
        /// </param>
        /// <param name="serviceName">
        ///   The name of the backend service (must be found in the configuration).
        /// </param>
        /// <typeparam name="TBackendService">
        ///   The expected type of backend service.
        /// </typeparam>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="TBackendService"/> or, on failure, an <see cref="Exception"/>.
        /// </returns>
        public static Outcome<TBackendService> GetBackendService<TBackendService>(
            this ControllerBase controller, 
            string? serviceName = null) 
        where TBackendService : IBackendService
        {
            if (!controller.TryGetTetraPakApiConfig(out var tetraPakApiConfig))
                return Outcome<TBackendService>.Fail(
                    new ServerConfigurationException($"Cannot resolved backend service '{serviceName}. "+
                                               $"Ensure backend service was set up (see {nameof(TetraPakServiceHelper)}.{nameof(AddTetraPakServices)})"));
                
            var outcome = tetraPakApiConfig.BackendServiceProvider?.ResolveService(
                typeof(TBackendService),
                serviceName);
            if (outcome is null)
                return Outcome<TBackendService>.Fail(
                    new ServerConfigurationException($"Cannot resolved backend service '{serviceName}. "+
                                               $"Ensure backend service was set up (see {nameof(TetraPakServiceHelper)}.{nameof(AddTetraPakServices)})"));
                
            if (!outcome)
                return Outcome<TBackendService>.Fail(outcome.Exception);

            var service = outcome.Value!;
            return Outcome<TBackendService>.Success((TBackendService) service);
        }

        internal static Outcome<IBackendService> GetService(
            ControllerBase controller, 
            string serviceName)
            => GetServiceWithEndpoints<ServiceEndpoints>(controller, serviceName);

        internal static Outcome<IBackendService> GetServiceWithEndpoints<TEndpoints>(
            ControllerBase controller, 
            string serviceName)
        where TEndpoints : ServiceEndpoints
        {
            if (!controller.TryGetTetraPakApiConfig(out var tetraPakApiConfig))
                return Outcome<IBackendService>.Fail(
                    new ServerConfigurationException($"Cannot resolved backend service '{serviceName}. "+
                                               $"Ensure backend service was set up (see {nameof(TetraPakServiceHelper)}.{nameof(AddTetraPakServices)})"));

            var outcome = tetraPakApiConfig.BackendServiceProvider?.ResolveService(
                typeof(BackendService<TEndpoints>), 
                serviceName);
            if (outcome is null)
                return Outcome<IBackendService>.Fail(
                    new ServerConfigurationException($"Cannot resolved backend service '{serviceName}. "+
                                               $"Ensure backend service was set up (see {nameof(TetraPakServiceHelper)}.{nameof(AddTetraPakServices)})"));

            return outcome;
        }

        /// <summary>
        ///   Returns a specified backend service endpoint.
        /// </summary>
        /// <param name="service">
        ///   The extended backend service.
        /// </param>
        /// <param name="name">
        ///   The name of the requested endpoint (as specified in configuration).
        /// </param>
        /// <returns>  
        /// </returns>
        public static ServiceEndpoint Endpoint(this IBackendService service, string name) => service.GetEndpoint(name);

        public static DtoRelationshipLocator GetRelLocatorFor(this ServiceEndpoint self, params string[] keys) 
            => self.GetRelLocatorFor(keys, null, Array.Empty<HttpMethod>());

        public static DtoRelationshipLocator GetRelLocatorFor(
            this ServiceEndpoint self, 
            string[]? keys, 
            HttpQuery? query,
            HttpMethod[]? methods)
        {
            var path = HateoasHelper.BuildPath(self.GetUrl(self.TrimHostInResponses), keys, query);
            return new DtoRelationshipLocator(path, methods.DefaultToGetVerb());
        }
    }
}