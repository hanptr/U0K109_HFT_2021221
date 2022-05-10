using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using U0K109_HFT_2021221.Data;
using U0K109_HFT_2021221.Endpoint.Services;
using U0K109_HFT_2021221.Logic;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IAppleServiceLogic, AppleServiceLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<IAppleProductLogic, AppleProductLogic>();
            services.AddTransient<IAppleServiceRepository, AppleServiceRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAppleProductRepository, AppleProductRepository>();
            services.AddTransient<AppleDbContext, AppleDbContext>();


            services.AddSignalR();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:21980/"));
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });

        }
    }
}
