using Product.Inventory.Controller;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using Product.Inventory;
using Product.Inventory.Dao.models;

namespace Product.Inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProductController productController;

        public InventoryController inventoryController;

        public SalesController salesController;

        public BuyController buyController;  

        public MainWindow()
        {
            InitializeComponent();

            this.productController = new ProductController(this);
            this.inventoryController = new InventoryController(this);
            this.salesController = new SalesController(this);
            this.buyController = new BuyController(this);     

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

        // Add items selected in cart 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {                  
            salesController.AddItemInCart();
            
        }

        private void xlistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("selecionado");
        }

        private void tBAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void xbtnBuy_Click(object sender, RoutedEventArgs e)
        {                     
        if(salesController.Products!=null)
            foreach(InventoryModel item in salesController.Products.Items)            
                buyController.BuyProducts(item);
                             
        }
    }
}
