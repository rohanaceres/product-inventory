using Product.Inventory.Dao.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.UI.ViewModel
{
    public class ItemViewModel
    {
        public ProductModel product { get; set; }
        public long Amount { get; set; }
    }
}
