using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System.Linq;

namespace API
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
            services.AddApplication();
            services.AddPersistence();
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            UpdateDatabase(app);
            SeedDatabase(app);

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<RecipeBookContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        private static void SeedDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<RecipeBookContext>())
                {

                    context.Database.EnsureCreated();

                    if (context.Recipes.Count() == 0)
                    {
                        context.Recipes.Add(new Recipe { Name = "Aloo Chaat" });
                        context.Recipes.Add(new Recipe { Name = "Biryani" });
                        context.Recipes.Add(new Recipe { Name = "Braided Salmon" });
                        context.Recipes.Add(new Recipe { Name = "Buffalo Dip" });
                        context.Recipes.Add(new Recipe { Name = "Chicken Alfredo" });
                        context.Recipes.Add(new Recipe { Name = "Chicken Fried Rice" });
                        context.Recipes.Add(new Recipe { Name = "Flat Bread" });
                        context.Recipes.Add(new Recipe { Name = "Fried Rice" });
                        context.Recipes.Add(new Recipe { Name = "Ground Turkey" });
                        context.Recipes.Add(new Recipe { Name = "Hawaiian Rolls" });
                        context.Recipes.Add(new Recipe { Name = "Homemade Pasta Sauce" });
                        context.Recipes.Add(new Recipe { Name = "Impossible Burger" });
                        context.Recipes.Add(new Recipe { Name = "Jerk Chicken" });
                        context.Recipes.Add(new Recipe { Name = "Keto Soup" });
                        context.Recipes.Add(new Recipe { Name = "Macadamia Fish" });
                        context.Recipes.Add(new Recipe { Name = "Mashed Potatoes" });
                        context.Recipes.Add(new Recipe { Name = "Morning Star Salad" });
                        context.Recipes.Add(new Recipe { Name = "Nihari" });
                        context.Recipes.Add(new Recipe { Name = "Orzo" });
                        context.Recipes.Add(new Recipe { Name = "Pani Puri" });
                        context.Recipes.Add(new Recipe { Name = "Rice & Beans" });
                        context.Recipes.Add(new Recipe { Name = "Shrimp Fried Rice" });
                        context.Recipes.Add(new Recipe { Name = "Sukhi's Chicken Tika Masala" });
                        context.Recipes.Add(new Recipe { Name = "Tandoori Wings" });
                        context.Recipes.Add(new Recipe { Name = "Trader Joe's Clam Chowder" });
                        context.Recipes.Add(new Recipe { Name = "Trader Joe's Fiery Chicken" });
                        context.Recipes.Add(new Recipe { Name = "Trader Joe's Palak Paneer" });
                        context.Recipes.Add(new Recipe { Name = "Tuna Salad" });
                        context.Recipes.Add(new Recipe { Name = "Tuscan Chicken" });
                        context.Recipes.Add(new Recipe { Name = "Tyson Chicken Burger" });
                        context.Recipes.Add(new Recipe { Name = "Vietnamese Summer Rolls" });
                    }

                    if (context.WeeklyMenuItems.Count() == 0)
                    {
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Monday", Position = 1 });
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Tuesday", Position = 2 });
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Wednesday", Position = 3 });
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Thursday", Position = 4 });
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Friday", Position = 5 });
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Saturday", Position = 6 });
                        context.WeeklyMenuItems.Add(new WeeklyMenuItem { Day = "Sunday", Position = 7 });
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
