using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainImageSlider
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainImageSlider : ContentPage
    {
        public MainImageSlider()
        {
            InitializeComponent();
            
        }


        #region"Button"
        private async void btnBack_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }

        private async void BtnOpen_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mindwave Ui Apps","You can put any link or anything you want after click this button.","Okay");
        }
        #endregion"Button"
    }
}