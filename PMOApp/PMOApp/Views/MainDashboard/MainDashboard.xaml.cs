using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainDashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDashboard : ContentPage
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        #region"Button"
        public async void BtnPge_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainButtonPage.MainButton());
        }

        public  async void BtnForm_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainFormPage.MainForm());
        }
        public async void TabbePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainTabPage.MainTabPage());
        }
        public async void ScanPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainScan.MainScan());
        }
        public async void ListViewPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainListView.MainListview());
        }
        public async void ImageSlider_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainImageSlider.MainImageSlider());
        }

        public async void UploadImage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainUploadImage.MainUpload());
        }

        #endregion"Button"

        public async void ProjectList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectList.ProjectList());
        }
    }
}