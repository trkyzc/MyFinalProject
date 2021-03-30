using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Business da asla Inmemory entityframework yok businessın bildiği tek şey IProductDal bu her şey olabilir.
        //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal(); //Bunu böyle yaparsak senin iş kodlarının tamamı bellekle çalışır.Gerçek veritabanına geçeceğin zaman GetAll gibi binlerce operasyon var bunların hepsini değiştirmen gerek.Kural:Bir iş sınıfı başka sınıfları newlemez.ctor (dependency injection) oluştururuz.  
        IProductDal _productDal; //Soyut nesneyle bağlantı kuracağız.

        public ProductManager(IProductDal productDal) //ProductManager newlendiğinde bana bir tane IProductDal referansı ver.Şuan bu inmemory de olabilir yarın entityframework de olabilir.
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları ifler felan var burada yetkisi var mı vs. buralardan geçerse DataAcess'i çağırıyoruz. veri tabanına ürünleri verebilirsin diyor.

            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
