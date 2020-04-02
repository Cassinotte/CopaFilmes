using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CopaFilme.Integration;
using CopaFilme.Service;
using CopaFilmeWeb.Mapper;
using CopaFilmeWeb.Middleware;
using CopaFilmeWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CopaFilmeWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            RegisterConteiner(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Copa Filme", Version = "v1" });
            });

            services.Configure<ApiLamb>(Configuration.GetSection("ApiLamb"));
        }

        private void RegisterConteiner(IServiceCollection services)
        {
            services.AddHttpClient<ICopaFilmeBase, CopaFilmeBase>();

            services.AddScoped<ISorteioService, SorteioService>();

            services.AddScoped<UrlApi>(x => new UrlApi(x.GetService<IOptions<ApiLamb>>().Value.Url));

            services.AddScoped<IMapper>(_ => AutoMapperConfig.Config());
        }


        public static void ConfigureCustomExceptionMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            ConfigureCustomExceptionMiddleware(app);

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Swagger Movies Demo V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
