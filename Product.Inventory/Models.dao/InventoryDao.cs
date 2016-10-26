using System;
using System.Data.SQLite;

namespace Product.Inventory.Dao.models.dao
{
    public class InventoryDao : ConnectionDB
    {
        
       public void save(InventoryModel item)
        {
            
        }
        public bool Update(InventoryModel item)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string query = "UPDATE Inventory SET Quantity = '" + item.Amount + "' WHERE Id_Product = '" + item.Product.Id + "'";

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
            
            //InventoryModel i = new InventoryModel(new ProductModel(4, "product04"), 125);
            //i.Id = 4;


            //using (SQLiteConnection connection = new SQLiteConnection(cs))
            //{

            //    using (SQLiteCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "UPDATE Inventory SET  Quantity = '@Quantity' WHERE Id_Product= '@Id_Product'";

            //        command.Parameters.AddWithValue("@Quantity", 125);
            //        command.Parameters.AddWithValue("@Id_Product", 3);

            //        connection.Open();

            //        command.ExecuteNonQuery();
            //    }

            //}
            //return true;
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
