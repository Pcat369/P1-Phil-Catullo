using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Transient, Scoped, SIngleton
        //Transient: A new ob ject is created everytime you call.
        //Scoped: New object per request. 
        //Singleton: Shares an instance across the request. Could lead to other requests waiting for container that is needed.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StoreDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));
            //We need to configure DB here and add DBContext as a dependency.
            //Finally, add all other dependencies such as BL, and Repo. 
            //This means that we specify what concrete classes impliment interfaces.
            

            /*
             * When adding scope it needs to go from deepest to shallowest. So the DB is deepest and must be set first. 
             */
            services.AddScoped<IRepo, DBRepo>();
            services.AddScoped<IBL, BL>();
            //^Dependency Injection. Registering the depencendies the conrollers need. 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
