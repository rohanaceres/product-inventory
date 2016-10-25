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

        public List<InventoryModel> Items { get; set; }

        public int Amount { get; set; }

        public SalesModel()
        {
            this.Items = new List<InventoryModel>();
        }
    }
}
