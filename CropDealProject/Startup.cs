using CropDealProject.Models;
using CropDealProject.Repository;
using CropDealProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDealProject
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CropDealProject", Version = "v1" });
            });
            services.AddDbContext<CropDealDataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CropDealProject")));
            services.AddScoped<IUserRepository<UserProfile>, UserProfileRepository>();
            services.AddScoped<UserProfileService, UserProfileService>();
            services.AddScoped<IRepository<Crop>, CropRepository>();
            services.AddScoped<CropService, CropService>();
            services.AddScoped<IInvoiceRepository<Invoice>, InvoiceRepository>();
            services.AddScoped<InvoiceService, InvoiceService>();
            services.AddScoped<ICropOnSale, CropOnSaleRepository>();
            services.AddScoped<CropOnSaleService, CropOnSaleService>();
            services.AddScoped<IViewCropRepository, ViewCropRepository>();
            services.AddScoped<CropViewService, CropViewService>();
            services.AddScoped<IUserIdRepository<int>, UserIdRepository>();
            services.AddScoped<UserIdService, UserIdService>();
            services.AddCors(option =>
            {
                option.AddPolicy("corspolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //        //.AddEntityFrameworkStores<CropDealDatabaseContext>()
            //        .AddDefaultTokenProviders();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
               // var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]);
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = Configuration["JWT:Audience"],
                    ValidIssuer = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CropDealProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("corspolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.Run();
        }
    
    }
}
