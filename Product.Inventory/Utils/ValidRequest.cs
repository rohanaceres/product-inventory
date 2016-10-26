using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Invetory.Utils
{
    public class ValidRequest
    {

        public static bool OnlyInteger(string s)
        {
            int value;

            return int.TryParse(s, out value);
        }


        //TODO: Ver qual parametro do Combobox e TextBox

        //public bool isNullOrEmpty()
        //{
        //    if (string.IsNullOrEmpty(this.MainWindow.xcBProducts.SelectedItem.ToString()) 
        //        || string.IsNullOrEmpty(this.MainWindow.xtBAmount.Text))
        //    {
                
        //        return  
        //    }

        //    return null;
        //}
        
    }
}
