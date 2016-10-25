using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ProductModel(int id,String name, String description, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }
        public ProductModel(int id,String name)
        {
            this.Id = id;
            this.Name = name;
            
        }
        public ProductModel()
        {

        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
