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

        public void save(SalesModel sales)
        {
            //using (SqlConnection connection = new SqlConnection(cs))
            //using (SqlCommand command = connection.CreateCommand())
            //{
            //    command.CommandText = "INSERT INTO Inventory (FirstName, Address, City) VALUES(@ln, @fn, @add, @cit)";

            //    command.Parameters.AddWithValue("@ln", lastName);
            //    command.Parameters.AddWithValue("@fn", firstName);


            //    connection.Open();

            //    command.ExecuteNonQuery();

            //    connection.Close();
            //}
        
    }
}
