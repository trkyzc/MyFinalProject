using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {

        public void Add(Product entity)
        {
            //NorthwindContext context = new NorthwindContext() //Bu şekilde de yapılabilir ama alttaki daha performanslı.
            //IDisposable pattern implementation of c#
            using (NorthwindContext context=new NorthwindContext()) //using'in içine yazdığımız nesneler using bitince anında GarbageCollectore beni bellekten at diyor atılıyor.Çünkü context nesnesi biraz pahalı.
            {
                var addedEntity = context.Entry(entity); //Git veri kaynağından benim gönderdiğim producta bir tane nesneyi eşleştir.Ama bu yeni ekleme olduğu için herhangi bir şeyle eşleştirmryecek direk ekleyecek.Burası referansı yakalama.
                addedEntity.State = EntityState.Added; //O aslında eklenecek bir nesne
                context.SaveChanges(); // Ve şimdi ekle.

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //using'in içine yazdığımız nesneler using bitince anında GarbageCollectore beni bellekten at diyor atılıyor.Çünkü context nesnesi biraz pahalı.
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges(); 

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList(); //ternary operatör kullandık.Db setteki Producta yerleş.Yani ben product tablosuyla çalışacağım demek.Veri tabanındaki bütün tabloyu listeye çevir ver.Arka planda Select * from Products çalıştırıyor.
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //using'in içine yazdığımız nesneler using bitince anında GarbageCollectore beni bellekten at diyor atılıyor.Çünkü context nesnesi biraz pahalı.
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
