using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System.Windows;

namespace Product.Inventory.Controller
{
    
    public class BuyController
    {
        public MainWindow MainWindow { get; set; }

        public InventoryController inventoryController { get; set; }

        InventoryDao inventoryDao = new InventoryDao();

        SalesDao salesDao = new SalesDao();

        public SalesController salesController { get; set; }

        public BuyController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.inventoryController = new InventoryController(mainWindow);
            this.salesController = new SalesController(mainWindow);
        }

        public void BuyProducts(InventoryModel item)
        {

            bool save = salesDao.save(item);

            this.SubstractAmountFromTheInventory(item);

            bool update = inventoryDao.Update(item);

            if (save && update)
            {
                MessageBox.Show("Successful");
                this.salesController.ClearCart();
            }


        }
        private void SubstractAmountFromTheInventory(InventoryModel item)
        {
            long amountInInventory = inventoryController.GetAmountItemInInventory(item);

            item.Amount = amountInInventory - item.Amount;
                        
        }
    }
}
