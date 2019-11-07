using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreMvc
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            // services.AddDistributedMemoryCache();
            services.AddDistributedSqlServerCache(config =>
            {
                config.TableName = "tbl_testcache";
                config.SchemaName = "dbo";
                config.ConnectionString = Configuration.GetConnectionString("SqlConnection");
            });
            //services.AddStackExchangeRedisCache(config => {
            //    config.InstanceName = Configuration.GetValue<string>("Redis:InstanceName");
            //    config.Configuration = Configuration.GetValue<string>("Redis:Configuration");
            //});

            services.AddSession(config=> {
                config.Cookie.Name = "MySessionCookie";
                config.Cookie.HttpOnly = true;
                config.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                config.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<DataService>();

            services.AddMvc()
                .AddSessionStateTempDataProvider()
               // .AddCookieTempDataProvider()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.Use(async (context, next)=> {
                if (context.Request.Headers.ContainsKey("x-samplekey"))
                {
                    //Form validation , header checking done here
                    context.Items["IsVerified"] = true;
                    context.Items["Description"] = "Request is verified for Forgery checking.";
                }
                else {
                    context.Items["IsVerified"] = false;
                }
              
                await next.Invoke();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
