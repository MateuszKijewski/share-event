using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShareEvent.DataAccess;
using ShareEvent.Models.Converters;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Repository;
using ShareEvent.Repository.Interfaces;
using ShareEvent.Services;
using ShareEvent.Services.Interfaces;


namespace ShareEvent.App
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
            services.AddDbContext<ShareEventDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // Converters
            services.AddSingleton<IEventConverter, EventConverter>();
            services.AddSingleton<ITicketTypeConverter, TicketTypeConverter>();
            services.AddSingleton<IReservationConverter, ReservationConverter>();

            // Repositories
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITicketTypeRepository, TicketTypeRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();

            // Services
            services.AddTransient<IEventGuestService, EventGuestService>();
            services.AddTransient<IEventHostService, EventHostService>();


            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Swagger
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShareEvent API",
                    Description = "ASP .NET Core API for creating and sharing various events",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mateusz Kijewski",
                        Email = "mateuszkijewski2307@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT license",
                        Url = new Uri("https://www.mit.edu/~amini/LICENSE.md"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShareEventAPI v1.0");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
