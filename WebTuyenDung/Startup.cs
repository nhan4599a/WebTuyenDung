using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using WebTuyenDung.Binders.Factories;
using WebTuyenDung.Configurations;
using WebTuyenDung.Constants;
using WebTuyenDung.Conventions;
using WebTuyenDung.Data;
using WebTuyenDung.Handlers;
using WebTuyenDung.JsonConverters;
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
            services.AddControllersWithViews(mvc =>
            {
                mvc.Conventions.Add(new ControllerNameConvention());
                mvc.ModelBinderProviders.Insert(0, new DateOnlyModelBinderProvider());
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new GenderJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new JobTypeJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new UserRoleJsonConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 256 * 1024 * 1024;
            });

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

                options.AddPolicy(AuthorizationConstants.CANDIDATE_ONLY_POLICY, policy =>
                {
                    policy.RequireRole(AuthorizationConstants.CANDIDATE_ROLE);
                });

                options.AddPolicy(AuthorizationConstants.NOT_ADMIN_POLICY, policy =>
                {
                    policy.RequireRole(AuthorizationConstants.CANDIDATE_ROLE, AuthorizationConstants.EMPLOYER_ROLE);
                });

                options.AddPolicy(AuthorizationConstants.EMPLOYER_ONLY_POLICY, policy =>
                {
                    policy.RequireRole(AuthorizationConstants.EMPLOYER_ROLE);
                });
            });

            services.AddSingleton<FileService>();
            services.AddSingleton(Configuration.GetSection("EmailConfig").Get<EmailConfiguration>()!);
            services.AddSingleton<IAuthorizationMiddlewareResultHandler, AppAuthorizationResultHandler>();
            services.AddScoped<PostService>();
            services.AddScoped<EmailService>();
            MappingConfigurations.ConfigMappings();
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
                endpoints.MapAreaControllerRoute(
                    name: "admin_route",
                    areaName: "admin",
                    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "employer_route",
                    areaName: "employer",
                    pattern: "employer/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllers();
            });
        }
    }
}
