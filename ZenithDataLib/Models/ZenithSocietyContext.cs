using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithSociety.Models;

namespace ZenithDataLib.Models
{
    public class ZenithSocietyContext : DbContext
    {

        public ZenithSocietyContext(): base("ZenithSocietyContext")
        {

        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
 
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        //    modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogin");
        //    modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
        //    modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
        //    modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
        //    modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
        //}
    }
}
