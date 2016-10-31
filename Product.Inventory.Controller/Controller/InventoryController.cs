using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product.Inventory.Controller
{
   public  class InventoryController
    {
        private InventoryDao inventoryDao = new InventoryDao();
        public List<ProductModel> Products { get; set; }

        public InventoryController()
        {
            
        }
        //private bool ValidRequest()
        //{

        //    if (this.MainWindow.xcBProducts.SelectedItem == null || this.MainWindow.xtBAmount.Text.Equals(""))
        //    {
        //        return false;
        //    }
        //    return true;

        //    //It validates input in amount
        //    //if (!IntegerUtils.OnlyInteger(this.xtBAmount.Text))
        //    //{
        //    //    MessageBox.Show("Apenas números");
        //    //}


        //}
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
        /// This method check if the amount of an item added into cart is more than amount of an item in the inventory.
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
                else if(this.GetAmountItemInInventory(item) >= item.Amount + itemInCart.Amount)
                    return true;
                return false;
            }
            
        }
        /// <summary>
        /// This method check if the item is contained in the cart. If so, that item is returned.
        /// </summary>
        /// <param name="item"> Parameter item requires an 'InventoryModel' argument</param>
        /// /// <param name="products"> Parameter products requires a 'SalesModel' argument</param>
        /// <returns>The method returns an InventoryModel</returns>
       
        private InventoryModel GetItemSelectedInCart (InventoryModel item,SalesModel products)
        {
            foreach (InventoryModel itemInInventory in products.Items)
                if (itemInInventory.Product.Name.Equals(item.Product.Name))
                    return itemInInventory;
            return null;
        }

    }
}
