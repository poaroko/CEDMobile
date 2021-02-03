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
    public partial class SQLiteSample : ContentPage
    {
        public SQLiteSample()
        {
            InitializeComponent();
        }

        async private void btnInsert_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entStdCode.Text) && 
                !string.IsNullOrWhiteSpace(entStdName.Text))
            {
                Student std = new Student();
                std.Code = entStdCode.Text;
                std.Name = entStdName.Text;
                await App.DBUtil.InsertStudentAsync(std);
                entStdCode.Text = entStdName.Text = string.Empty;
                stdView.ItemsSource = await App.DBUtil.GetStudentAsync();
            }
        }

        async private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            Student std = new Student();
            std.Code = entStdCode.Text;
            std.Name = entStdName.Text;
            await App.DBUtil.UpdateStudentAsync(std);
            stdView.ItemsSource = await App.DBUtil.GetStudentAsync();
            entStdCode.Text = entStdName.Text = string.Empty;
        }

        async private void btnDelete_Clicked(object sender, EventArgs e)
        {
            Student std = new Student();
            std.Code = entStdCode.Text;
            std.Name = entStdName.Text;
            await App.DBUtil.DeleteStudentAsync(std);
            stdView.ItemsSource = await App.DBUtil.GetStudentAsync();
            entStdCode.Text = entStdName.Text = string.Empty;
        }

        async private void btnShow_Clicked(object sender, EventArgs e)
        {
            stdView.ItemsSource = await App.DBUtil.GetStudentAsync();
        }

        private void stdView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            entStdCode.Text = (((CollectionView)sender).SelectedItem as Student).Code;
            entStdName.Text = (((CollectionView)sender).SelectedItem as Student).Name;
        }
    }
}