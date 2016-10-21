using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;


namespace product_inventory.controller
{
    public class InventoryController
    {
        InventoryDao inventoryDao = new InventoryDao();

        public bool checkInStock(ProductModel product, long amountRequest)
        {
            long amountStock = inventoryDao.GetQuantity(product);

            if (amountStock >= amountRequest)
                return true;
            return false;
        }



    }
}
