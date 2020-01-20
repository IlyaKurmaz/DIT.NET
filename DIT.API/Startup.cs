using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DIT.Portal2.Extentions;
using DIT.Domain.Models;
using Microsoft.AspNetCore.Identity;
using DIT.Domain.Context;
using System.Text;
using DIT.API.Services;
using DIT.API.Options;
using Microsoft.IdentityModel.Logging;

namespace DIT.API
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
            services.AddControllers();
            services.AddMvc();

            services.Configure<JWTOptions>(Configuration.GetSection(nameof(JWTOptions)));

            services.AddDataServices(Configuration.GetConnectionString("DitConnectionString"));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DitContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtBearerOptions => {
                    jwtBearerOptions.SaveToken = true;
                    jwtBearerOptions.RequireHttpsMetadata = false;
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTOptions:SigningKey"))),

                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetValue<string>("JWTOptions:Issuer"),

                        ValidateAudience = true,
                        ValidAudience = Configuration.GetValue<string>("JWTOptions:Audience"),

                        ValidateLifetime = true,
                        
                        ClockSkew = TimeSpan.FromSeconds(5)
                    };
                })
                .AddCookie(); 

            services.AddScoped<IJWTAuthService, JWTAuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            SeedDB.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
