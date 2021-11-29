using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Data
{
    public class AppleDbContext: DbContext
    {
        public virtual DbSet<AppleService> AppleServices { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<AppleProduct> AppleProducts { get; set; }
        public AppleDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            if (!builder.IsConfigured)
            {
                string connection= @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Database1.mdf; Integrated Security = True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<AppleProduct>(entity =>
            {
                entity
                    .HasOne(appleProduct => appleProduct.Customer)
                    .WithMany(customer => customer.Products)
                    .HasForeignKey(appleProduct => appleProduct.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .HasOne(customer => customer.AppleService)
                    .WithMany(appleService => appleService.Customers)
                    .HasForeignKey(customer => customer.ServiceID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<AppleProduct>(entity =>
            {
                entity
                    .HasOne(appleProduct=>appleProduct.AppleService)
                    .WithMany(appleService => appleService.Products)
                    .HasForeignKey(appleProduct => appleProduct.ServiceID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            AppleService a1 = new AppleService() { ServiceID = 1, ServiceName = "A1", Location = "Budapest"};
            AppleService a2 = new AppleService() { ServiceID = 2, ServiceName = "A2", Location = "Érd" };

            Customer Bela = new Customer() { CustomerID = 1, Name = "Bela Bela", Email = "bela@gmail.com", ServiceID=1  };
            Customer Sanyi = new Customer() { CustomerID = 3, Name = "Sanyi Sanyi", Email = "Sanyi@gmail.com", ServiceID=1 };
            Customer Lajos = new Customer() { CustomerID = 5, Name = "Lajos Lajos", Email = "Lajos@gmail.com", ServiceID=2 };

            AppleProduct mac1 = new AppleProduct() { Serial = 1, Color = "Black", Type = Models.Type.Mac, ServiceID=1, CustomerID=1 };
            AppleProduct iphone1 = new AppleProduct() { Serial = 2, Color = "Red", Type = Models.Type.iPhone, ServiceID=1, CustomerID = 1 };
            AppleProduct watch1 = new AppleProduct() { Serial = 3, Color = "Green", Type = Models.Type.AppleWatch, ServiceID = 1, CustomerID = 3 };
            AppleProduct mac2 = new AppleProduct() { Serial = 4, Color = "Black", Type = Models.Type.Mac, ServiceID = 1, CustomerID = 3 };
            AppleProduct ipad1 = new AppleProduct() { Serial = 5, Color = "Yellow", Type = Models.Type.iPad, ServiceID = 2, CustomerID = 5 };
            AppleProduct iphone2 = new AppleProduct() { Serial = 6, Color = "Blue", Type = Models.Type.iPhone, ServiceID = 2, CustomerID = 5 };

            modelBuilder.Entity<AppleService>().HasData(a1, a2);
            modelBuilder.Entity<Customer>().HasData(Bela, Sanyi, Lajos);
            modelBuilder.Entity<AppleProduct>().HasData(mac1, mac2, iphone1, iphone2, ipad1, watch1);
        }
    }
}
