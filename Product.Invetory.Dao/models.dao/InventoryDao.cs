using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.models.dao
{
    public class InventoryDao : AbstractDao
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
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
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
                                if (product.Id == rdr.GetInt32(0))
                                    return rdr.GetInt32(3); // Quantity
                               
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
