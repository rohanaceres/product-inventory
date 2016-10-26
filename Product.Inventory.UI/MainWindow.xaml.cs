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
            ProductModel p = new ProductModel();

            //Get datas from form 
            p.Name = this.xcBProducts.SelectedItem.ToString();

            long amount = long.Parse(this.xtBAmount.Text);

            //It validates input in amount
            //if (!IntegerUtils.OnlyInteger(this.xtBAmount.Text))
            //{
            //    MessageBox.Show("Apenas números");
            //}

            p.Id = productController.Search_Id_Products(p.Name); // Get Id Product | The query in inventoryDao.getAmountItem needs this property

            InventoryModel itemNovo = new InventoryModel(p, amount); // Item created with form information(ComboBox and TextBox)

            salesController.AddItemInCart(itemNovo);
            
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
            // TODO: verifica estoque
            //Verifica no banco o que é necessário
            buyController.BuyProducts();
        }
    }
}
