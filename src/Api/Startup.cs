using Insurance.Application;
using Insurance.Application.Common.Interfaces;
using Insurance.Infrastructure;
using Insurance.Api.Filters;
using Insurance.Api.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System;

namespace Insurance.Api
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
            services.AddApplication();
            services.AddInfrastructure(Configuration);


            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks();

            services.AddControllers(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
                    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddApiVersioning(options =>
                 {
                     options.AssumeDefaultVersionWhenUnspecified = true;
                     options.DefaultApiVersion = ApiVersion.Default;
                     //options.ApiVersionReader = ApiVersionReader.Combine(
                     //    new MediaTypeApiVersionReader("version"),
                     //    new HeaderApiVersionReader("X-version")
                     //    );
                     options.ReportApiVersions = true;
                 });

              services.AddVersionedApiExplorer(options =>
               {
                   options.DefaultApiVersion = new ApiVersion(1, 0);
                   options.GroupNameFormat = "'v'VVV";
                   options.SubstituteApiVersionInUrl = true;
               });


            services.AddRazorPages();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var versions = new[]
    {
        // Here you can control the minor version of each supported major version
        new Version(1, 0),
        new Version(2, 0)
    };

            foreach (var version in versions) {



                services.AddOpenApiDocument(options =>
                {
                    options.Title = "Insurance API";
                    options.Description = $"Insurance API Version {version.Major}.";
                    options.DocumentName = "v" + version.Major;
                    options.ApiGroupNames = new string[] { "v" + version.Major };
                    options.Version = version.Major + "." + version.Minor;
                    options.AllowReferencesWithProperties = true;
                    options.PostProcess = document =>
                    {
                        var prefix = "/api/v" + version.Major;
                        foreach (var pair in document.Paths.ToArray())
                        {
                            document.Paths.Remove(pair.Key);
                            document.Paths[pair.Key[prefix.Length..]] = pair.Value;
                        }
                    };
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwaggerUi3();
            app.UseOpenApi(options =>
            {
                options.PostProcess = (document, request) =>
                {
                    // Patch server URL for Swagger UI
                    var prefix = "/api/v" + document.Info.Version.Split('.')[0];
                    document.Servers.First().Url += prefix;
                };
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
