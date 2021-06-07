using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak için yaparız
   public class NorthwindContext:DbContext //DbContext den türeticez bunu
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Projemin hangi veri tabanıyla ilişkili olduğunu belirrtiğimiz yer(Override yazıp boşluk bırakınca gelir)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");//visual studio-view-sql server object explorer altındaki northwind databaseinin yolunu verdik
        }
        public DbSet<Product> Products { get; set; } //Benim Product nesnemi veritabanındaki Products ile bağla demek buda.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
