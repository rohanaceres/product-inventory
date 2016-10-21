﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models
{
    public class ProductModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
