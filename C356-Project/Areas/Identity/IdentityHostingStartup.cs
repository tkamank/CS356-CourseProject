using System;
using C356_Project.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(C356_Project.Areas.Identity.IdentityHostingStartup))]
namespace C356_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                /*  services.AddDbContext<C356_Project.Areas.Identity.Data.C356_AuthDbContext>(options =>
                      options.UseSqlServer(
                          context.Configuration.GetConnectionString("C356_AuthDbContextConnection")));
                */
                /* services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                     .AddEntityFrameworkStores<C356_Project.Areas.Identity.Data.C356_AuthDbContext>(); */
            });
        }
    }
}