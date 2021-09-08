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

namespace WebAPI
{
    public class Startup
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ITetraPakAuthConfigDelegate, MyAuthConfigDelegate>();
            services.AddTetraPakJwtBearerAssertion();    // <-- add this for JWT bearer assertion
            services.AddTetraPakServices();              // <-- add this _after_ services.AddControllers() to support backend Tetra Pak services

            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo {Title = "demo.WebAPI", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.Use((context, func) =>
                {
                    context.Request.Headers.Add("my-header", "Hello World!");
                    return func();
                });
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo demo.WebAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseTetraPakDiagnostics(env);       // <-- add this to allow diagnostics, such a profiling headers
            
            app.UseTetraPakApiAuthentication(env); // <-- add this (after UserRouting and before UseAuthorization)
            
            app.UseAuthorization();

            app.UseEndpoints(builder => { builder.MapControllers(); });
            
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