using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SDE_Server.Domain.Entities;
using SDE_Server.Domain.Entities.Auth;
using SDE_Server.Domain.Repositories;
using SDE_Server.Hubs;
using SDE_Server.JWT;

namespace SDE_Server
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(AppSettings.GetSettings().CorsAllowedAccess)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            #region Controller/SignalR
            services.AddControllers();
            services.AddSignalR();
            #endregion

            #region DB 
            services.AddScoped<DbContext, SDEDBContext>();
            services.AddDbContext<SDEDBContext>(option => option.UseSqlServer(AppSettings.GetSettings().DBConnectionString));
            services.AddDbContext<AuthDBContext>(option => option.UseSqlServer(AppSettings.GetSettings().DBConnectionString));
            services
                .AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AuthDBContext>()
                .AddDefaultTokenProviders();
            #endregion

            services.AddScoped<JwtHandler>();

            services.AddTransient<UserRepository>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ServerHub>("/hub");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
