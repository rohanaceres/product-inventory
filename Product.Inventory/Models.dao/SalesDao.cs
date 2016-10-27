using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Product.Inventory.Dao.models.dao
{
    public class SalesDao : ConnectionDB
    {

        public bool save(InventoryModel item)
        {
            string query = "INSERT INTO Sales(Id_Product,Quantity) VALUES('" + item.Product.Id + "','" + item.Amount + "')";

            try
            {
                this.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
        public List<InventoryModel> GetItemsSold()
        {
            List<InventoryModel> items = new List<InventoryModel>();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string query = "SELECT p.Id,p.Name,s.Quantity FROM Sales s JOIN Product p ON s.Id_Product=p.Id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                //TODO:filtrar na query
                                ProductModel product = new ProductModel(rdr.GetInt32(0), rdr.GetString(1));
                                InventoryModel item = new InventoryModel(product, rdr.GetInt32(2)); // An item is a product with your quantity specified

                                items.Add(item);

                                
                            }
                        }
                    }
                    return items;
                   
                }
            }

            catch (Exception)
            {

                throw;
            }
            
        }  
    }
}
