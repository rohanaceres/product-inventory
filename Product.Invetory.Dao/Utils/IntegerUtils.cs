using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Inventory.Dao.Utils
{
    public  static class IntegerUtils
    {

        public static bool OnlyInteger(string s)
        {
            int value;         

            return int.TryParse(s, out value);
        }
    }
}
