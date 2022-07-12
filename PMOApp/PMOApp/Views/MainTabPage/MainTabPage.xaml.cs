using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainTabPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabPage : TabbedPage
    {
        public MainTabPage()
        {
            InitializeComponent();

        }

        #region"Button"
        private async void btnBackTab1_Click(object  sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }

        private async void btnBackTab2_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }

        private async void btnBackTab3_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }
        #endregion"Button"
    }
}