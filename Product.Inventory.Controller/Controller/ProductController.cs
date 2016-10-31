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
        private ProductDao productdao = new ProductDao();
        public List<ProductModel> Products { get; set; }

        public ProductController()
        {
            this.Products = new List<ProductModel>();
          
        }
        /// <summary>
        /// This method get a list of products
        /// </summary>
        /// <returns>The method returns a ProductModel list </returns>
        public List<ProductModel> GetListProducts()
        {
            return productdao.GetProducts();
        }
        /// <summary>
        /// This method search id of an item in the database.
        /// </summary>
        /// <param name="name"> Parameter item requires a string argument</param>
        /// <returns>The method returns a int</returns>        
        public int Search_Id_Products(String name)
        {
            return productdao.Search_Id_Product(name);
        }
          
    }
}
