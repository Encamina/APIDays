using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace taller
{
  public class Program
  {
    public static void Main(string[] args)
    {
      BuilderWebHostLog(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();

    public static IWebHost BuilderWebHostLog(string[] args)
    {
      var webHost = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
          var env = hostingContext.HostingEnvironment;
          config.AddJsonFile("appsetings.json", true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);
          config.AddEnvironmentVariables();
 

        })
        .ConfigureLogging((hostingContext,logging)=> {
          Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Verbose()
          .WriteTo.ColoredConsole()
          .CreateLogger();

          logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
          //logging.AddDebug();
          //logging.AddConsole();
          logging.AddSerilog(Log.Logger);
        }).UseStartup<Startup>()
            .Build(); 


      return webHost;

    }
  }
}
