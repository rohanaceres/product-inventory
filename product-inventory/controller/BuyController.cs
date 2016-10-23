using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Product.Inventory.Dao; // added in references from project
using Product.Inventory.Dao.models;
using Product.Inventory.Dao.Utils;
using Product.Inventory.Dao.models.dao;


namespace product_inventory.controller
{
    
    public class BuyController
    {
        //MainWindow mainView;
        public Dictionary<ProductModel, long> Products { get; set; }
        //public BuyController(MainWindow mainView)
        //{
        //    this.mainView = mainView;
        //    this.Products = new Dictionary<ProductModel, long>();
        //}

        ProductDao productdao = new ProductDao();

        public void teste()
        {
            productdao.Search();
        }
        // Valid amount field
        //public bool isValid {
        //    get{
        //        string textBox = mainView.tBAmount.Text;

        //        if (IntegerUtils.OnlyInteger(textBox) == false)
        //            return false;

        //        if (String.IsNullOrEmpty(textBox))
        //            return false;


        //        return true;
        //    }
        //}

        //public void SendToCart()
        //{           
        //    try
        //    {
        //        if (isValid)
        //        {
        //            ProductModel p = new ProductModel();

        //            p.Name = this.mainView.cBProducts.SelectedItem.ToString();
        //            long amount = long.Parse(this.mainView.tBAmount.Text);

        //            Products.Add(p, amount);

        //            this.mainView.tBCart.Text = "ITEM                Quantity \n";

        //            foreach (KeyValuePair<ProductModel, long> items in Products)
                    
        //                this.mainView.tBCart.Text += items.Key + "                " + items.Value + "\n";                  
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        
        

    }
}
