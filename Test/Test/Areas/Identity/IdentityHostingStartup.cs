using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Areas.Identity.Data;
using Test.Data;
using Test.Mail;

[assembly: HostingStartup(typeof(Test.Areas.Identity.IdentityHostingStartup))]
namespace Test.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestDbContextConnection")));

                services.AddDefaultIdentity<TestUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<TestDbContext>();
            });
        }
    }
}