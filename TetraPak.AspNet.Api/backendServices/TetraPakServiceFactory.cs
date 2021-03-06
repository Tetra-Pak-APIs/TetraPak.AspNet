using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;

namespace TetraPak.AspNet.Api
{
    public static class TetraPakServiceFactory
    {
        static readonly IDictionary<ServiceKey, IBackendService> s_services 
            = new Dictionary<ServiceKey, IBackendService>();
        
        public static IServiceCollection AddTetraPakServices(
            this IServiceCollection c, 
            bool addControllerBackendServices = true)
        {
            c.TryAddSingleton<IServiceAuthConfig>(p =>
            {
                var parentConfig = p.GetRequiredService<TetraPakAuthConfig>();
                // var ambientData = p.GetRequiredService<AmbientData>(); obsolete
                return new ServiceAuthConfig(p, parentConfig);
            });
            c.AddTetraPakServiceEndpoints();
            c.TryAddSingleton<IHttpServiceProvider,HttpServiceProvider>();
            c.AddTetraPakTokenExchangeService();
            c.AddTetraPakClientCredentialsService();
            if (addControllerBackendServices)
            {
                // register all API gateway controllers and corresponding services,
                // then replace controller factory to automatically activate non-custom (derived) services and endpoints 
                c.AddControllerBackendServices();
                // var p = c.BuildServiceProvider(); // todo Consider re-introducing custom controller factory when needed
                // var defaultControllerFactory = p.GetService<IControllerFactory>();
                // c.Replace(new ServiceDescriptor(typeof(IControllerFactory), 
                //     _ => new TetraPakControllerFactory(defaultControllerFactory), 
                //     ServiceLifetime.Singleton));
            }

            return c;
        }

        public static IServiceCollection AddTetraPakServiceEndpoints(this IServiceCollection c)
        {
            c.AddAmbientData();
            c.TryAddTransient<ServiceInvalidEndpoint>();
            return c;
        }

        public static void AddControllerBackendServices(this IServiceCollection c, params Assembly[] assemblies)
        {
            assemblies = assemblies.Any() ? assemblies : new[] { Assembly.GetEntryAssembly() };
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(i => i.GetCustomAttribute<ApiControllerAttribute>() is {}).ToArray();
                HashSet<Type> registered = new();
                for (var i = 0; i < types.Length; i++)
                {
                    var type = types[i];
                    if (!type.TryGetGenericBase(typeof(ApiGatewayController<>), out var apiGatewayControllerType))
                        continue;
                    
                    var serviceType = apiGatewayControllerType.GetGenericArguments().First();
                    if (registered.Contains(serviceType))
                        continue;
                    
                    if (!serviceType.TryGetGenericBase(typeof(BackendService<>), out var backendServiceType))
                        throw new Exception(
                            $"Unexpected error: Generic service type {serviceType} does not inherit from {typeof(BackendService<>)}");

                    var endpointsType = backendServiceType.GetGenericArguments().First();
                    if (serviceType.IsAbstract)
                        throw new InvalidOperationException(
                            $"Invalid backend service type: {serviceType}. Type cannot be abstract");

                    // non-custom (derived) service and endpoints will be handled by custom controller factory
                    // (see TetraPakControllerFactory)
                    if (serviceType == typeof(BackendService<ServiceEndpointCollection>))
                        continue;
                    
                    c.TryAddSingleton(serviceType);
                    c.TryAddSingleton(endpointsType);
                    registered.Add(serviceType);
                }
            }
        }
        
        // public static IApplicationBuilder UseTetraPakServicesDiagnostics(this IApplicationBuilder app) obsolete
        // {
        //     const string TotalName = "*";
        //     
        //     var config = app.ApplicationServices.GetService<TetraPakAuthConfig>();
        //     if (!(config?.EnableDiagnostics ?? false))
        //         return app;
        //
        //     app.Use(async (context, func) =>
        //     {
        //         var logger = app.ApplicationServices.GetService<ILogger<ServiceDiagnostics>>();
        //         var diagnostics = context.BeginDiagnostics(logger);
        //         context.Response.OnStarting(() =>
        //         {
        //             if (diagnostics is null)
        //                 return Task.CompletedTask;
        //
        //             diagnostics.End(logger);
        //             var timers = diagnostics.GetValues(ServiceDiagnostics.TimerPrefix).ToArray();
        //             var timerNameIndex = ServiceDiagnostics.TimerPrefix.Length + 1;
        //             var sb = new StringBuilder();
        //             var timer = (ServiceDiagnostics.Timer) timers[0].Value;
        //             var key = timers[0].Key;
        //             var name = key.Length == ServiceDiagnostics.TimerPrefix.Length 
        //                 ? TotalName 
        //                 : key[timerNameIndex..];
        //             sb.Append($"{name}={timer.ElapsedMs().ToString()}");
        //             for (var i = 1; i < timers.Length; i++)
        //             {
        //                 sb.Append(", ");
        //                 timer = (ServiceDiagnostics.Timer) timers[i].Value;
        //                 key = timers[i].Key;
        //                 name = key.Length == ServiceDiagnostics.TimerPrefix.Length 
        //                     ? TotalName 
        //                     : key[timerNameIndex..];
        //                 sb.Append($"{name}={timer.ElapsedMs().ToString()}");
        //             }
        //
        //             var timerValues = sb.ToString();
        //             context.Response.Headers.Add(ServiceDiagnostics.TimerPrefix, timerValues);
        //             return Task.CompletedTask;
        //         });
        //
        //         await func();
        //     });
        //
        //     return app;
        // }
        
        public static Outcome<TBackendService> GetService<TBackendService>(
            ControllerBase controller, 
            string serviceName = null) 
        where TBackendService : IBackendService
        {
            var key = new ServiceKey(controller, typeof(TBackendService));
            lock (s_services)
            {
                if (s_services.TryGetValue(key, out var service))
                    return Outcome<TBackendService>.Success((TBackendService) service);
                
                var outcome = ServiceResolver.ResolveService(
                    controller.GetType(), 
                    controller.ControllerContext, 
                    typeof(TBackendService),
                    serviceName);
                if (!outcome)
                    return Outcome<TBackendService>.Fail(outcome.Exception);

                service = outcome.Value;
                s_services.Add(key, outcome.Value);
                return Outcome<TBackendService>.Success((TBackendService) service);
            }
        }

        internal static Outcome<IBackendService> GetService(ControllerBase controller, string serviceName = null)
            => GetServiceWithEndpoints<ServiceEndpointCollection>(controller, serviceName);

        internal static Outcome<IBackendService> GetServiceWithEndpoints<TEndpoints>(
            ControllerBase controller, 
            string serviceName = null)
        where TEndpoints : ServiceEndpointCollection
        {
            var key = new ServiceKey(controller, typeof(BackendService<TEndpoints>));
            lock (s_services)
            {
                if (s_services.TryGetValue(key, out var service))
                    return Outcome<IBackendService>.Success(service);

                var outcome = ServiceResolver.ResolveService(
                    controller.GetType(),
                    controller.ControllerContext, 
                    typeof(BackendService<TEndpoints>), 
                    serviceName);
                if (outcome)
                {
                    s_services.Add(key, outcome.Value);
                }
                return outcome;
            }
        }

        public static ServiceEndpoint Endpoint(this IBackendService service, string name) => service.GetEndpoint(name);
    }
}