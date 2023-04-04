using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebTuyenDung.Constants;
using WebTuyenDung.Data;
using WebTuyenDung.Handlers;
using WebTuyenDung.Services;

namespace WebTuyenDung
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
            services.AddControllersWithViews();

            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<RecruimentDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        options => Configuration.Bind("CookieSettings", options)
                    );

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConstants.AUTHORIZED_PERSON_POLICY, policy =>
                {
                    policy.RequireRole(AuthorizationConstants.EMPLOYER_ROLE, AuthorizationConstants.ADMIN_ROLE);
                });

                options.AddPolicy(AuthorizationConstants.CANDIDATE_ROLE, policy =>
                {
                    policy.RequireRole(AuthorizationConstants.CANDIDATE_ROLE);
                });
            });

            services.AddSingleton<FileService>();
            services.AddSingleton<IAuthorizationMiddlewareResultHandler, AppAuthorizationResultHandler>();
            services.AddScoped<CreatePostService>();
            services.AddScoped<LocaleService>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
