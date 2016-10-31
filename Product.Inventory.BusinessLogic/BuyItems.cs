using Product.Inventory.Controller;
using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.BusinessLogic
{
    public class BuyItems
    {
        InventoryController inventoryController;

        SalesController salesController;

        BuyController buyController;

        public BuyItems()
        {
            this.salesController = new SalesController();
            this.buyController = new BuyController();
            this.inventoryController = new InventoryController();
        }
        public void BuyProducts(InventoryModel item)
        {
            InventoryDao inventoryDao = new InventoryDao();
            SalesDao salesDao = new SalesDao();

            bool save = salesDao.save(item);

            this.SubstractsAmountFromInventory(item);

            bool update = inventoryDao.Update(item);

            if (save && update)
            {
                //MessageBox.Show("Successful");
                //this.salesController.ClearCart();
            }

        }
        /// <summary>
        /// This method subtracts the amount of a purchased item by item in inventory
        /// </summary>
        /// <param name="item"> Parameter item requires an InventoryModel argument</param>
        private void SubstractsAmountFromInventory(InventoryModel item)
        {
            long amountInInventory = inventoryController.GetAmountItemInInventory(item);

            item.Amount = amountInInventory - item.Amount;
        }
    }

    
}
