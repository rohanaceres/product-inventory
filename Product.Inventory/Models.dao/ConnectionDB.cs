using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;


namespace Product.Inventory.Dao.models.dao
{
    public abstract class ConnectionDB
    {
        protected string cs = (@"Data Source=C:\Users\lguimaraes\Documents\workspace\Product.Inventory\bd.db;Version=3;New=False;Compress=True;");
        protected SqlConnection con;
        protected SQLiteCommand cmd;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        protected SQLiteDataAdapter DB;
        
       
        private void SetConnection()
        {         
            sql_con = new SQLiteConnection(cs);
  
        }
        protected void ExecuteQuery(string txtQuery)
        {      
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();            
        }

    }
}
