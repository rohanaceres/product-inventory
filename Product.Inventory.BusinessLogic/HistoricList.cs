using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System.Collections.Generic;

namespace Product.Inventory.BusinessLogic
{
    public class HistoricList
    {

        SalesDao salesDao = new SalesDao();

        public HistoricList()
        {
            
        }

        /// <summary>
        /// This method get a list of items purchased and show it in the textBox
        /// </summary>
       
        public List<InventoryModel> GetItemsSold()
        {
            return this.salesDao.GetItemsSold();
        }

    }
}
