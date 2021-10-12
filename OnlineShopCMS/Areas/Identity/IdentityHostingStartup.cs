using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopCMS.Areas.Identity.Data;
using OnlineShopCMS.Data;

[assembly: HostingStartup(typeof(OnlineShopCMS.Areas.Identity.IdentityHostingStartup))]
namespace OnlineShopCMS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OnlineShopUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OnlineShopUserContextConnection")));

                services.AddRazorPages();

                services.AddDefaultIdentity<OnlineShopUser>(options =>
                {
                    // password validator
                    options.Password.RequiredLength = 4;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                    .AddRoles<IdentityRole>() //角色
                    .AddEntityFrameworkStores<OnlineShopUserContext>();

                
            });
        }
    }
}