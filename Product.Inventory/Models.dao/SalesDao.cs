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
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();
                    
                    string query = "INSERT INTO Sales(Id_Product,Quantity) VALUES('"+ item.Product.Id+"','"+item.Amount +"')";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
