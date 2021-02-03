using System.Collections.Generic;
using Xamarin.Forms;

namespace CEDMobile
{
    public partial class CollectionV : ContentPage
    {
        public List<Monkey> Monkeys { get; private set; }
        public CollectionV()
        {
            InitializeComponent();

            Monkeys = new List<Monkey>();
            Monkeys.Add(new Monkey
            {
                Name = "Baboon"
            });

            BindingContext = this;
        }

        private void btnAdd_Clicked(object sender, System.EventArgs e)
        {
            Monkeys.Add(new Monkey
            {
                Name = entName.Text
            });
            BindingContext = this;
        }
    }
}