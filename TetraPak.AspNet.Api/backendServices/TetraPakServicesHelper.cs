using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;
using TetraPak.AspNet.diagnostics;
using TetraPak.AspNet.Diagnostics;

namespace TetraPak.AspNet.Api
{
    public static class TetraPakServicesHelper
    {
        public static IServiceCollection AddTetraPakServices(
            this IServiceCollection c, 
            bool addControllerBackendServices = true)
        {
            c.TryAddSingleton<ServicesAuthConfig>();
            c.AddTetraPakServiceEndpoints();
            c.TryAddSingleton<IHttpServiceProvider,HttpServiceProvider>();
            c.AddTetraPakTokenExchangeService();
            c.AddTetraPakClientCredentialsService();
            if (addControllerBackendServices)
            {
                // register all API gateway controllers and corresponding services,
                // then replace controller factory to automatically activate non-custom (derived) services and endpoints 
                c.AddControllerBackendServices();
                var p = c.BuildServiceProvider();
                var defaultControllerFactory = p.GetService<IControllerFactory>();
                c.Replace(new ServiceDescriptor(typeof(IControllerFactory), 
                    _ => new TetraPakControllerFactory(defaultControllerFactory), 
                    ServiceLifetime.Singleton));
            }

            return c;
        }

        public static IServiceCollection AddTetraPakServiceEndpoints(this IServiceCollection c)
        {
            c.TryAddTransient<AmbientData>();
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
                    if (serviceType == typeof(BackendService<ServiceEndpoints>))
                        continue;
                    
                    c.TryAddSingleton(serviceType);
                    c.TryAddSingleton(endpointsType);
                    registered.Add(serviceType);
                }
            }
        }
        
        public static IApplicationBuilder UseTetraPakServicesDiagnostics(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetService<TetraPakAuthConfig>();
            if (!(config?.EnableDiagnostics ?? false))
                return app;

            app.Use(async (context, func) =>
            {
                var logger = app.ApplicationServices.GetService<ILogger<ServiceDiagnostics>>();
                var diagnostics = context.BeginDiagnostics(logger);
                context.Response.OnStarting(async () =>
                {
                    if (diagnostics is null)
                        return;

                    diagnostics.End(logger);
                    foreach (var (key, value) in diagnostics)
                    {
                        if (value is ServiceDiagnostics.Timer timer)
                        {
                            context.Response.Headers.Add(key, timer.ElapsedMs().ToString(CultureInfo.InvariantCulture));
                            continue;
                        }
                        
                        context.Response.Headers.Add(key, value?.ToString());
                    }
                });

                await func();
            });

            return app;
        }

    }
}