using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncInn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // The appsettings.json, by default, is our "configurations" for the app
        // Set ourselves up for Dependency Injection
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // enable use controllers within the MVC convention
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            // register with the app, that the database exists and what options to use for it
            services.AddDbContext<AsyncInnDbContext>(options =>
            {
                // install package Microsoft.EntityFramewowrkCore.SqlServer
                // connection string = location where something lives. In our case, it's where our DB lives
                // Connection string contains the location, username, pw of your sql server... with our sql db directly.
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // register my dependency injection services
            services.AddTransient<IHotel, HotelRepo>();
            services.AddTransient<IRoom, RoomRepo>();
            services.AddTransient<IAmenities, AmenitiesRepo>();
            services.AddTransient<IHotelRoom, HotelRoomRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // set default routing for our request within the API application
                // by default, our convention is {site}/[controller]/[action]/[id]
                // id is not required, allowing it to be nullable
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
