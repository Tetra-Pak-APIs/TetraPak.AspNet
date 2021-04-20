using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;

namespace TetraPak.Api.Auth.Development
{
    // todo Finish sidecar simulator (under construction)
    public static class MockedSidecarHelper
    {
        public static IApplicationBuilder UseEmulatedSidecar(
            this IApplicationBuilder app,
            Action<MockedSidecarOptions> configure = null)
        {
            var logScope = app.ApplicationServices.CreateScope();
            var logger = logScope.ServiceProvider.GetService<ILogger<MockedSidecarOptions>>();
            var authConfig = logScope.ServiceProvider.GetService<TetraPakAuthConfig>();

            var options = new MockedSidecarOptions(logger, authConfig);
            configure?.Invoke(options);
            
            app.Use(async (context, next) =>
            {
                bool wasHandled;
                try
                {
                    ensureSimulatedAuthority(context, options);
                    wasHandled = await options.RunHandlersAsync(context);
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex);
                    throw;
                }

                if (!wasHandled)
                {
                    await next();
                }
            });
            return app;
        }

        static void ensureSimulatedAuthority(HttpContext context, MockedSidecarOptions options)
        {
            if (options.AuthConfig.IsAuthDomainAssigned)
                return;

            options.AuthConfig.AuthDomain = $"{context.Request.Scheme}://{context.Request.Host.Value}";
        }
    }

    public class MockedSidecarOptions
    {
        readonly List<SidecarHandlerInfo> _handlerInfos = new List<SidecarHandlerInfo>();
        readonly ILogger _logger;
        public TetraPakAuthConfig AuthConfig { get;  }
        
        class SidecarHandlerInfo
        {
            public MockedSidecarHandler Handler { get; }

            public object Options { get; }
            
            public SidecarHandlerInfo(MockedSidecarHandler handler, object options)
            {
                Handler = handler;
                Options = options;
            }
        }

        public void AddHandler(MockedSidecarHandler handler, object options) 
            => _handlerInfos.Add(new SidecarHandlerInfo(handler, options));

        public MockedSidecarOptions InjectSidecarJwtBearerAssertion(
            SidecarJwtBearerAssertionOptions options = null)
        {
            options ??= new SidecarJwtBearerAssertionOptions();
            AddHandler(new MockedSidecarDiscoveryDocumentHandler(), options);
            AddHandler(new MockedSidecarJwtBearerAssertionHandler(), options);
            AddHandler(new MockedSidecarAuthorityHandler(), options);
            return this;
        }

        public async Task<bool> RunHandlersAsync(HttpContext context)
        {
            if (!_handlerInfos.Any())
                return false;

            var args = new SidecarServiceArgs(this, context, _logger);
            foreach (var handlerInfo in _handlerInfos)
            {
                var wasHandled = await handlerInfo.Handler.Handle(args, handlerInfo.Options);
                if (wasHandled)
                    return true;
            }

            return false;
        }
        
        internal MockedSidecarOptions(ILogger logger, TetraPakAuthConfig authConfig)
        {
            _logger = logger;
            AuthConfig = authConfig;
        }
    }

    public class SidecarServiceArgs
    {
        public ILogger Log { get; }
        
        public MockedSidecarOptions Options { get; }
        
        public HttpContext Context { get; }
        
        internal SidecarServiceArgs(MockedSidecarOptions options, HttpContext context, ILogger log)
        {
            Options = options;
            Context = context;
            Log = log;
        }
    }

    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class SidecarJwtBearerAssertionOptions
    {
        byte[] _tokenKey;

        /// <summary>
        ///   Gets or sets a custom token signing key.
        /// </summary>
        public byte[] TokenKey
        {
            get => _tokenKey;
            set => _tokenKey = value is null || value.Length == 0 ? _tokenKey : value;
        }

        /// <summary>
        ///   Gets or sets a key id, to be included as the 'kid' JWT token claim.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        ///   Gets or sets a lifetime for JWT tokens.
        /// </summary>
        public TimeSpan TokenLifetime { get; set; }

        /// <summary>
        ///   Gets or sets a custom issuer (leave empty for current host).
        /// </summary>
        public string Issuer { get; set; }
        
        public virtual string GetIssuer(HttpContext context)
        {
            var req = context.Request;
            return $"{req.Scheme}://{req.Host}";
        }

        /// <summary>
        ///   Gets or sets an audience for all JWT tokens.
        /// </summary>
        public string Audience { get; set; }

        public SidecarJwtBearerAssertionOptions()
        {
            TokenKey = Encoding.ASCII.GetBytes(new RandomString());
            KeyId = new RandomString(20);
            TokenLifetime = TimeSpan.FromMinutes(10);
        }
    }
}