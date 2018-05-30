using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace CityInfo.API
{
    public class Startup
    {

		public static IConfiguration Configuration { get; private set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
			//.AddJsonOptions(o => {
			//    if (o.SerializerSettings.ContractResolver != null)
			//    {
			//        var castedResolver = o.SerializerSettings.ContractResolver
			//            as DefaultContractResolver;
			//        castedResolver.NamingStrategy = null;
			//    }
			//});

			// Register our services with the container so we can inject them using the built in dependency injection system
			// transient: created each time requested, best for lightweight, stateless services
			// scoped: created once per request
			// singleton: created first time requested only. Future requests will use the same instance 

			// shows how we can switch service providers
#if DEBUG

			services.AddTransient<IMailService, LocalMailService>(); // saying which IMailService to inject - makes it easy to switch
#else
			services.AddTransient<IMailService, CloudMailService>();
#endif
			// You can see your local sql server in SQL Server Object Explorer un View in VS
			var connectionString = @"Server=(localdb)\mssqllocaldb;Database=CityInfoDB;Trusted_Connection=True;";
			services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));


		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			// No need to add these loggers in ASP.NET Core 2.0: the call to WebHost.CreateDefaultBuilder(args) 
			// in the Program class takes care of that.

			//loggerFactory.AddConsole();

			loggerFactory.AddDebug();

			// Genericly add a provider 
			// loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
			loggerFactory.AddNLog();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();

            //app.Run((context) =>
            //{
            //    throw new Exception("Example exception");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
