using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WPFW_week13.Areas.Identity.Data;
using WPFW_week13.Data;

[assembly: HostingStartup(typeof(WPFW_week13.Areas.Identity.IdentityHostingStartup))]
namespace WPFW_week13.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WPFW_week13Context>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("WPFW_week13ContextConnection")));

                services.AddDefaultIdentity<WPFW_week13User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WPFW_week13Context>();
            });
        }
    }
}