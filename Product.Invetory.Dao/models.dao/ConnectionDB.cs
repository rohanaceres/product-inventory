using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models.dao
{
    public abstract class ConnectionDB
    {
        public OleDbConnection conn = new OleDbConnection();
        public OleDbCommand cmd = new OleDbCommand();

        string strCn =" Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:/Users/Leandro/Documents/workspaceC#/product-inventory/ProductInventory.accdb";
        protected void ConnectToAccess()
        {
            conn.ConnectionString = strCn;

            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" Não foi possível conectar");
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
