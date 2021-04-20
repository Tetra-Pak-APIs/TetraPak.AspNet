using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TetraPak.Api.Auth;
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
            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo {Title = "demo.WebAPI", Version = "v1"}); });
            services.AddSidecarTunnel(); // <-- add this
        }

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

            //app.UseEmulatedSidecar(options => options.InjectSidecarJwtBearerAssertion()); // todo (this is an experiment with using a simulated local sidecar)

            app.UseRouting();

            app.UseSidecarTunnelAuthentication(); // <-- add this (after UserRouting and before UseAuthorization)
            
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