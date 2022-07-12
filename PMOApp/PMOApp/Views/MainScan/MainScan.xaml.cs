using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace PMOApp.Views.MainScan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScan : ContentPage
    {
        public MainScan()
        {
            InitializeComponent();
        }

        #region"Button"
        private async void btnBack_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }
        private void BtnScan_Click(object sender, EventArgs args)
        {
            ScanFunction();
        }
        #endregion"Button"

        #region"ScanFunction"
        public async void  ScanFunction()
        {
            var mobilescanner = new MobileBarcodeScanner();
            try
            {
                var scan = new ZXingScannerPage();
                scan.OnScanResult += (resultscan) =>
                {
                    scan.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                        var res = await DisplayAlert("Mindwave UI Apps", "View This QR or Barcode Data?", "Yes", "Cancel");
                        if (res)
                        {
                            await DisplayAlert("Mindwave Ui Apps", "Data is : "+resultscan.Text +"","Okay");
                        }
                        else
                        {
                            return;
                        }
                    });
                };
                await Navigation.PushAsync(scan);
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Problem to retrieve data:", ex.Message), "Error");

            }

        }
        #endregion"ScanFunction"
    }
}