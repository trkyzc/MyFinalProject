using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService//İş katmanında kullanacağımız servis operatörleri.
    {
        List<Product> GetAll(); //DataAccess ve Entity referansını ekledik.
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
