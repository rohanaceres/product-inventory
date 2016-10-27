using System;
using System.Data.SQLite;

namespace Product.Inventory.Dao.models.dao
{
    public class InventoryDao : ConnectionDB
    {
        
        public bool Update(InventoryModel item)
        {
            string query = "UPDATE Inventory SET Quantity = '" + item.Amount + "' WHERE Id_Product = '" + item.Product.Id + "'";
            
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
        public long GetAmountItem(InventoryModel item)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string query = "SELECT * FROM Inventory i JOIN Product p ON i.Id_Product=p.Id ";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                /*TODO: Implementar de outra forma o retorno(indice por nome na tabela)
                                filtrar na query*/
                                
                                if (item.Product.Id == rdr.GetInt32(0))
                                    return rdr.GetInt32(2); // Quantity  
                               
                            }
                        }
                    }
                               
                }
                return -1;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
