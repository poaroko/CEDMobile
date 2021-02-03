using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace CEDMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Essential : ContentPage
    {
        public Essential()
        {
            InitializeComponent();
            lblBatt.Text = (Battery.ChargeLevel*100).ToString();
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                // Do something
                GetLocation();
                return true; // True = Repeat again, False = Stop the timer
            });
        }

        async private void GetLocation()
        {
            try
            {
                Location location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblBatt.Text = "Latitude: " + location.Latitude.ToString();
                    lblBatt.Text += "Longitude:" + location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Location location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblBatt.Text = "Latitude: " + location.Latitude.ToString();
                    lblBatt.Text += "Longitude:" + location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
        }
    }
}