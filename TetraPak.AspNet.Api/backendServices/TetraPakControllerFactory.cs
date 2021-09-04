using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using TetraPak.AspNet.Api.Controllers;

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
            // var attribute = type.GetCustomAttribute<BackendServiceAttribute>(); obsolete
            // var serviceName = attribute?.ServiceName ?? assumeSameAsControllerName(type); obsolete
            if (!type.TryGetGenericBase(typeof(ApiGatewayController<>), out var svcControllerType))
                return s_defaultControllerFactory.CreateController(context);
            
            // use default factory unless controller supports BackendService<T> implementation of IBackendService 
            var serviceType = svcControllerType.GetGenericArguments().First();
            if (serviceType != typeof(BackendService<ServiceEndpointCollection>))
                return s_defaultControllerFactory.CreateController(context);

            var outcome = ServiceResolver.ResolveService(type, context);
            if (!outcome)
                throw outcome.Exception;

            throw new NotImplementedException(); // todo support creating typed service-consuming controllers

            // var p = context.HttpContext.RequestServices;
            // var servicesAuthConfig = p.GetRequiredService<IServiceAuthConfig>(); obsolete
            // var httpServiceProvider = p.GetRequiredService<IHttpServiceProvider>();
            // var ambientData = servicesAuthConfig.AmbientData;
            // var endpoints = new ServiceEndpoints(servicesAuthConfig, serviceName);
            // try
            // {
            //     var ctors = type.GetConstructors();
            //     if (ctors.Length != 1)
            //         throw new TypeLoadException("More than one ctor found");
            //
            //     var ctor = ctors.First();
            //     var parameterInfos = ctor.GetParameters();
            //     object[] parameters = null;
            //     if (parameterInfos.Any())
            //     {
            //         var paramList = new List<object>();
            //         foreach (var info in parameterInfos)
            //         {
            //             if (info.IsOptional)
            //                 break;
            //             
            //             paramList.Add(p.GetService(info.ParameterType));
            //         }
            //
            //         parameters = paramList.Count == 0 ? null : paramList.ToArray();
            //     }
            //     
            //     var controller = (ApiGatewayController<BackendService<ServiceEndpoints>>) ctor.Invoke(parameters);
            //     if (controller is null)
            //         throw new TypeLoadException("No controller was created"); 
            //     
            //     var service = new BackendService<ServiceEndpoints>(endpoints, httpServiceProvider);
            //     controller.ControllerContext = new ControllerContext(context);
            //     controller.SetAmbientData(ambientData);
            //     controller.SetService(service);
            //     return controller;
            // }
            // catch (Exception ex)
            // {
            //     var exception = new Exception($"Failed to activate controller {svcControllerType}", ex);
            //     var logger = p.GetService<ILogger<TetraPakControllerFactory>>();
            //     logger.Error(exception);
            //     throw exception;
            // }
        }

        public void ReleaseController(ControllerContext context, object controller)
        {
            if (controller is IDisposable disposable)
                disposable.Dispose();
        }
        
        internal static TBackendService CreateService<TBackendService>(
            ApiGatewayController<TBackendService> controller, 
            string serviceName = null) 
        where TBackendService : IBackendService
        {
            return CreateService<TBackendService>(controller.GetType(), controller.ControllerContext);
        }
        
        internal static Outcome<TBackendService> CreateService<TBackendService>(
            Type controllerType,
            ControllerContext context,
            string serviceName = null) 
        where TBackendService : IBackendService
        {
            var outcome = ServiceResolver.ResolveService(controllerType, context, typeof(TBackendService), serviceName);
            return outcome
                ? Outcome<TBackendService>.Success((TBackendService) outcome.Value)
                : Outcome<TBackendService>.Fail(outcome.Exception);
        }

        public TetraPakControllerFactory(IControllerFactory defaultControllerFactory)
        {
            s_defaultControllerFactory = defaultControllerFactory 
                                        ?? throw new ArgumentNullException(nameof(defaultControllerFactory));
        }
    }
}