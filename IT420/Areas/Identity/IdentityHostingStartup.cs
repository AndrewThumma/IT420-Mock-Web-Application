using System;
using IT420.Core;
using IT420.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IT420.Areas.Identity.IdentityHostingStartup))]
namespace IT420.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IT420IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IT420IdentityContextConnection")));

                services.AddDefaultIdentity<UserProfile>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<IT420IdentityContext>();

                services.AddScoped<IUserClaimsPrincipalFactory<UserProfile>, ApplicationUserClaimsPrincipalFactory>();
            });
        }
    }
}