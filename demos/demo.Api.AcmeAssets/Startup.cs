using demo.Acme.Seeding;
using demo.AcmeAssets.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TetraPak.AspNet;
using TetraPak.AspNet.Api.Auth;

namespace demo.AcmeAssets
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "demo.Api.AcmeAssets", Version = "v1" });
            });
            // create a simple file repository, to allow uploading more files ...
            services.AddSingleton<FilesRepository>();

            // create and seed the simple assets repository ...
            services.AddSingleton(p =>
            {
                var repo = new AssetsRepository(p.GetService<ILogger<AssetsRepository>>());
                repo.Seed(AssetsSeeder.GetAssetsSeed());
                return repo;
            });
            
            // enable Tetra Pak's JWT bearer assertion mechanism ...
            services.AddTetraPakJwtBearerAssertion();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo.Api.AcmeAssets v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // activate Tetra Pak's API authentication mechanism ...
            app.UseTetraPakApiAuthentication(env);
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.LogTetraPakConfiguration();
        }
    }
}