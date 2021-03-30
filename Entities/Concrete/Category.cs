using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın
    public class Category:IEntity //İşaretleme.Bunu görürsek anlıyoruz ki Category bir veri tabanı tablosu.İşaretlemenin bize avantajı IEntity Category'nin referansını tutabiliyor.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
