using System;
using CoreAngCombinedNew.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CoreAngCombinedNew.Areas.Identity.IdentityHostingStartup))]
namespace CoreAngCombinedNew.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CoreAngCombinedNewIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CoreAngCombinedNewIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CoreAngCombinedNewIdentityDbContext>();
            });
        }
    }
}