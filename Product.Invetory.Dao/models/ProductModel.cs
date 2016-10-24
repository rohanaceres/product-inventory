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

        public ProductModel(int Id,String Name, String Description, double Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
        }
        public ProductModel(int Id,String Name)
        {
            this.Id = Id;
            this.Name = Name;
            
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
