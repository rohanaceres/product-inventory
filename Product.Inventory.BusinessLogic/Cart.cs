using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Product.Inventory.BusinessLogic
{
    public class Cart
    {           
        public SalesModel Products { get; set; }

        InventoryDao inventoryDao;
        public Cart()
        {         
            Products = new SalesModel();
            this.inventoryDao = new InventoryDao();            
        }        

        public InventoryModel AddItemInCart(InventoryModel item)
        {
            try
            {
                //Check the quantity of an item in inventory is greater than that required
                if (this.CheckAmountInInventory(item, this.Products) && Products.Items != null)
                {
                    //If the item exists, that item is updated instead of adding again
                    if (this.ExistsInCart(item)){
                        this.UpdateAmountOfAProductInCart(item);
                        return null;                     
                    }

                    else
                         return this.SendToCart(item);
                }
                else
                {
                    MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + this.GetAmountItemInInventory(item));
                    return null;
                    //this.MainWindow.base.MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(item)); 
                }

            }
            catch (Exception)
            {
                throw;
            }           
            
        }
        /// <summary>
        /// This method check if the amount of an item added into Cart is more than amount of an item in the inventory.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        /// /// <param name="products"> Parameter products requires a 'SalesModel' argument</param>
        /// <returns>The method returns a bool</returns>
        public bool CheckAmountInInventory(InventoryModel item, SalesModel products)
        {
            InventoryModel itemInCart = this.GetItemSelectedInCart(item, products);

            if (itemInCart == null && this.GetAmountItemInInventory(item) >= item.Amount)
                return true;
            else
            {
                if (itemInCart == null && this.GetAmountItemInInventory(item) <= item.Amount)
                    return false;
                else if (this.GetAmountItemInInventory(item) >= item.Amount + itemInCart.Amount)
                    return true;
                return false;
            }

        }
        /// <summary>
        /// This method get the amount of the item in the inventory.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        /// <returns>The method returns a long</returns>
        public long GetAmountItemInInventory(InventoryModel item)
        {
            return inventoryDao.GetAmountItem(item);
        }
        /// <summary>
        /// This method check if the item is contained in the Cart. If so, that item is returned.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        /// /// <param name="products"> Parameter products requires a 'SalesModel' argument</param>
        /// <returns>The method returns an InventoryModel</returns>

        private InventoryModel GetItemSelectedInCart(InventoryModel item, SalesModel products)
        {
            foreach (InventoryModel itemInInventory in products.Items)
                if (itemInInventory.Product.Name.Equals(item.Product.Name))
                    return itemInInventory;
            return null;
        }
        /// <summary>
        /// This method valid the request. Check if the comboBox was selected  and in the amount field are only numbers.
        /// </summary>    
        /// <returns>The method returns a bool</returns>

        /// <summary>
        /// This method check if the item is contained in the Cart.
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

        }      
       
        /// <summary>
        /// This method put items in the Cart.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        public InventoryModel SendToCart(InventoryModel item)
        {            
            /*this.XListInCart.Items.Add(item)*/;

            Products.Items.Add(item);
            return item;
        }
       

        /// <summary>
        /// This method cleans the list of items in the textBox from HistoricView.
        /// </summary>

        public void DeleteItemInCart(InventoryModel item)
        {
            this.Products.Items.Remove(item);
            //this.UpdateCart();
        }
       
        /// <summary>
        /// This method cleans the list of items in the textBox from Cart.
        /// </summary>

        public void ClearCart(ListBox xListItemsInCart)
        {
            xListItemsInCart.Items.Clear();
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
