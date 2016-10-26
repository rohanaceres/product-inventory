using Product.Inventory.Dao.models.dao;


namespace Product.Inventory.Controller
{
    
    public class BuyController
    {
        public MainWindow MainWindow { get; set; }

        InventoryDao inventoryDao = new InventoryDao();
        public BuyController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public void BuyProducts()
        {
            inventoryDao.Update();
        }
    }
}
