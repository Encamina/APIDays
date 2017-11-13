using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using taller.Controllers;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using taller.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using taller.Data;

namespace taller
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           // services.AddDbContext<EFCoreWebDemoContext>();
            //services.AddTransient<DbInitializer>();

                services.AddAuthentication(sharedOptions =>
                    {
                        sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
        .AddAzureAdBearer(options => Configuration.Bind("AzureAd", options));
             services.AddApiVersioning(options =>
    {
       options.ReportApiVersions=true;
        options.AssumeDefaultVersionWhenUnspecified = true;
      var multiVersionReader = new HeaderApiVersionReader("x-version"); 
         options.ApiVersionReader= multiVersionReader;
         options.DefaultApiVersion = new ApiVersion(1, 0);
     });
           services.AddMvc();
           services.AddSingleton<IConfiguration>(Configuration);
                 //      services.AddScoped<IStarWarsService,StarWarsMockService>();
        var container = new ContainerBuilder();
        container.Populate(services);
        container.RegisterModule<taller.Infraestructure.AutofacModules.ServicesModules>();
        return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseMvc(); 
        }
    }
}
