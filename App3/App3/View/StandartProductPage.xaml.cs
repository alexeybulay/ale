﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using App7.DataAccess;
using App7.Model;
using App7.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StandartProductPage : ContentPage
    {
        public StandartProductPage()
        {
            InitializeComponent();

            #region AddProduct
            //using (var dbCon = new StandartProductDbContext())
            //{
            //    dbCon.Products.Add(new Product()
            //    {
            //        NameProduct = "Творог2",
            //        CalloriesProduct = 0,
            //        ProteinProduct = 12,
            //        FatsProduct = 14,
            //        CarbohytratesProduct = 155
            //    });
            //    dbCon.SaveChanges();
            //}
#endregion
            listProduct.ItemSelected += (s, e) =>
            {
                ((ListView) s).SelectedItem = null;

            };
            listProduct.ItemTapped += ListProduct_ItemTapped;
        }

        private async void ListProduct_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = (Product) e.Item;
            await Navigation.PushAsync(new StandartProductInfo(product.ProductId));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new StandartProductListViewModel();
        }
    }
}