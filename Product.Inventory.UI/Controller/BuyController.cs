using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System.Windows;

namespace Product.Inventory.Controller
{
    
    public class BuyController
    {
        public MainWindow MainWindow { get; set; }

        public InventoryController inventoryController { get; set; }

        private InventoryDao inventoryDao = new InventoryDao();

        private SalesDao salesDao = new SalesDao();

        public SalesController salesController { get; set; }

        public BuyController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.inventoryController = new InventoryController(mainWindow);
            this.salesController = new SalesController(mainWindow);
        }
        /// <summary>
        /// This method save an item(in Sales Table) and update(in Inventory Table) it in the inventory.
        /// </summary>
        /// <param name="item"> Parameter item requires an InventoryModel argument</param>    
        public void BuyProducts(InventoryModel item)
        {

            bool save = salesDao.save(item);

            this.SubstractsAmountFromTheInventory(item);

            bool update = inventoryDao.Update(item);

            if (save && update)
            {
                MessageBox.Show("Successful");
                this.salesController.ClearCart();
            }


        }
        /// <summary>
        /// This method subtracts the amount of a purchased item by item in inventory
        /// </summary>
        /// <param name="item"> Parameter item requires an InventoryModel argument</param>
        private void SubstractsAmountFromTheInventory(InventoryModel item)
        {
            long amountInInventory = inventoryController.GetAmountItemInInventory(item);

            item.Amount = amountInInventory - item.Amount;
                        
        }
    }
}
