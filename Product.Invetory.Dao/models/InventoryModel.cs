using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public long Amount { get; set; }
      

        public InventoryModel(ProductModel product, long amount)
        {
            this.Product = product;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return this.Product.Name + " --------------  " + this.Amount;
        }
    }
}
