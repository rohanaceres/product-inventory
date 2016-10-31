using Product.Inventory.BusinessLogic;
using Product.Inventory.Dao.models;
using Product.Inventory.Dao.models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Product.Inventory.Controller
{
   public  class InventoryController
    {
        private InventoryDao inventoryDao = new InventoryDao();       
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
       

    }
}
