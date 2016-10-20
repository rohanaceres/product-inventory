using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Invetory.Dao.models.dao
{
    public abstract class AbstractDao
    {
        public abstract void Search();
        public abstract void Save();
        public abstract void Update();
        public abstract void Delete();

    }
}
