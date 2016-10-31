using Product.Inventory.Controller;
using Product.Inventory.Dao.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.BusinessLogic
{
    public class HistoricList
    {
        SalesController salesController;

        public HistoricList()
        {
            this.salesController = new SalesController();
        }

        /// <summary>
        /// This method get a list of items purchased and show it in the textBox
        /// </summary>
       
        public List<InventoryModel> GetItemsSold()
        {
            return this.salesController.GetItemsSold();
        }

    }
}
