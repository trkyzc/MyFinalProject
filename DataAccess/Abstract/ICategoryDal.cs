﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>//Alttaki kodlara gerek kalmadı.
    {
        //List<Category> GetAll(); 
        //void Add(Category category);
        //void Update(Category category);
        //void Delete(Category category);

        //List<Product> GetAllByCategory(int categoryId);
    }
}
