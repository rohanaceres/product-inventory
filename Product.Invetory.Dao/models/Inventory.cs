﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models
{
    public class Inventory
    {
        public List<Product> Products { get; set; }
        public int Amount { get; set; }
    }
}
