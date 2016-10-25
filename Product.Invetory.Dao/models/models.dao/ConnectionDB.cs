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
        protected string cs = (@"Data Source=C:\Users\lguimaraes\Documents\workspace\product-inventory\bd.db;Version=3;New=False;Compress=True;");
        
        private SQLiteConnection sql_con;
        protected SqlConnection con;
        protected SQLiteCommand cmd;
       
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        //private DataSet DS = new DataSet();
        //private DataTable DT = new DataTable();



        public void ConnectSQLite()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public void TestConnection()
        {
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();

                string stm = "SELECT * FROM product WHERE Id=1";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr.GetInt32(0) + "  "+rdr.GetString(1));
                        }
                    }
                }

                con.Close();
            }
        }
        public void Test()
        {

            //SqlConnection conn = new SqlConnection(connMDF);
            //conn.Open();
            //string query = "SELECT * FROM Product WHERE Id=1";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.CommandText = search;

            //SqlDataReader reader = cmd.ExecuteReader();
        }
        public void SetConnection()
        {
            try
            {
                sql_con = new SQLiteConnection
                ("Data Source=bd.db;Version=3;New=False;Compress=True;");
                string sql = "select * from Product where Id=1";
                this.ExecuteQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }         
            

           
           
            
        }

        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select id, desc from mains";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            //DS.Reset();
            //DB.Fill(DS);
            //DT = DS.Tables[0];
            //Grid.DataSource = DT;
            sql_con.Close();
        }

        private void Add()
        {
            //string txtSQLQuery = "insert into  mains (desc) values ('" + txtDesc.Text + "')";
            //ExecuteQuery(txtSQLQuery);
        }
        //public OleDbConnection conn = new OleDbConnection();
        //public OleDbCommand cmd = new OleDbCommand();

        //string strCn = " Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:/Users/Leandro/Documents/workspaceC#/product-inventory/ProductInventory.accdb";
        //protected void ConnectToAccess()
        //{
        //    conn.ConnectionString = strCn;

        //    try
        //    {
        //        conn.Open();
        //    }

        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(" Não foi possível conectar");
        //        throw;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        protected void Connect()
        {
            
        }

        //protected void Connect()
        //{
        //    SQLiteConnection.CreateFile("ProductInventorySQLite.sqlite");
        //    SQLiteConnection m_dbConnection;
        //    m_dbConnection =  new SQLiteConnection("Data Source=ProductInventory.sqlite;Version=3;");
        //    m_dbConnection.Open();
        //    string sql = "create table highscores (name varchar(20), score int)";
        //}
    }
}
