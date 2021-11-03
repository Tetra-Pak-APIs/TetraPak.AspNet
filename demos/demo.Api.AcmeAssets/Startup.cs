using demo.Acme.Seeding;
using demo.AcmeAssets.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TetraPak.AspNet.Api.Auth;
using TetraPak.AspNet.Auth;

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
            services.AddSingleton(p =>
            {
                // create and seed the simple repository ...
                var repo = new AssetsRepository(p.GetService<ILogger<AssetsRepository>>());
                repo.Seed(AssetsSeeder.GetAssetsSeed());
                return repo;
            });

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

            app.UseTetraPakAuthentication(env);
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}