using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Product.Inventory.UI
{
    /// <summary>
    /// Interaction logic for HistoricView.xaml
    /// </summary>
    public partial class HistoricView : Window
    {
        public HistoricView()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
