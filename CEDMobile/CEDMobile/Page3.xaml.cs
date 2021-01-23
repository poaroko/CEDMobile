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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void sw1_Toggled(object sender, ToggledEventArgs e)
        {
            if(sw1.IsToggled)
            {
                lblSwitch.Text = "Switch On";
                lblSwitch.TextColor = Color.Green;
            }
            else
            {
                lblSwitch.Text = "Switch Off";
                lblSwitch.TextColor = Color.Red;
            }
        }
    }
}