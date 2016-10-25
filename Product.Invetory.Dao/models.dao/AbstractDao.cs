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

        public abstract void Search(int id);
        public abstract void Save(Object obj);
        public abstract void Update(Object obj);
        public abstract void Delete(Object obj);

    }
}
