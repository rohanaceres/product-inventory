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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Product.Inventory.Dao.models;
using product_inventory.controller;


namespace product_inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        BuyController buyController;
        public MainWindow()
        {
            InitializeComponent();
            this.buyController = new BuyController();
            this.Initializer();
           
            //this.Products = new Dictionary<ProductModel, long>();

        }
        
        public Dictionary<ProductModel, long> Products { get; set; }
        // initialize comboBox 
        public void Initializer()
        {
            //List<ProductModel> products = buyController.GetListProducts();
            foreach (ProductModel p in buyController.GetListProducts())
                this.cBProducts.Items.Add(p);
        }

        // Add items selected
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            buyController.teste();
            //buyController.SendToCart();
            
            //ProductModel p = new ProductModel();

            //p.Name = this.cBProducts.SelectedItem.ToString();
            //long amount = long.Parse(this.tBAmount.Text);
           
            //Products.Add(p, amount);

            //this.sendToCart();

           
        }
        // Put items in cart
        private void sendToCart()
        {
            this.tBCart.Text = "ITEM                Quantity \n";
            //foreach (ProductModel items in Products)
            //{
            //    this.tBCart.Text += items.Key + "                " + items.Value + "\n";
            //}
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            //TODO: verifica estoque 
            //Verifica no banco o que é necessário
        }

        private void tBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
