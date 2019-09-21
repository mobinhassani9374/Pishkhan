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

        public virtual ICollection<UserPhoneNumber> PhoneNumbers { get; set; }
    }

    public class UserPhoneNumber
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public virtual AppIdentityUser User { get; set; }

        public string UserId { get; set; }

        public bool IsConfirm { get; set; }
    }

    public class AppIdentityDbContext
      : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppIdentityUser>().ToTable("Users","dbo");
            builder.Entity<AppIdentityRole>().ToTable("Roles","dbo");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims","dbo");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins","dbo");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles","dbo");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens","dbo");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims","dbo");

            //user
            var user = builder.Entity<AppIdentityUser>();

            user.Property(c => c.NationalCode).HasMaxLength(256);
            user.HasIndex(c => c.NationalCode).IsUnique(true);

            //userPhoneNumbers
            var userPhoneNumber = builder.Entity<UserPhoneNumber>();

            userPhoneNumber.Property(c => c.PhoneNumber).HasMaxLength(265).IsRequired(true);
            userPhoneNumber.HasIndex(c => c.PhoneNumber).IsUnique(true);

            userPhoneNumber.Property(c => c.UserId).HasMaxLength(450);

            userPhoneNumber
                .HasOne(c => c.User)
                .WithMany(c => c.PhoneNumbers)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
