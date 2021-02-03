using System;
using Xamarin.Forms;
using System.IO;

namespace CEDMobile
{
    public partial class App : Application
    {
        static DatabaseUtil dbUtil;
        public static DatabaseUtil DBUtil
        {
            get
            {
                if (dbUtil == null)
                {
                    dbUtil = new DatabaseUtil(Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "sampleDB.db3"));
                }
                return dbUtil;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new SQLiteSample2();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
