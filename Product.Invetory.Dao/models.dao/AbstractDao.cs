using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Inventory.Dao.models.dao;

namespace Product.Inventory.Dao.models.dao
{
    public abstract class AbstractDao : ConnectionDB
    {   

        public abstract void Search();
        public abstract void Save();
        public abstract void Update();
        public abstract void Delete();

    }
}
