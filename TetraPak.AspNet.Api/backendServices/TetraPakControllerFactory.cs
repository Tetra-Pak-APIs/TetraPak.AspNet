using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Api.Controllers;
using TetraPak.AspNet.Auth;
using TetraPak.Logging;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Deals with activating non-custom (derived) API gateway controllers. 
    /// </summary>
    class TetraPakControllerFactory : IControllerFactory
    {
        static IControllerFactory s_defaultControllerFactory;

        public object CreateController(ControllerContext context)
        {
            var type = context.ActionDescriptor.ControllerTypeInfo;
            var attribute = type.GetCustomAttribute<BackendServiceAttribute>();
            var serviceName = attribute?.ServiceName ?? assumeSameAsControllerName(type);
            if (!type.TryGetGenericBase(typeof(ApiGatewayController<>), out var svcControllerType))
                return s_defaultControllerFactory.CreateController(context);
            
            // use default factory unless controller supports BackendService<T> implementation of IBackendService 
            var serviceType = svcControllerType.GetGenericArguments().First();
            if (serviceType != typeof(BackendService<ServiceEndpoints>))
                return s_defaultControllerFactory.CreateController(context);

            var p = context.HttpContext.RequestServices;
            var servicesAuthConfig = p.GetService<ServicesAuthConfig>();
            var httpServiceProvider = p.GetRequiredService<IHttpServiceProvider>();
            var endpoints = new ServiceEndpoints(servicesAuthConfig, serviceName);
            var ambientData = p.GetRequiredService<AmbientData>();
            try
            {
                var ctors = type.GetConstructors();
                if (ctors.Length != 1)
                    throw new TypeLoadException("More than one ctor found");

                var ctor = ctors.First();
                var parameterInfos = ctor.GetParameters();
                object[] parameters = null;
                if (parameterInfos.Any())
                {
                    var paramList = new List<object>();
                    foreach (var info in parameterInfos)
                    {
                        if (info.IsOptional)
                            break;
                        
                        paramList.Add(p.GetService(info.ParameterType));
                    }

                    parameters = paramList.Count == 0 ? null : paramList.ToArray();
                }
                
                var controller = (ApiGatewayController<BackendService<ServiceEndpoints>>) ctor.Invoke(parameters);
                if (controller is null)
                    throw new TypeLoadException("No controller was created"); 
                
                var service = new BackendService<ServiceEndpoints>(endpoints, httpServiceProvider);
                controller.ControllerContext = new ControllerContext(context);
                controller.SetAmbientData(ambientData);
                controller.SetService(service);
                return controller;
            }
            catch (Exception ex)
            {
                var exception = new Exception($"Failed to activate controller {svcControllerType}", ex);
                var logger = p.GetService<ILogger<TetraPakControllerFactory>>();
                logger.Error(exception);
                throw exception;
            }
        }

        public void ReleaseController(ControllerContext context, object controller)
        {
            if (controller is IDisposable disposable)
                disposable.Dispose();
        }
        
        internal static TBackendService CreateService<TBackendService>(ApiGatewayController<TBackendService> controller) 
        where TBackendService : IBackendService
        {
            return CreateService<TBackendService>(controller.GetType(), controller.ControllerContext);
            }
        
        internal static TBackendService CreateService<TBackendService>(Type controllerType, ControllerContext context) 
        where TBackendService : IBackendService
        {
            var p = context.HttpContext.RequestServices;
            if (!controllerType.TryGetGenericBase(typeof(ApiGatewayController<>), out var apiGatewayControllerType))
                throw new InvalidOperationException($"Cannot create backend service for controller type {controllerType} (not a API gateway controller)");
            
            // use default service locator unless controller supports BackendService<T> implementation of IBackendService
            var serviceType = apiGatewayControllerType.GetGenericArguments().First();
            var service = (TBackendService) p.GetService(serviceType);
            if (service is { })
            {
                if (isInitialized())
                    return service;
            }
            
            if (!serviceType.TryGetGenericBase(typeof(BackendService<>), out var baseServiceType))
                return (TBackendService) p.GetService(serviceType);

            try
            {
                var endpointsType = baseServiceType.GetGenericArguments().First();
                var httpServiceProvider = p.GetRequiredService<IHttpServiceProvider>();
                var endpoints = createEndpoints(endpointsType);
                if (service is { })
                    return initialize(endpoints, httpServiceProvider);

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
                        
                        paramList.Add(p.GetService(info.ParameterType));
                    }

                    if (paramList.Count < 2)
                        return false;
                    
                    parameters = paramList.ToArray();
                    return true;
                });
                
                if (ctor is null)
                    throw new TypeLoadException("Unsupported ctor signature");

                service = (TBackendService) ctor.Invoke(parameters);
                return parameters.Length != 0 
                    ? service 
                    : initialize(endpoints, httpServiceProvider);
            }
            catch (Exception ex)
            {
                var exception = new Exception($"Failed to activate backend service {serviceType}", ex);
                var logger = p.GetService<ILogger<TetraPakControllerFactory>>();
                logger.Error(exception);
                throw exception;
            }
            
            bool isInitialized()
            {
                var isInitializeMethod = serviceType.GetMethod("IsInitialized", BindingFlags.Instance | BindingFlags.NonPublic);
                if (isInitializeMethod is null)
                    throw new TypeLoadException("No (internal) 'IsInitialized' method found");
                
                var obj = isInitializeMethod.Invoke(service, Array.Empty<object>());
                if (obj is not bool bValue) 
                    throw new TypeLoadException($"Unexpected result from (internal) 'IsInitialized' method: {obj}. Expected boolean");

                return bValue;
            }


            TBackendService initialize(ServiceEndpoints endpoints, IHttpServiceProvider httpServiceProvider)
            {
                var initializeMethod = serviceType.GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic);
                if (initializeMethod is null)
                    throw new TypeLoadException("No (internal) 'Initialize' method found");
                
                initializeMethod.Invoke(service, new object[] {endpoints, httpServiceProvider});
                return service;
            }
            
            ServiceEndpoints createEndpoints(Type endpointsType)
            {
                var serviceEndpoints = endpointsType != typeof(ServiceEndpoints)
                    ? (ServiceEndpoints) p.GetService(endpointsType)
                    : null;
                if (serviceEndpoints is { })
                    return serviceEndpoints;

                try
                {
                    var serviceName = controllerType.GetCustomAttribute<BackendServiceAttribute>()?.ServiceName 
                                      ?? assumeSameAsControllerName(controllerType);
                    var servicesAuthConfig = p.GetService<IServiceAuthConfig>();

                    object[] parameters = null;
                    var ctors = endpointsType.GetConstructors();
                    var ctor = ctors.FirstOrDefault(ctorInfo =>
                    {
                        var paramList = new List<object>();
                        var paramInfos = ctorInfo.GetParameters();
                        foreach (var info in paramInfos)
                        {
                            if (typeof(IServiceAuthConfig).IsAssignableFrom(info.ParameterType))
                            {
                                paramList.Add(servicesAuthConfig);
                                continue;
                            }

                            if (typeof(string).IsAssignableFrom(info.ParameterType) && info.Name == "sectionIdentifier")
                            {
                                paramList.Add(serviceName);
                                continue;
                            }
                        
                            if (info.IsOptional)
                                break;

                            paramList.Add(p.GetService(info.ParameterType));
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
                    var logger = p.GetService<ILogger<TetraPakControllerFactory>>();
                    logger.Error(exception);
                    throw exception;
                }
                
            }
        }


        static string assumeSameAsControllerName(Type controllerType)
        {
            const string ControllerQualifier = "Controller";

            return controllerType.Name.EndsWith(ControllerQualifier) 
                ? controllerType.Name[..^ControllerQualifier.Length] 
                : controllerType.Name;
        }

        public TetraPakControllerFactory(IControllerFactory defaultControllerFactory)
        {
            s_defaultControllerFactory = defaultControllerFactory 
                                        ?? throw new ArgumentNullException(nameof(defaultControllerFactory));
        }
    }
}