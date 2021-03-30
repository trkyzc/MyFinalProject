using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>//Productla ilgili veritabanında yapacağım operasyonları içeren interface.
    {
        //IEntityRepository sayesinde alttaki kodlara gerek kalmadı.

        //List<Product> GetAll(); //Hepsini getir(GetAll). Başka bir katmanı kullanıyoz(Entities).Referans eklememiz lazım.DataAccess de sağ tık add referance.Sonra using.Dependenciese ekledi.Bu da DataAccess Entities katmanındaki productı,categoryi vs. ekler siler günceller demek.
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);

        //List<Product> GetAllByCategory(int categoryId); //Ürünleri kategoriye göre filtrele.E ticaret sisteminde kategoriye basınca çalışacak kod.
        //üst kısım için generic yapı kullanacaz.IEntityRepository.
    }
}
