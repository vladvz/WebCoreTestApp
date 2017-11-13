using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebCoreTestApp.Data;
using WebCoreTestApp.Data.Entities;
using WebCoreTestApp.Services;

namespace WebCoreTestApp
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebCoreContext>(cfg => 
            {
                cfg.UseSqlServer(_config.GetConnectionString("WebCoreConnectionString"));
            });
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<WebCoreSeeder>();
            services.AddScoped<IWebCoreRepository, WebCoreRepository>();
            services.AddMvc()
                    .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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

                    seeder.Seed();
                }
            }
        }
    }
}
