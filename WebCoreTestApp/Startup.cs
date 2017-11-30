using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebCoreTestApp.Data;
using WebCoreTestApp.Data.Entities;
using WebCoreTestApp.Services;

namespace WebCoreTestApp
{
    public class Startup
    {
        private IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<WebCoreContext>();

            services.AddDbContext<WebCoreContext>(cfg => 
            {
                cfg.UseSqlServer(_config.GetConnectionString("WebCoreConnectionString"));
            });
            services.AddAutoMapper();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<WebCoreSeeder>();
            services.AddScoped<IWebCoreRepository, WebCoreRepository>();
            services.AddMvc(opt => 
            {
                if (_env.IsProduction() && _config["DisableSSL"] != "true")
                {
                    opt.Filters.Add(new RequireHttpsAttribute());
                }
            }).AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes => 
            {
                routes.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index"});
            });

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<WebCoreSeeder>();

                    seeder.Seed().Wait();
                }
            }
        }
    }
}
