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
            //TODO: Inicializar no app.xaml.cs

            List<ProductModel> products = buyController.GetListProducts();

            foreach (ProductModel p in products)
                this.xcBProducts.Items.Add(p);
            
        }

        // Add items selected in cart 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductModel p = new ProductModel();

            //Get datas from form 
            p.Name = this.xcBProducts.SelectedItem.ToString();
            long amount = long.Parse(this.xtBAmount.Text);

            //It validates input in amount
            //if (!IntegerUtils.OnlyInteger(this.xtBAmount.Text))
            //{
            //    MessageBox.Show("Apenas números");
            //}

            try
            {
                p.Id = buyController.Search_Id_Products(p.Name); // Get Id Product | The query in inventoryDao.getAmountItem needs this property

                InventoryModel itemNovo = new InventoryModel(p, amount); // Item created with form information(ComboBox and TextBox)

                //Check the quantity of an item in inventory is greater than that required
                if (inventoryController.CheckAmountInInventory(itemNovo, Products) && Products.Items!=null)
                {
                    //If the item exists, that item is updated instead of adding again
                    if (this.ExistsInCart(itemNovo))
                        this.updateAmountOfAProductInCart(itemNovo);

                    else
                        this.SendToCart(itemNovo);
                }

                else
                    MessageBox.Show("Quantidade superior a do estoque. Quantidade no estoque: " + inventoryController.GetAmountItemInInventory(itemNovo));
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Clean and update the items in cart
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
        // Find the item and update your amount
        private void updateAmountOfAProductInCart(InventoryModel item)
        {       
            foreach (InventoryModel itemInInventory in Products.Items)   
                        
                if (item.Product.Name.Equals(itemInInventory.Product.Name))                                                      
                    itemInInventory.Amount += item.Amount;

            this.updateCart();                                                      
                      
        }
       // Check if cart contains that item
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

        private void xlistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("selecionado");
        }

        private void tBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
