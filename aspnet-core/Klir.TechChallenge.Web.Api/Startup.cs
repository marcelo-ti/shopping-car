using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Adapter.In.Calculators;
using Klir.TechChallenge.Web.Api.Adapter.Out.Persistence;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using Klir.TechChallenge.Web.Api.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Klir.TechChallenge.Web.Api
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ProductRepository>();
            services.AddSingleton<OrderRepository>();
            services.AddScoped<IGetProductQuery, GetProductService>();
            services.AddScoped<IGetOrderQuery, GetOrderService>();
            services.AddScoped<ILoadProduct, ProductQueryAdapter>();
            services.AddScoped<ILoadOrder, OrderQueryAdapter>();
            services.AddScoped<ISaveNewOrderPort, OrderPersistenceAdapter>();
            services.AddScoped<IEngineCalculator, EngineCalculator>();
            services.AddScoped<ICalculator, Buy1Get1FreeCalculator>();
            services.AddScoped<ICalculator, Buy3For10EuroCalculator>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                    builder => { builder.WithOrigins("http://localhost:4200"); });
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "KlirTechChallenge", Version = "v1"});
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options =>
                options.PreSerializeFilters.Add((document, request) =>
                {
                    var apiRoutePrefix =
                        $"{(request.Host.Host.ToLower().Contains("xpinc.io") ? $"/xpinc-digitalusa-onboarding" : string.Empty)}";

                    document.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer
                        {
                            Url = $"{request.Scheme}://{request.Host.Value}{apiRoutePrefix}"
                        }
                    };
                }));

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"./{description.GroupName}/swagger.json",
                        description.GroupName.ToLowerInvariant());
                }
            });

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}