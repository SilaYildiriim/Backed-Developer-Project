using Autofac.Extensions.DependencyInjection;
using Autofac;
using Backed_Developer_Project.Application.IoC;
using Backed_Developer_Project.Application.Services.FormFieldServices;
using Backed_Developer_Project.Application.Services.FormServices;
using Backed_Developer_Project.Application.Services.UserService;
using Backed_Developer_Project.Domain.Entities;
using Backed_Developer_Project.Domain.Repositories;
using Backed_Developer_Project.InfraStructure.Context;
using Backed_Developer_Project.InfraStructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;

namespace Backed_Developer_Project.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddIdentity<User, IdentityRole>(o =>
            {
                o.SignIn.RequireConfirmedEmail = false;
                o.SignIn.RequireConfirmedPhoneNumber = false;
                o.SignIn.RequireConfirmedAccount = false;

                o.User.RequireUniqueEmail = true;


                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 3;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new DependencyResolver());
            });
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<IFormService, FormService>();
            builder.Services.AddTransient<IFormRepo, FormRepo>();
                        builder.Services.AddTransient<IFormFieldService, FormFieldService>();
            builder.Services.AddTransient<IFormFieldRepo, FormFieldRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}