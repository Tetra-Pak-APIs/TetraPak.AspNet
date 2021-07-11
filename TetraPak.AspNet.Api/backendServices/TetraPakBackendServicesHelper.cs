using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Api.Controllers;

namespace TetraPak.AspNet.Api
{
    public static class TetraPakBackendServicesHelper
    {
                public static IServiceCollection AddBackendServices(this IServiceCollection c, bool addControllerBackendServices = true)
        {
            c.TryAddSingleton<ServicesAuthConfig>();
            c.AddTetraPakServiceEndpoints();
            c.TryAddSingleton<IHttpServiceProvider,HttpServiceProvider>();
            c.AddTetraPakTokenExchangeService();
            c.AddTetraPakClientCredentialsService();
            if (addControllerBackendServices)
            {
                c.AddControllerBackendServices();
            }
            return c;
        }

        public static IServiceCollection AddTetraPakServiceEndpoints(this IServiceCollection c)
        {
            c.TryAddTransient<AmbientData>();
            c.TryAddTransient<ServiceInvalidEndpoint>();
            return c;
        }

        public static IServiceCollection AddControllerBackendServices(this IServiceCollection c, params Assembly[] assemblies)
        {
            assemblies = assemblies.Any() ? assemblies : new[] { Assembly.GetEntryAssembly() };
            foreach (var assembly in assemblies)
            {
                addControllerBackendServices(assembly);
            }

            return c;
            
            void addControllerBackendServices(Assembly assembly)
            {
                var types = assembly.GetTypes().Where(i => i.GetCustomAttribute<ApiControllerAttribute>() is {}).ToArray();
                HashSet<Type> registered = new();
                for (var i = 0; i < types.Length; i++)
                {
                    var type = types[i];
                    if (!type.TryGetGenericBase(typeof(ApiGatewayController<>), out var controllerType))
                        continue;
                    
                    var serviceType = controllerType.GetGenericArguments().First();
                    if (registered.Contains(serviceType))
                        continue;
                    
                    if (!serviceType.TryGetGenericBase(typeof(BackendService<>), out var backendServiceType))
                        throw new Exception(
                            $"Unexpected error: Generic service type {serviceType} does not inherit from {typeof(BackendService<>)}");

                    var endpointsType = backendServiceType.GetGenericArguments().First();
                    if (serviceType.IsAbstract)
                        throw new InvalidOperationException(
                            $"Invalid backend service type: {serviceType}. Type cannot be abstract");
                        
                    if (endpointsType.IsAbstract)
                        throw new InvalidOperationException(
                            $"Invalid backend endpoints type: {endpointsType}. Type cannot be abstract");

                    c.TryAddSingleton(serviceType);
                    c.TryAddSingleton(endpointsType);
                    registered.Add(serviceType);
                }
            }
        }
    }
}