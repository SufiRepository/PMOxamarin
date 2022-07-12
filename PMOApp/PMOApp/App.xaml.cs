using PMOApp.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp
{
    public partial class App : Application
    {
        static OfflineDatabase database;
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI4MTU0QDMxMzkyZTMzMmUzMGhlL2hsL3ZOejg4Y3VzSTJjMmZDK3BSVDBwZ0xMT0lZYk81UFZEMVB5Vk09");
            MainPage = new NavigationPage(new Views.MainLogin.MainLogin());
        }

        public static OfflineDatabase Database //CREATING DATABASE ON MOBILE
        {
            get
            {
                if (database == null)
                {
                    database = new OfflineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mindwaveuiapps.db3"));
                }
                return database;
            }
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
