using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Product.Inventory.Dao.models.dao
{
    public class InventoryDao : ConnectionDB
    {


        public int Search(int id) {

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string query = "SELECT * FROM Inventory WHERE Id = " + id;

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                
                                                               

                            }
                        }
                    }

                    con.Close();
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    

        public void Update(InventoryModel item)
        {
            
            string query = "UPDATE Inventory SET  Id_Product= '"+item.Id +"', Quantity = '"+item.Amount +"'"; 
        }
        public long GetAmountProduct(ProductModel product)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string stm = "SELECT * FROM Inventory i JOIN Product p ON i.Id_Product=p.Id ";

                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                /*TODO: Implementar de outra forma o retorno(indice por nome na tabela)
                                filtrar na query*/
                                
                                if (product.Id == rdr.GetInt32(0))
                                    return rdr.GetInt32(2); // Quantity  
                               
                            }
                        }
                    }

                    con.Close();
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
