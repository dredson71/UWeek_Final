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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository;
using Repository.Context;
using Repository.Implementation;
using Service;
using Service.Implementation;

namespace uweek_app_web
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

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IAllergyRepository, AllergyRepository>();
             services.AddTransient<IAllergyService, AllergyService>();
            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddTransient<IPlanService, PlanService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IIngredientService, IngredientService>();
             services.AddTransient<IOrderRepository, OrderRepository>();
             services.AddTransient<IOrderService, OrderService>();
              services.AddTransient<ISuscriptionRepository, SuscriptionRepository>();
              services.AddTransient<ISuscriptionService, SuscriptionService>();

            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IDishService, DishService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
       
            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });
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
             app.UseCors("Todos");
            app.UseMvc();
        }
    }
}
