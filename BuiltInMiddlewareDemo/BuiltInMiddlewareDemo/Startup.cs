using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using BuiltInMiddlewareDemo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace BuiltInMiddlewareDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton<IDataManager, NoSqlDataManager>();
        //    //services.AddScoped<IDataManager, SqlDataManager>();
        //    //services.AddTransient<IDataManager, SqlDataManager>();

        //    services.AddSingleton<IConfiguration>(Configuration);

        //    services.Configure<CookiePolicyOptions>(options =>
        //   {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => true;
        //       options.MinimumSameSitePolicy = SameSiteMode.None;

        //   });


        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //}


        public IServiceProvider ConfigurationServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = "Production";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseExceptionHandler(appBuilder => {
                //    appBuilder.Run(async (httpContext) => {
                //          httpContext.Response.Headers.Add("Content-Type","text/html");
                //        await httpContext.Response.WriteAsync("<h2>Error Occured</h2>");
                //        await httpContext.Response.WriteAsync("<p>Internal Server Error -  500</p>");
                //    });
                //});
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("hello.html");
            //app.UseDefaultFiles(options);

            //  var fileOptions = new DefaultFilesOptions();
            // fileOptions.DefaultFileNames.Clear();
            //  fileOptions.DefaultFileNames.Add("index.html");
            //fileOptions.RequestPath = "/files";
            //fileOptions.FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files"));
            //app.UseDefaultFiles(fileOptions);

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    RequestPath= "/files",
            //    FileProvider= new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"files")),

            //});

            app.UseFileServer(new FileServerOptions() {
                RequestPath="/files",
              //  EnableDefaultFiles = true,
                EnableDirectoryBrowsing =true,
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files")),
            });

            app.UseStaticFiles();
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    RequestPath = "/files",
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files")),
            //});

            app.UseCookiePolicy();

            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    //routes.MapRoute(
            //    //    name:"ProductRoute",
            //    //    template:"admin/Products/{action=Index}/{id?}"
            //    //    );

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
