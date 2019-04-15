using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Swashbuckle.AspNetCore.Swagger;

namespace BrightsIdeas.Api
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
            AppCenter.Start("b9ce1697-d3d4-4b33-a0d0-559f42bca4b6", typeof(Analytics));
            Uri endPointA = new Uri("http://services.jupix.co.uk/api/"); // this is the endpoint HttpClient will hit
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endPointA
            };
            services.AddSingleton<HttpClient>(httpClient); // note the singleton
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Properties Api", Version = "v1" });
                //options.OperationFilter<ExamplesOperationFilter>();
                //options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                //{
                //    Type = "oauth2",
                //    Flow = "password",
                //    AuthorizationUrl = $"{identitySettings.IdentityServerUrl}/connect/authorize",
                //    TokenUrl = $"{identitySettings.IdentityServerUrl}/connect/token",
                //    Scopes = new Dictionary<string, string>
                //    {
                //        { "cashflowsIdentityApi ", "cashflows Identity Api Scope " },
                //        { "openid ", "openid Scope " }
                //    }
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Properties Api");
                    c.RoutePrefix = "documentation";
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
