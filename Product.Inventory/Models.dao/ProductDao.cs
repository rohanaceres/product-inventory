using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Product.Inventory.Dao.models.dao
{
    public class ProductDao : ConnectionDB
    {
       
        public int Search_Id_Product(string name)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string stm = "SELECT * FROM Product WHERE Name= '"+name+"'";

                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                //TODO:filtrar na query
                                return rdr.GetInt32(0);
                            }
                        }
                    }

                    con.Close();
                }
            }            
            catch (Exception)
            {

                throw;
            }
            return -1;
        }

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();

                    string stm = "SELECT * FROM product";

                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                products.Add(new ProductModel(rdr.GetInt32(0), rdr.GetString(1)));
                                
                            }
                        }
                    }

                    con.Close();
                    return products;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
