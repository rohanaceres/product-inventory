using System;
using System.Collections.Generic;
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
        public long GetQuantity(ProductModel product)
        {

            //TODO: criar query
            return 1;
        }
        
    }
}
