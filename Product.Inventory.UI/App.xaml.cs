﻿using Product.Inventory.Dao.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace product_inventory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //this.Initializer();
        }
        public void Initializer()
        {
            //List<ProductModel> products = productController.GetListProducts();

            //foreach (ProductModel p in products)
            //    this.cBProducts.Items.Add(p);
        }
    }
}
