using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic conctraint=generic kısıt.t yi sınırlıyoruz.
    //class:class olabilir demek değil referans tip olabilir demek.T bir referans tip olmalıdır ve T ya IEntity olabilir ya da Ientityden implemente olan bişey olabilir.
    //new()=newlenebilir birşey olsun.Bu da IEntity yi devre dışı bıraktı.Yani şuan veri tabanı nesneleri ile çalışabiliyoruz.
    public interface IEntityRepository<T> where T:class,IEntity,new() //Generic Yapı.T diyoruz bana çalışacağım tipi söyle.Productsa product category ise category.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //Bu yapıyla kategoriye göre getir fiyata göre getir vs. için ayrı ayrı metodlara gerek kalmayacak.LINQ ile geliyor bu yapı.filter=null filtre vermeyedebilirsin demek.Bu yapı bizim (p=>p.CategoryId==2) gibi filtreler yazabilmemizi sağlıyor.
        T Get(Expression<Func<T, bool>> filter); //Tek bir data getirmek için.Bir sistemde bir şeyin detayına gitmek.Bankacılık sistde hesap listesinden bi hesabın deteyına gitmek.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        

    }
}
