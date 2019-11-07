﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigurationDemo
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
          
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration(config=> {
            //    config.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddXmlFile("mysettings.xml", optional: true)
            //    .AddJsonFile("mysettings.json", optional: true)
            //    .AddInMemoryCollection(configData);
            //})
                .UseStartup<Startup>();
    }
}
