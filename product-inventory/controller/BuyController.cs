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
          
    }
}
