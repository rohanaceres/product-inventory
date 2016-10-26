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
        public MainWindow MainWindow { get; set; }
        public List<ProductModel> Products { get; set; }

        public InventoryController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public long GetAmountItemInInventory(InventoryModel item)
        {
            return inventoryDao.GetAmountItem(item);
        }
        
        public bool CheckAmountInInventory(InventoryModel item, SalesModel products)
        {
            InventoryModel itemInCart = this.GetItemSelectedInCart(item, products);
            
            if (itemInCart == null && this.GetAmountItemInInventory(item) >= item.Amount)
                return true;
            else
            {
                if (itemInCart == null && this.GetAmountItemInInventory(item) <= item.Amount)
                    return false;
                else if(this.GetAmountItemInInventory(item) >= item.Amount + itemInCart.Amount)
                    return true;
                return false;
            }
            
        }
        // Get Item Selected and find it in cart
        private InventoryModel GetItemSelectedInCart (InventoryModel item,SalesModel products)
        {
            foreach (InventoryModel itemInInventory in products.Items)
                if (itemInInventory.Product.Name.Equals(item.Product.Name))
                    return itemInInventory;
            return null;
        }
        
        public void UpdateQuantityOfAProduct(ProductModel product)
        {
            //inventoryDao.Update((ProductModel)product);
        }

    }
}
