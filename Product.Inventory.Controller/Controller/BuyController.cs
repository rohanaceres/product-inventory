using Product.Inventory.BusinessLogic;
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
        public BuyItems BuyItems { get; set; }
        public BuyController()
        {
            this.BuyItems = new BuyItems();
        }

        public void BuyProduct(InventoryModel item)
        {
            this.BuyItems.BuyProducts(item);
        }
     
    }
}
