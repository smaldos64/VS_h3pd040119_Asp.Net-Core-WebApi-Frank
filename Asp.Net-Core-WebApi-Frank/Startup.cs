using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Asp.Net_Core_WebApi_Frank.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_WebApi_Frank
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
            // LTPE : Metode 1 at få gang i Databasen på. Ikke så fleksibel som metode 2 vist herunder.
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=Asp.Net.Core.WebApi_1;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<DatabaseContext> 
            //    (options => options.UseSqlServer(connection));

            // LTPE Added below
            // Metode 2 at få gang i Databasen på. ConnectionString er oprettet i filen : appsettings.json.
            // I tilfældet her er Connectionstring taget fra Contoso University projektet og modificeret, 
            // så den passer til projektet her.
            services.AddDbContext<DatabaseContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Asp.Net.Core.WebApi_1")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
