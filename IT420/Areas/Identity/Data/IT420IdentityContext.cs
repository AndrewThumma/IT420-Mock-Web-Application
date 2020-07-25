using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT420.Data
{
    public class IT420IdentityContext : IdentityDbContext<UserProfile>
    {
        public IT420IdentityContext(DbContextOptions<IT420IdentityContext> options)
            : base(options)
        {
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
