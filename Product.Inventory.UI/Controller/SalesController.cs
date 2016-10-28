using Product.Inventory.Dao.models;
using System;
using Product.Inventory.Dao.models.dao;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Product.Inventory.UI.ViewModel;

namespace Product.Inventory.Controller
{
    public class SalesController
    {
        
        public InventoryController inventoryController { get; set; }
        public ProductController productController { get; set; }
        public SalesModel Products { get; set; }
        private SalesDao salesDao = new SalesDao();
        public MainWindow MainWindow { get; private set; }

        public SalesController(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.inventoryController = new InventoryController(mainWindow);
            this.productController = new ProductController(mainWindow);
            this.Products = new SalesModel();
        }
        /// <summary>
        /// This method add a item selected and your amount in the cart  
        /// </summary>
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
                    else
                    {
                        MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(newItem));
                        //this.MainWindow.base.MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(item)); 
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                //MessaBox.Show();
            }
            
        }
        
        /// <summary>
        /// This method valid the request. Check if the comboBox was selected  and in the amount field are only numbers.
        /// </summary>    
        /// <returns>The method returns a bool</returns>
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
        /// <summary>
        /// This method check if the item is contained in the cart.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>  
        /// <returns>The method returns a bool</returns>
       
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
       
        /// <summary>
        /// This method find the item and update your amount.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        private void UpdateAmountOfAProductInCart(InventoryModel item)
        {
            foreach (InventoryModel itemInInventory in Products.Items)

                if (item.Product.Name.Equals(itemInInventory.Product.Name))
                    itemInInventory.Amount += item.Amount;

            this.UpdateCart();

        }
        /// <summary>
        /// This method cleans and update the items in the cart.
        /// </summary>
        public void UpdateCart()
        {
            this.MainWindow.xlistBox.Items.Clear();

            foreach (InventoryModel itemInInventory in Products.Items)
                this.MainWindow.xlistBox.Items.Add(itemInInventory);
        }
        /// <summary>
        /// This method get a list of items purchased and show it in the textBox
        /// </summary>
        public void ShowListOfItemsInBought()
        {
            this.ClearHistoricOfItemsBought();

            this.MainWindow.historicView.xTextBoxHistoric.Text = "   ITEM                Quantity \r\n";

            List<InventoryModel> items = this.salesDao.GetItemsSold();

            foreach (InventoryModel item in items)
                this.MainWindow.historicView.xTextBoxHistoric.Text += "" + item.Product.Name + "                 " + item.Amount+"\r\n";
        }
        /// <summary>
        /// This method put items in the cart.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        private void SendToCart(InventoryModel item)
        {
            this.MainWindow.xlistBox.Items.Add(item);

            Products.Items.Add(item);
        }
        /// <summary>
        /// This method cleans the list of items in the textBox from HistoricView.
        /// </summary>
      
        public void DeleteItemInCart(InventoryModel item)
        {
            this.Products.Items.Remove(item);
            this.UpdateCart();
        }
        private void ClearHistoricOfItemsBought()
        {
            this.MainWindow.historicView.xTextBoxHistoric.Text = "";
        }
        /// <summary>
        /// This method cleans the list of items in the textBox from cart.
        /// </summary>
       
        public void ClearCart()
        {
            this.MainWindow.xlistBox.Items.Clear();
            this.ClearItemsInList();
        }
        /// <summary>
        /// This method cleans the list of items from SalesModel.
        /// </summary>
       
        private void ClearItemsInList()
        {
            this.Products.Items.Clear();
        }
    }
}
