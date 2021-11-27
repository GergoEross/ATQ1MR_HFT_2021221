﻿using Microsoft.EntityFrameworkCore;
using ATQ1MR_HFT_2021221.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Data
{
    public class PcPartsDbContext : DbContext
    {
        public virtual DbSet<MBrand> MBrands { get; set; }
        public virtual DbSet<PBrand> PBrands { get; set; }
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public PcPartsDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PcPartsDb.mdf;Integrated Security=true;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motherboard>(e => e.HasOne(c => c.Brand).WithMany(b => b.Motherboards).HasForeignKey(c => c.BrandId).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Processor>(e => e.HasOne(c => c.Brand).WithMany(b => b.Processors).HasForeignKey(c => c.BrandId).OnDelete(DeleteBehavior.ClientSetNull));

            //Seed
            var msi = new MBrand() { Id = 1, Name = "MSI" };
            var asus = new MBrand() { Id = 2, Name = "Asus" };
            var intel = new PBrand() { Id = 1, Name = "Intel" };
            var amd = new PBrand() { Id = 2, Name = "AMD" };

            var mboard1 = new Motherboard() { Id = 1, BrandId = msi.Id, Chipset = "B450", Price = 30000, Socket = "AM4", Type = "TOMAHAWK MAX" };
            var mboard2 = new Motherboard() { Id = 2, BrandId = asus.Id, Chipset = "Z390", Price = 40000, Socket = "LGA-1151(300)", Type = "MPG GAMING PLUS" };
            var cpu1 = new Processor() { Id = 1, BrandId = amd.Id, Name = "Ryzen 5 3600", Socket = "AM4", Cores = 6, Threads = 12, BaseClock = 3.6, BoostClock = 4.2, Price = 110000 };
            var cpu2 = new Processor() { Id = 2, BrandId = intel.Id, Name = "Core i9-9900K", Socket = "LGA-1151(300)", Cores = 8, Threads = 16, BaseClock = 3.6, BoostClock = 5, Price = 134000 };

            modelBuilder.Entity<MBrand>().HasData(msi, asus);
            modelBuilder.Entity<PBrand>().HasData(intel, amd);
            modelBuilder.Entity<Motherboard>().HasData(mboard1, mboard2);
            modelBuilder.Entity<Processor>().HasData(cpu1, cpu2);
        }
    }
}
