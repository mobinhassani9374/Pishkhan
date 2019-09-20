using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Data
{
    public class AppIdentityRole : IdentityRole
    { }

    public class AppIdentityUser : IdentityUser
    {
        public string NationalCode { get; set; }
    }

    public class AppIdentityDbContext
      : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //user
            var user = builder.Entity<AppIdentityUser>();

            user.Property(c => c.NationalCode).HasMaxLength(256);
            user.HasIndex(c => c.NationalCode).IsUnique(true);
            
        }
    }
}
