using Product.Inventory.Dao.models;
using System;
using Product.Inventory.Dao.models.dao;
using System.Collections.Generic;
using System.Windows;
using Product.Inventory.BusinessLogic;
using System.Windows.Controls;

namespace Product.Inventory.Controller
{
    public class SalesController
    {      
        public SalesDao salesDao = new SalesDao();
        public SalesModel Products { get; set; }

        public Cart Cart { get; set; }

        public SalesController()
        {
            this.Cart = new Cart();
        
            this.Products = new SalesModel();
        }

        public void AddItemsInCart(InventoryModel item, ListBox xListItemsInCart)
        {
            InventoryModel newItem = Cart.AddItemInCart(item);
            if (newItem == null)
                this.UpdateCart(xListItemsInCart);
            else
                xListItemsInCart.Items.Add(newItem);
            
        }
        /// <summary>
        /// This method cleans and update the items in the Cart.
        /// </summary>
        public void UpdateCart(ListBox xListItemsInCart)
        {
            xListItemsInCart.Items.Clear();

            foreach (InventoryModel itemInInventory in Products.Items)
                xListItemsInCart.Items.Add(itemInInventory);
        }
        public List<InventoryModel> GetItemsSold()
        {
            return salesDao.GetItemsSold();
        }
        public void DeleteItem(InventoryModel item, ListBox xListItemsInCart)
        {
            Cart.DeleteItemInCart(item);
            this.UpdateCart(xListItemsInCart);
        }
        public void ClearCart(ListBox xListItemsInCart)
        {
            Cart.ClearCart(xListItemsInCart);
        }

    }
}
