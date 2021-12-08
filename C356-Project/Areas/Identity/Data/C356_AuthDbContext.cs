using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C356_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace C356_Project.Areas.Identity.Data
{
    public class C356_AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public C356_AuthDbContext(DbContextOptions<C356_AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntry> TaskEntry { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<TaskEntry>().ToTable("Tasks");
        }
    }
}
