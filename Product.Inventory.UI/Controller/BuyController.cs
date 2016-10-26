using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;


namespace Product.Inventory.Controller
{
    
    public class BuyController
    {
        public MainWindow MainWindow { get; set; }

        public InventoryController inventoryController { get; set; }

        InventoryDao inventoryDao = new InventoryDao();

        SalesDao salesDao = new SalesDao();

        public BuyController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.inventoryController = new InventoryController(mainWindow);
        }

        public void BuyProducts(InventoryModel item)
        {

            salesDao.save(item);

            this.SubstractAmountFromTheInventory(item);

            inventoryDao.Update(item);
      

        }
        private void SubstractAmountFromTheInventory(InventoryModel item)
        {
            long amountInInventory = inventoryController.GetAmountItemInInventory(item);

            item.Amount = amountInInventory - item.Amount;
                        
        }
    }
}
