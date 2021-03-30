using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext //EntityFrameworkle beraber böyle bir base sınıf geliyor Dbcontext bizim contextimizin ta kendisi.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //override boşluk on yazıp tamamla.Bu metod senin projen hangi veri tabanı ile ilişkiliği belirttiğin yer.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //Verdiğim serverda databaselerdan ismi northwind olana bağlan.
        }

        public DbSet<Product> Products { get; set; } //Veri tabanımın ne olduğunu söyledim.Ama benim hangi nesnem(class) hangi nesneye(tablo) karşılık gelecek.Benim Product nesnemi veri tabanındaki Products ile bağla.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
