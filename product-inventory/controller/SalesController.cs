using Product.Inventory.Dao.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_inventory.controller
{
    public class SalesController
    {
        public InventoryController inventoryController { get; set; }
        public SalesModel Products { get; set; }
        public MainWindow MainWindow { get; private set; }

        public SalesController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.inventoryController = new InventoryController(mainWindow);
            this.Products = new SalesModel();
        }
        public void AddItemInCart(InventoryModel item)
        {
            try
            {
                //Check the quantity of an item in inventory is greater than that required
                if (inventoryController.CheckAmountInInventory(item, this.Products) && Products.Items != null)
                {
                    //If the item exists, that item is updated instead of adding again
                    if (this.ExistsInCart(item))
                        this.updateAmountOfAProductInCart(item);

                    else
                        this.SendToCart(item);
                }

                //else
                //    this.MainWindow.MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(item));
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Check if cart contains that item
        private bool ExistsInCart(InventoryModel item)
        {
            if (Products.Items == null)
                return false;

            else
            {
                foreach (InventoryModel itemInInventory in Products.Items)
                    if (item.Product.Name.Equals(itemInInventory.Product.Name))
                        return true;
            }

            return false;
        }
        // Find the item and update your amount
        private void updateAmountOfAProductInCart(InventoryModel item)
        {
            foreach (InventoryModel itemInInventory in Products.Items)

                if (item.Product.Name.Equals(itemInInventory.Product.Name))
                    itemInInventory.Amount += item.Amount;

            this.updateCart();

        }
        // Clean and update the items in cart
        private void updateCart()
        {
            this.MainWindow.xlistBox.Items.Clear();

            foreach (InventoryModel itemInInventory in Products.Items)
                this.MainWindow.xlistBox.Items.Add(itemInInventory);
        }
        // Put items in cart
        private void SendToCart(InventoryModel item)
        {
            this.MainWindow.xlistBox.Items.Add(item);

            Products.Items.Add(item);
        }

    }
}
