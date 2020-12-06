using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WPFW_week13.Areas.Identity.Data;

namespace WPFW_week13.Data
{
    public class WPFW_week13Context : IdentityDbContext<WPFW_week13User>
    {
        public WPFW_week13Context(DbContextOptions<WPFW_week13Context> options)
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

        public DbSet<WPFW_week13.Models.TestResults> TestResults { get; set; }
    }
}
