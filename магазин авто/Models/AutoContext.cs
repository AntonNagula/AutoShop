using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using магазин_авто.Configurations;

namespace магазин_авто.Models
{
    public class AutoContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<BuyCar> BuyCars { get; set; }
        public AutoContext(DbContextOptions<AutoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public AutoContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigManyToMany());
            modelBuilder.ApplyConfiguration(new ConfigBuyer());
            

            Buyer b1 = new Buyer() { Id = 1, Email = "nagula.anton@mail.ru", Password = "1234" };
            Buyer b2 = new Buyer() { Id = 2, Email = "Banderos99@tut.by", Password = "5678" };

            Car car1 = new Car() { Id = 1, Name = "BMW X5", CarBrand = "BMW", Price = 75000, Count_Of_Unit=200, ExtencionName="BMW X5.jpg" };
            Car car2 = new Car() { Id = 2, Name = "BMW i8", CarBrand = "BMW", Price = 154000 , Count_Of_Unit=200, ExtencionName="BMW i8.jpg"};
            Car car3 = new Car() { Id = 3, Name = "BMW X2", CarBrand = "BMW", Price = 40000, Count_Of_Unit=200, ExtencionName="BMW X2.jpg"};
            Car car4 = new Car() { Id = 4, Name = "BMW 8 серия", CarBrand = "BMW", Price = 100000,Count_Of_Unit=200, ExtencionName= "BMW 8 серия.jpg "}; 


            modelBuilder.Entity<Buyer>().HasData(
            new Buyer[]
            {
                b1,b2         
            });

            modelBuilder.Entity<Car>().HasData(
            new Car[]
            {
                car1,car2,car3,car4
            });

            modelBuilder.Entity<BuyCar>().HasData(
            new BuyCar[]
            {
                new BuyCar() { BuyerId=b2.Id, CarId=car1.Id},
                new BuyCar() { BuyerId=b2.Id, CarId=car2.Id},
                new BuyCar() { BuyerId=b1.Id, CarId=car3.Id},
                new BuyCar() { BuyerId=b2.Id, CarId=car4.Id}
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AutoContext;Trusted_Connection=True;");
        }
    }
}