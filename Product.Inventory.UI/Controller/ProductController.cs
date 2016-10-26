using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Product.Inventory.Dao; // added in references from project
using Product.Inventory.Dao.models;
using Product.Inventory.Dao.Utils;
using Product.Inventory.Dao.models.dao;


namespace Product.Inventory.Controller
{
    
    public class ProductController
    {
        ProductDao productdao = new ProductDao();
        public List<ProductModel> Products { get; set; }

        public MainWindow MainWindow { get; set; }

        public ProductController(MainWindow mainWindow)
        {
            this.Products = new List<ProductModel>();
            this.MainWindow = mainWindow;
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
