using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using SametKabay.Application;
using SametKabay.Application.UserServices;
using SametKabay.Core;
using SametKabay.Core.Models;
using Serilog;
using Newtonsoft.Json;
using SametKabay.Application.BlogCategoryService;
using SametKabay.Application.BlogPostServices;
using SametKabay.Core.Repositories;
using SametKabay.Core.Repositories.BlogCategory;
using SametKabay.Core.Repositories.BlogPost;
using SametKabay.Core.Repositories.User;

namespace SametKabayApi
{
    /// <summary>
    /// Startup.cs
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  ConfigurationServices
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var xmlPath = GetXmlCommentsPath();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "SametKabayAPI", Version = "v1" });
                options.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])
                            )
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireClaim("Admin"));
            });
            services.AddHangfire(config =>
                config.UseSqlServerStorage(Configuration.GetConnectionString("SametDbConnectionString")));

            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            services.AddAutoMapper();
            services.AddDbContext<SametKabayDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("SametDbConnectionString")
                    )
                );

            services.AddTransient<IBlogPostAppService, BlogPostAppService>();
            services.AddTransient<IUserAppServices, UserAppServices>();
            services.AddTransient<IBlogCategoryAppService, BlogCategoryAppService>();

            services.AddTransient(typeof(UserRepository));
            services.AddTransient(typeof(IBlogPostRepository), typeof(BlogPostRepository));
            services.AddTransient(typeof(IBlogCategoryRepository), typeof(BlogCategoryRepository));

            //UserRepository<User>
            services.AddTransient(typeof(IRepository<User>), typeof(UserRepository));
            services.AddTransient<IMapper, Mapper>();
            services.AddSingleton<Serilog.ILogger>(x => new LoggerConfiguration()
                .WriteTo.MSSqlServer(Configuration["Serilog:ConnectionString"],
                    Configuration["Serilog:TableName"],
                    autoCreateSqlTable: true)
                .CreateLogger());
        }

        private string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, "SametKabayApi.xml");
        }

        /// <summary>
        /// Configure
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SametKabayAPI");
            });
            app.UseAuthentication();

            app.UseHangfireDashboard();
            app.UseHangfireServer();
            app.UseMvc();
        }
    }
}
