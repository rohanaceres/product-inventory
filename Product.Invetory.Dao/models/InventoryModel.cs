using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models
{
    public class InventoryModel
    {
        public List<ProductModel> Products { get; set; }
        public int Amount { get; set; }
    }
}
