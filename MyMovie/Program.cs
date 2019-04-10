using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)=>
            //默认设置   Kestrel Web Server  
            //IIS集成  useIIS() useIISIntegration
            //Log
            //IConfiguration
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
            
    }
}
