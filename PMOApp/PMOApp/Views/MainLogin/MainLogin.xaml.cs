using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainLogin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainLogin : ContentPage
    {
        public MainLogin()
        {
            InitializeComponent();
            IdPengguna.Completed += PassWord_Trigger;
            IdPengguna.TextChanged += EntIdPenggunaHasErrorCheck;
            kataLaluan.TextChanged += EntPasswordHasErrorCheck;
        }


        #region"TextErrorCheck"
        private void EntIdPenggunaHasErrorCheck(object sender, EventArgs e)
        {
            FrameId.HasError = false;
        }

        private void EntPasswordHasErrorCheck(object sender, EventArgs e)
        {
            EntryPassword.HasError = false;
        }
        #endregion"TextErrorCheck"

        #region"Event Trigger"
        private void PassWord_Trigger(object sender, EventArgs e)
        {
            kataLaluan.Focus();

        }
        #endregion"Event Trigger"

        #region"Button"
        //public async void LogMasuk_Clicked(object sender, EventArgs e) //GUNA BILA DAH ADA WEB SERVICES
        //{
        //    using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
        //    {
        //        try
        //        {
        //            //Application.Current.MainPage = new Submenu.MainSubMenu();
        //            //await Navigation.PopToRootAsync();
        //            //await Navigation.PushAsync(new DashboardCarianAcara.DashCarianAcara());
        //            //await Navigation.PushAsync(new Submenu.MainSubMenu());
        //            if (validateLogin())
        //            {
        //                JsonResponse jRes = new JsonResponse();
        //                using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
        //                {

        //                    var objlogin = new iRestServices();
        //                    jRes = await Task.Run(() => objlogin.LoginAsync(IdPengguna.Text.ToString(), kataLaluan.Text));
        //                    if (jRes != null)
        //                    {
        //                        if (jRes.Result)
        //                        {
        //                            var obIdPegawai = IdPengguna.Text;
        //                            App.IsUserLoggedIn = true;
        //                            await Navigation.PushAsync(new DashboardCarianAcara.DashCarianAcara());
        //                        }
        //                        else
        //                        {
        //                            await DisplayAlert("eMedia", jRes.Message, "Okay");

        //                        }
        //                    }
        //                    else
        //                    {
        //                        await DisplayAlert("eMedia", "Katalaluan atau Id Pengguna anda salah", "Okay");
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                msgWrong.IsVisible = true;
        //                msgWrong.Text = "Sila masukkan Id Pengguna dan Katalaluan anda";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            await DisplayAlert("eMedia", ex.Message, "Okay");
        //        }
        //    }

        //}

        public async void LogMasuk_Clicked(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {
                    if (validateLogin())
                    {
                        Application.Current.MainPage = new MainSubMenu.MainSubMenu();
                        await Navigation.PopToRootAsync();
                        await Navigation.PushAsync(new MainDashboard.MainDashboard());
                        await Navigation.PushAsync(new MainSubMenu.MainSubMenu());
                    }
                        

                    //if (validateLogin())
                    //{
                    //    Application.Current.MainPage = new MainSubMenu.MainSubMenu();
                    //    await Navigation.PopToRootAsync();
                    //    await Navigation.PushAsync(new MainDashboard.MainDashboard());
                    //    await Navigation.PushAsync(new MainSubMenu.MainSubMenu());

                    //}
                    //else
                    //{
                    //    msgWrong.IsVisible = true;
                    //    msgWrong.Text = "Sila masukkan Id Pengguna dan Katalaluan anda";
                    //}
                }
                catch (Exception ex)
                {
                    await DisplayAlert("eMedia", ex.Message, "Okay");
                }
            }

        }
        #endregion"Button"

        #region"Validate"
        public bool validateLogin()
        {
            bool vell = true;
            if (IdPengguna.Text == null || string.IsNullOrEmpty(IdPengguna.Text))
            {
                FrameId.HasError = true;
                FrameId.ErrorText = "Fill Up ID Pengguna";
                vell = false;
                
            }
            if (kataLaluan.Text == null || string.IsNullOrEmpty(kataLaluan.Text))
            {
                EntryPassword.HasError = true;
                EntryPassword.ErrorText = "Fill Up Password";
                vell = false;
            }

            else
            {

                vell = true;
            }
            return vell;
        }
        #endregion"Validate"
    }
}