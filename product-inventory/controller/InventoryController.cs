using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Inventory.Dao.models.dao;
using Product.Inventory.Dao.models;

namespace product_inventory.controller
{
   public  class InventoryController
    {
        InventoryDao inventoryDao = new InventoryDao();

        public List<ProductModel> Products { get; set; }

        public long GetAmountProduct(ProductModel product)
        {
            return inventoryDao.GetAmountProduct(product);
        }

        public bool CheckAmount(ProductModel product, long amount)
        {
            if (this.GetAmountProduct(product) > amount)
                return true;
            return false;
        }

    }
}
