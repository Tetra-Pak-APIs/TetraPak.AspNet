using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

#nullable enable

namespace TetraPak.AspNet
{
    class TetraPakClaimsTransformationDispatcher : IClaimsTransformation
    {
        static readonly object s_syncRoot = new();
        static readonly List<ClaimsTransformationFactoryInfo> s_claimsTransformations;
        readonly IServiceProvider _provider;
        ILogger? _logger;
        static IServiceCollection s_services;

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            foreach (var info in s_claimsTransformations)
            {
                ITetraPakClaimsTransformation? claimsTransformation; 
                if (info.ClaimsTransformationFactory is { })
                {
                    claimsTransformation = info.ClaimsTransformationFactory.GetClaimsTransformation(_provider);
                    principal = await claimsTransformation.TransformAsync(principal);
                    continue;
                }

                try
                {
                    claimsTransformation = _provider.GetService(info.Type) as ITetraPakClaimsTransformation;
                    switch (claimsTransformation)
                    {
                        case null:
                            var ambientData = _provider.GetService<AmbientData>();
                            var messageId = ambientData?.GetMessageId();
                            logger(_provider).Warning($"Could not resolve claims transformation service \"{info.Type}\"", messageId);
                            continue;

                        case TetraPakJwtClaimsTransformation tetraPakClaimsTransformation:
                            tetraPakClaimsTransformation.OnInitialize(_provider);
                            break;
                    }
                    principal = await claimsTransformation.TransformAsync(principal);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return principal;
        }

        ILogger? logger(IServiceProvider provider)
        {
            lock (s_syncRoot)
            {
                if (_logger is { })
                    return _logger;

                _logger = provider.GetService<ILogger<TetraPakClaimsTransformationDispatcher>>();
                return _logger;
            }
        }

        internal static void AddCustomClaimsTransformation<T>(IServiceCollection c, ServiceScope? serviceScope)
        where T : class, ITetraPakClaimsTransformation
        {
            var scope = serviceScope ?? TetraPakJwtClaimsTransformation.DefaultServiceScope;
            switch (scope)
            {
                case ServiceScope.Singleton:
                    c.AddSingleton<T>();
                    break;
                
                case ServiceScope.Scoped:
                    c.AddScoped<T>();
                    break;
                
                case ServiceScope.Transient:
                    c.AddTransient<T>();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            s_services = c; // bug (see ctor for explanation)
            s_claimsTransformations.Add(new ClaimsTransformationFactoryInfo(typeof(T), scope));
        }
        
        internal static void AddCustomClaimsTransformation(ClaimsTransformationFactory factory)
        {
            s_claimsTransformations.Add(new ClaimsTransformationFactoryInfo(factory, ServiceScope.Unspecified));
        }
        
        public TetraPakClaimsTransformationDispatcher()
        {
            // bug This is a hack to circumvent a weird problem where an injected IServiceProvider cannot resolve the registered Tetra Pak Claims Transformation services
            _provider = s_services.BuildServiceProvider();
        }

        static TetraPakClaimsTransformationDispatcher()
        {
            s_claimsTransformations = new List<ClaimsTransformationFactoryInfo>();
        }
    }

    class ClaimsTransformationFactoryInfo
    {
        public Type Type { get; }

        public ClaimsTransformationFactory? ClaimsTransformationFactory { get; }

        public ServiceScope ServiceScope { get; }
        
        public ClaimsTransformationFactoryInfo(Type type, ServiceScope serviceScope)
        {
            Type = type;
            ServiceScope = serviceScope; 
        }

        public ClaimsTransformationFactoryInfo(ClaimsTransformationFactory factory, ServiceScope serviceScope)
        {
            ClaimsTransformationFactory = factory;
            ServiceScope = serviceScope; 
        }
    }

    public abstract class ClaimsTransformationFactory : ITetraPakClaimsTransformation
    {
        internal ITetraPakClaimsTransformation GetClaimsTransformation(IServiceProvider serviceProvider)
        {
            return OnGetClaimsTransformation(serviceProvider);
        }

        protected abstract ITetraPakClaimsTransformation OnGetClaimsTransformation(IServiceProvider serviceProvider);

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITetraPakClaimsTransformation
    {
        Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal);
    }
}