using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;

namespace Product.Inventory.BusinessLogic
{
    public class BuyItems
    {
        InventoryDao inventoryDao;

        public Cart Cart { get; set; }

        public BuyItems()
        {
            this.inventoryDao = new InventoryDao();
            this.Cart = new Cart();
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
            long amountInInventory = Cart.GetAmountItemInInventory(item);

            item.Amount = amountInInventory - item.Amount;
        }
    }

    
}
