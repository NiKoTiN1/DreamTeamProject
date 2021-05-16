using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Repositories;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DreamTeamProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
                });

            services.AddTransient<IBaseReposetory, BaseReposetory>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountReposetory, AccountReposetory>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookReposetory, BookReposetory>();
            services.AddTransient<IOrderReposetory, OrderReposetory>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Dashobard}");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
