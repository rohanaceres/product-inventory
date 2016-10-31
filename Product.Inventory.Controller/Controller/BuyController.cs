using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System.Windows;

namespace Product.Inventory.Controller
{
       
    /// <summary>
    /// 
    /// </summary>
    public class BuyController
    {
        //Properties
        /// <summary>
        /// 
        /// </summary>
        public InventoryController inventoryController { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SalesController salesController { get; set; }
        //Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainWindow"></param>
        public BuyController()
        {
          
            this.inventoryController = new InventoryController();
            this.salesController = new SalesController();
        }
        /// <summary>
        /// This method save an item(in Sales Table) and update(in Inventory Table) it in the inventory.
        /// </summary>
        /// <param name="item"> Parameter item requires an InventoryModel argument</param>    
        
    }
}
