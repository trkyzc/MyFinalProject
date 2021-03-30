using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //Bellek üzerinde ürünle ilgili veri erişim kodlarının yazılacağı yer.
    {
        List<Product> _products; //Class içinde metodların dışında tanımladık nesneyi.Global değişken oldu class için. _ ile veririz genelde.Sadece değişkeni oluşturduk.Veri tabanı olarak bunu kullanıyoruz burada.
        public InMemoryProductDal() //Proje çalıştığında bellekte ürün oluşturdu.Yani sanki bu bize Oracle,Sql Server,Postgres,MongoDb den geliyormuş gibi simule ediyoruz.
        {
            _products = new List<Product> { 
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)//Arayüzden (Businessdan) bana gönderilen ürünü alıp veritabanına ekliyorum gibi.Burada veri tabanı liste.
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product);//Bu şekilde silemeyiz çalışmaz.Referans tip bu şekilde silinmez.Bellekte oluşturduğumuz productlarla aynı referansa sahip olmadığı için bu şekilde silemeyiz.Arayüzden gönderdiğimiz product'ın biligileri aynı olsa da referansı farklı oluyor.Bizim silinecek nesnenin referansını almamız lazım.
            //Delete de verilen product'ın Id sini kullanarak veritabanında(yukarıda oluşturduğumuz liste) eşleşen Id yi bulup o referansı yakalayacaz.Burada karşımıza LINQ dedğimiz bir sistem çıkıyor.
            //Product productToDelete = null; //Referansı yok anlamında null verdik.
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;//Kendim bir product oluşturup referansı ona atıyorum.
            //    }
            //}

            //_products.Remove(productToDelete); //Bu şekilde silebildik.

            //LINQ - Language Integreted Query Dile gömülü sorgulama.LINQ ile bu liste bazlı yapıları aynen Sql gibi filtreleyebiliyoruz.Üstteki foreach kodunu LINQ ile yazalım.

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //SingleOrDefault tek bir eleman bulmaya yarar.Bu bizim yerimize productsı tek tek dolaşmaya yarar.p=> lambda.Tek tek dolaşırken verdiğimiz takma isim.Yani bu kod  foreach'yapıyor.Her p için o an dolaştığım ürünün Id si benim gönderdiğim ürünün Id sine eşitse onun referansını productToDelete eşitle.
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() //Veri tabanındaki datayı Business'e vermem lazım.
        {
            return _products; //Veri tabanını olduğu gibi döndürüyorum.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId==categoryId).ToList();//Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirip onu döndürür.Sql de de aynı şekilde tablo yapıyordu.Bu kod bize array dönderiyor.ToList() diyerek listeye dönüştürüyoruz.
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            //Burada mantığı anlıyoruz.Bunları bizim yerimize EntityFramework vs. yapıyor.
        }
    }
}
