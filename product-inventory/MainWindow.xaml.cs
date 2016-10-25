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
using Product.Inventory.Dao.Utils;


namespace product_inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BuyController buyController;

        public InventoryController inventoryController;
        public SalesModel Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.buyController = new BuyController();
            this.inventoryController = new InventoryController();
            this.Products = new SalesModel();
            this.Initializer();
        }

        // initialize comboBox with products from inventory
        public void Initializer()
        {
            List<ProductModel> products = buyController.GetListProducts();

            foreach (ProductModel p in products)
                this.xcBProducts.Items.Add(p);
            //DataGridTextColumn c1 = new DataGridTextColumn();
            //c1.Header = "Num";
            //c1.Binding = new Binding("Num");
            //c1.Width = 100;
            //this.xdataGrid.Columns.Add(c1);
            //DataGridTextColumn c2 = new DataGridTextColumn();
            //c2.Header = "Num";
            //c2.Binding = new Binding("Num");
            //c2.Width = 50;
            //this.xdataGrid.Columns.Add(c2);

            //ProductModel p1 = new ProductModel(1, "product1");
            //this.xlistBox.Items.Add(new InventoryModel(p1, 20));
            //this.xlistBox.Items.Add(new InventoryModel(p1, 20));
        }

        // Add items selected in cart 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductModel p = new ProductModel();

            p.Name = this.xcBProducts.SelectedItem.ToString();

            long amount = long.Parse(this.xtBAmount.Text);

            //TODO: Arrumar validacao do campo Amount
            //if (!IntegerUtils.OnlyInteger(amount.ToString()))
            //    MessageBox.Show("Apenas números");

            try
            {
                //p.Id = buyController.Search_Id_Products(p.Name); // Get Id Product

                InventoryModel itemNovo = new InventoryModel(p, amount);

                if (this.ExistsInCart(itemNovo))
                    this.updateAmountOfAProductInCart(itemNovo);
                                                   
                else               
                    this.SendToCart(itemNovo);

                //if (inventoryController.CheckAmount(p, amount))
                //{
                //    Products.Add(p,amount);
                //    this.sendToCart();
                //    //inventoryController.
                //}         
                //else
                //    MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountProduct(p));
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void updateCart()
        {
            this.xlistBox.Items.Clear();

            foreach(InventoryModel itemInInventory in Products.Items)
                this.xlistBox.Items.Add(itemInInventory);
        }

        // Put items in cart
        private void SendToCart(InventoryModel item)
        {
            this.xlistBox.Items.Add(item);

            Products.Items.Add(item);
        }
        private void updateAmountOfAProductInCart(InventoryModel item)
        {       
            foreach (InventoryModel itemInInventory in Products.Items)   
                        
                if (item.Product.Name.Equals(itemInInventory.Product.Name))                                                      
                    itemInInventory.Amount += item.Amount;

            this.updateCart();                                                      
                      
        }
        private bool ExistsInCart(InventoryModel item)
        {
            if (Products.Items==null)
                return false;

            else
            {
                foreach (InventoryModel itemInInventory in Products.Items)               
                    if (item.Product.Name.Equals(itemInInventory.Product.Name))
                        return true;                     
            }

            return false;
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
