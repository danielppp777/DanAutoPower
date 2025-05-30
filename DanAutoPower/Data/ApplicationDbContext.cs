﻿using DanAutoPower.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanAutoPower.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<TestDrive> TestDrives { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ApplicationUser>()
        //        .Property(u => u.Role)
        //        .HasMaxLength(256); // Optional: Set a max length
                                    
        //    //    modelBuilder.Entity<Car>()                                  
        //    //        .Property(c => c.Price)
        //    //        .HasPrecision(18, 2);

        //    //    modelBuilder.Entity<Car>()
        //    //        .HasOne(c => c.User)
        //    //        .WithMany()
        //    //        .HasForeignKey(c => c.UserId)
        //    //        .OnDelete(DeleteBehavior.Cascade);
        //    //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }
}