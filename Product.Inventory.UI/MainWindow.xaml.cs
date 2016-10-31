using Product.Inventory.Controller;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using Product.Inventory;
using Product.Inventory.Dao.models;
using Product.Inventory.UI;
using Product.Inventory.BusinessLogic;

namespace Product.Inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public HistoricView historicView { get; set; }

        public Cart Cart { get; set; }

        public BuyItems BuyItems { get; set; }

        ProductController productController;

        SalesController salesController;

        BuyController buyController;

        public MainWindow()
        {
            InitializeComponent();

            this.buyController = new BuyController();

            this.productController = new ProductController();

            this.salesController = new SalesController();
            
                              
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            BuyItems = new BuyItems();
            Cart = new Cart();

            this.Initializer();
        }

        // initialize comboBox with products from inventory
        public void Initializer()
        {
            //TODO: Inicializar no app.xaml.cs

            List<ProductModel> products = productController.GetListProducts();

            foreach (ProductModel p in products)
                this.xcBProducts.Items.Add(p);            
        }

        // Add items selected in Cart 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductModel p = new ProductModel();

            //Get datas from form 
            p.Name = this.xcBProducts.SelectedItem.ToString();
            long amount = long.Parse(this.xtBAmount.Text);

            p.Id = productController.Search_Id_Products(p.Name); // Get Id Product | The query in inventoryDao.getAmountItem needs this property

            InventoryModel item = new InventoryModel(p, amount);

            salesController.AddItemsInCart(item, this.xlistBox);   
                       
        }
        private void xbtnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (salesController.Products != null)
                foreach (InventoryModel item in Cart.Products.Items)
                    this.buyController.BuyProduct(item);               
                             
        }
       
        //ViewList
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.historicView = new HistoricView();
            this.historicView.Show();
            this.historicView.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //this.salesController.ShowListOfItemsInBought();
            this.historicView.ShowListOfItemsBought();
            
        }

        private void xlistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void tBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void xBtnDelete_Click(object sender, RoutedEventArgs e)
        {
          InventoryModel item = (InventoryModel) this.xlistBox.SelectedItem;
            Cart.DeleteItemInCart(item);
        }

        private void xbtnClear_Click(object sender, RoutedEventArgs e)
        {
            Cart.ClearCart();
        }
    }
}
