using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CEDMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteSample2 : ContentPage
    {
        public SQLiteSample2()
        {
            InitializeComponent();
        }

        async private void btnInsert_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entCode.Text) && 
                !string.IsNullOrWhiteSpace(entName.Text) &&
                !string.IsNullOrWhiteSpace(entPrice.Text))
            {
                Product prod = new Product();
                prod.Code = entCode.Text;
                prod.Name = entName.Text;
                prod.Price = Convert.ToInt32(entPrice.Text);
                await App.DBUtil.InsertProductAsync(prod);
                entCode.Text = entName.Text = entCode.Text = string.Empty;
                proView.ItemsSource = await App.DBUtil.GetProductAsync();
            }
        }

        async private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            Product prod = new Product();
            prod.Code = entCode.Text;
            prod.Name = entName.Text;
            prod.Price = Convert.ToInt32(entPrice.Text);
            await App.DBUtil.UpdateProductAsync(prod);
            proView.ItemsSource = await App.DBUtil.GetProductAsync();
            entCode.Text = entName.Text = entCode.Text = string.Empty;
        }

        async private void btnDelete_Clicked(object sender, EventArgs e)
        {
            Product prod = new Product();
            prod.Code = entCode.Text;
            await App.DBUtil.DeleteProductAsync(prod);
            proView.ItemsSource = await App.DBUtil.GetProductAsync();
            entCode.Text = entName.Text = entCode.Text = string.Empty;
        }

        async private void btnShow_Clicked(object sender, EventArgs e)
        {
            proView.ItemsSource = await App.DBUtil.GetProductAsync();
        }

        private void proView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            entCode.Text = (((CollectionView)sender).SelectedItem as Product).Code;
            entName.Text = (((CollectionView)sender).SelectedItem as Product).Name;
            entPrice.Text = (((CollectionView)sender).SelectedItem as Product).Price.ToString("#,##0");
        }
    }
}