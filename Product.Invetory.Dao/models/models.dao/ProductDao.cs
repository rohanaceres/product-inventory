using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Product.Inventory.Dao.models.dao
{
    public class ProductDao : ConnectionDB
    {
        //TODO refazer abstrata
       

        public void Search(int id)
        {
            //try
            //{
            //    using (SQLiteConnection con = new SQLiteConnection(cs))
            //    {
            //        con.Open();

            //        string stm = "SELECT * FROM product WHERE Id=1";

            //        using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
            //        {
            //            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            //            {
            //                while (rdr.Read())
            //                {
            //                    Console.WriteLine(rdr.GetInt32(0) + "  " + rdr.GetString(1));
            //                }
            //            }
            //        }

            //        con.Close();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
           

            //string search = "select * from Product where Id = 1";
            //try {

            //    conn.Open();
            //    cmd.Connection = conn;

            //    cmd.CommandText = search;

            //    OleDbDataReader reader = cmd.ExecuteReader();

            //    int count = 0;

            //    while (reader.Read())
            //    {
            //        count++;

            //        //Guarda os dados recebidos do BD

            //        System.Diagnostics.Debug.WriteLine(reader["Id"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader["Name"].ToString());

            //    }

            //    conn.Close();
            //}
            //catch (Exception)
            //{
            //    System.Diagnostics.Debug.WriteLine(" Dados Inválidos. Transação negada");
            //    throw;
            //}

        }
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
        //public override void Update(Object obj)
        //{
        //    throw new NotImplementedException();
        //}
        public void teste()
        {
            //this.SetConnection();
            this.TestConnection();
        }
    }
}
