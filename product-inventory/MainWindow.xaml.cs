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
        InventoryController inventoryController;    
        public Dictionary<ProductModel,long> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.buyController = new BuyController();
            this.inventoryController = new InventoryController();
            this.Products = new Dictionary<ProductModel, long>();
            this.Initializer();            
        }
        
        // initialize comboBox 
        public void Initializer()
        {          
            foreach (ProductModel p in buyController.GetListProducts())
                this.cBProducts.Items.Add(p);
        }

        // Add items selected
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //buyController.teste();            
            ProductModel p = new ProductModel();

            p.Name = this.cBProducts.SelectedItem.ToString();
            p.Id = buyController.Search_Id_Products(p.Name);

            long amount = long.Parse(this.tBAmount.Text);
            try
            {
                if (inventoryController.CheckAmount(p, amount))
                {
                    products.Add(p,amount);
                    this.sendToCart();
                }         
                else
                    MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountProduct(p));
            }
            catch (Exception)
            {

                throw;
            }
 
        }
        // Put items in cart
        private void sendToCart()
        {
            this.tBCart.Text = "ITEM                Quantity \n";
            foreach (KeyValuePair<ProductModel,long> items in Products)
            {
                this.tBCart.Text += items.Key + "                " + items.Value + "\n";
            }
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
