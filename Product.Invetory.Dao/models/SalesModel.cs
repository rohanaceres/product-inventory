using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models
{
    public class SalesModel
    {
        public int Id { get; set; }

        public ProductModel product { get; set; }

        public int Amount { get; set; }
    }
}
