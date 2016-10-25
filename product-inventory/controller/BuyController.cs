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
        ProductDao productdao = new ProductDao();
        public List<ProductModel> Products { get; set; }

        public BuyController()
        {
            this.Products = new List<ProductModel>();
        }      
     
        public List<ProductModel> GetListProducts()
        {
            return productdao.GetProducts();
        }
        public int Search_Id_Products(String name)
        {
            return productdao.Search_Id_Product(name);
        }
        //public void teste()
        //{
        //    productdao.teste();
        //}
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
