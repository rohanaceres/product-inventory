
using Product.Inventory.Controller;
using Product.Inventory.Dao.models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Product.Inventory.BusinessLogic
{
    public class Cart
    {
        public InventoryController inventoryController;
        public SalesController salesController;
        public SalesModel Products { get; set; }

        public ListBox XListInCart { get; set; }

        public Cart(ListBox xListInCart)
        {
            this.inventoryController = new InventoryController();
            this.salesController = new SalesController();
            Products = new SalesModel();
            this.XListInCart = xListInCart;
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
                        this.UpdateAmountOfAProductInCart(item);

                    else
                        this.SendToCart(item);
                }
                else
                {
                    MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(item));
                    //this.MainWindow.base.MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(item)); 
                }

            }
            catch (Exception)
            {
                throw;
            }           
            
        }
        /// <summary>
        /// This method valid the request. Check if the comboBox was selected  and in the amount field are only numbers.
        /// </summary>    
        /// <returns>The method returns a bool</returns>
       
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
            this.XListInCart.Items.Clear();         

            foreach (InventoryModel itemInInventory in Products.Items)
                this.XListInCart.Items.Add(itemInInventory);
        }
       
        /// <summary>
        /// This method put items in the cart.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        public void SendToCart(InventoryModel item)
        {
            
            this.XListInCart.Items.Add(item);

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
       
        /// <summary>
        /// This method cleans the list of items in the textBox from cart.
        /// </summary>

        public void ClearCart()
        {
            this.XListInCart.Items.Clear();
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
