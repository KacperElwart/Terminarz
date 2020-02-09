using System;
using System.Collections.Generic;
using System.Text;
using Terminarz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Terminarz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Happening> Happenings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Happening>()
                .HasOne(p => p.Address)
                .WithMany(b => b.Happenings)
                .HasForeignKey(p => p.AddressID);
        }

    }
}
