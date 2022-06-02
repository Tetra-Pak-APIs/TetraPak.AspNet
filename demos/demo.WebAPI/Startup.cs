using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TetraPak.AspNet;
using TetraPak.AspNet.Api;
using TetraPak.AspNet.Api.Auth;
using TetraPak.Logging;
using TetraPak.SecretsManagement;
using WebAPI.spike_customAuthScheme;

namespace WebAPI
{
    public sealed class Startup
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ITetraPakSecretsProvider, MySecretsProvider>();
            services.AddSingleton<ITetraPakConfigDelegate, MyConfigDelegate>();
            
            services.AddTetraPakJwtBearerAssertion()
                    .AddJwtBearer("obsolete", options => // <-- spike: test additional (AAD) JWT Bearer auth scheme
                    {
                        options.Authority =  "https://api-dev.tetrapak.com/oauth2/v2";
                        options.SaveToken = true;
                        options.TokenValidationParameters.ValidateLifetime = false;
                        options.TokenValidationParameters.ValidAudiences = new []{ "https://ta01qtastst01.azurewebsites.net", "EdgeIDP" };
                        options.Events.OnAuthenticationFailed = OnJwtAuthenticationFailed;
                    })  
                    // .AddScheme<AliBabaAuthenticationOptions,AliBabaAuthenticationHandler>("AliBaba", null)
                    .AddAliBabaAuthentication();            // <-- spike: testing custom auth scheme
            services.AddTetraPakCustomClaimsTransformation<AliBabaClaimsTransformation>();
            services.AddTetraPakServices();              // <-- add this _after_ services.AddControllers() to support backend Tetra Pak services

            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo {Title = "demo.WebAPI", Version = "v1"}); });
        }

        Task OnJwtAuthenticationFailed(AuthenticationFailedContext arg) => Task.CompletedTask; // spike throw away

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo demo.WebAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseTetraPakDiagnostics();       // <-- add this to allow diagnostics, such a profiling headers
            
            app.UseTetraPakApiAuthentication(env); // <-- add this (after UserRouting and before UseAuthorization)
            
            app.UseAuthorization();

            app.UseEndpoints(builder => { builder.MapControllers(); });

            app.UseCors(builder => 
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            
            var logScope = app.ApplicationServices.CreateScope();
            var logger = logScope.ServiceProvider.GetService<ILogger<Startup>>();
            logger.Information($"STARTING: Environment: {env.EnvironmentName}");
        }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}