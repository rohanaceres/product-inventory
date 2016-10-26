using Product.Inventory.Dao.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Controller
{
    public class SalesController
    {
        public InventoryController inventoryController { get; set; }

        public ProductController productController { get; set; }
        public SalesModel Products { get; set; }
        public MainWindow MainWindow { get; private set; }

        public SalesController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.inventoryController = new InventoryController(mainWindow);
            this.productController = new ProductController(mainWindow);
            this.Products = new SalesModel();
        }
        public void AddItemInCart()
        {

            if (this.ValidRequest())
            {
                ProductModel p = new ProductModel();

                //Get datas from form 
                p.Name = this.MainWindow.xcBProducts.SelectedItem.ToString();
                long amount = long.Parse(this.MainWindow.xtBAmount.Text);

                p.Id = productController.Search_Id_Products(p.Name); // Get Id Product | The query in inventoryDao.getAmountItem needs this property

                InventoryModel newItem = new InventoryModel(p, amount);

                try
                {
                    //Check the quantity of an item in inventory is greater than that required
                    if (inventoryController.CheckAmountInInventory(newItem, this.Products) && Products.Items != null)
                    {
                        //If the item exists, that item is updated instead of adding again
                        if (this.ExistsInCart(newItem))
                            this.UpdateAmountOfAProductInCart(newItem);

                        else
                            this.SendToCart(newItem);
                    }

                    //else                
                    //    this.MainWindow.MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(item));                                  
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                //this.MainWindow.MessaBox();
            }
            
        }
        private bool ValidRequest()
        {
            if(this.MainWindow.xcBProducts.SelectedItem==null || this.MainWindow.xtBAmount.Text.Equals(""))           
            {
                return false;
            }
            return true;
            
            //It validates input in amount
            //if (!IntegerUtils.OnlyInteger(this.xtBAmount.Text))
            //{
            //    MessageBox.Show("Apenas números");
            //}

            
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void UpdateAmountOfAProductInCart(InventoryModel item)
        {
            foreach (InventoryModel itemInInventory in Products.Items)

                if (item.Product.Name.Equals(itemInInventory.Product.Name))
                    itemInInventory.Amount += item.Amount;

            this.UpdateCart();

        }
        // Clean and update the items in cart
        private void UpdateCart()
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
