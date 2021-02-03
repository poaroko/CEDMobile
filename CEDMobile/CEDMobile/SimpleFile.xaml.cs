using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CEDMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleFile : ContentPage
    {
        public SimpleFile()
        {
            InitializeComponent();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myfile.txt");
            StreamReader streamReader = new StreamReader(filename);
            string content = streamReader.ReadToEnd();
            lblContent.Text = lblContent.Text + content;
            streamReader.Close();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myfile.txt");
            StreamWriter streamWriter;
            if (!File.Exists(filename))
            {
                streamWriter = new StreamWriter(File.Create(filename));
                streamWriter.WriteLine(entContent.Text);
            }
            else
            {
                streamWriter = new StreamWriter(filename, true);
                streamWriter.WriteLine(entContent.Text);
            }
            streamWriter.Close();

            StreamReader streamReader = new StreamReader(filename);
            string content = streamReader.ReadToEnd();
            lblContent.Text = content;
            streamReader.Close();
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myfile.txt");
            if (File.Exists(filename))
            {
                StreamWriter streamWriter = new StreamWriter(filename, false);
                streamWriter.WriteLine(string.Empty);
                streamWriter.Close();
            }
            lblContent.Text = string.Empty;
        }
    }
}