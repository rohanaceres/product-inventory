using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models.dao
{
    public class ProductDao : AbstractDao
    {
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Search()
        {
            this.ConnectToAccess();
            string search = "select * from Product where Id = 1";
            try {

                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = search;

                OleDbDataReader reader = cmd.ExecuteReader();

                int count = 0;

                while (reader.Read())
                {
                    count++;

                    //Guarda os dados recebidos do BD

                    System.Diagnostics.Debug.WriteLine(reader["Id"].ToString());
                    System.Diagnostics.Debug.WriteLine(reader["Name"].ToString());

                }
              
                conn.Close();
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine(" Dados Inválidos. Transação negada");
                throw;
            }
        
        }
        
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
