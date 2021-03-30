﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity //Diğer classlardan erişmek için public yazdık başa.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } //Short int'in küçüğü
        public decimal UnitPrice { get; set; }

    }
}
