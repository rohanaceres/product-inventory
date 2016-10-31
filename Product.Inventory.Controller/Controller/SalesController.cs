using Product.Inventory.Dao.models;
using System;
using Product.Inventory.Dao.models.dao;
using System.Collections.Generic;
using System.Windows;

namespace Product.Inventory.Controller
{
    public class SalesController
    {
        
        public InventoryController inventoryController { get; set; }
       
                
        public SalesDao salesDao = new SalesDao();
        public SalesModel Products { get; set; }

        public SalesController()
        {
           
            this.inventoryController = new InventoryController();
            
            this.Products = new SalesModel();
        }


        public List<InventoryModel> GetItemsSold()
        {
            return salesDao.GetItemsSold();
        }

    }
}
