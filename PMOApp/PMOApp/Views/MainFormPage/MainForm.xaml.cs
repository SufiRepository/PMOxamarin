using Acr.UserDialogs;
using PMOApp.Data;
using PMOApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainFormPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainForm : ContentPage
    {
        private List<Department> ObjCboDepartment = null;
        public MainForm()
        {
            InitializeComponent();
            PopulateCbo();
            EntUserName .TextChanged += EntUserHasErrorCheck;
            EntIcNo .Completed += EntIcNoHasErrorCheck;
            EntPhoneNumber .TextChanged += EntPhoneHasErrorCheck;
            EntBloodType .TextChanged += EntBloodTypeHasErrorCheck;
        }

        #region"TextErrorCheck"
        private void EntUserHasErrorCheck(object sender, EventArgs e)
        {
            UName .HasError = false;
        }

        private void EntIcNoHasErrorCheck(object sender, EventArgs e)
        {
            icnum .HasError = false;
        }

        private void EntPhoneHasErrorCheck(object sender, EventArgs e)
        {
            fonnum.HasError = false;
        }
        private void EntBloodTypeHasErrorCheck(object sender, EventArgs e)
        {
            blodtyp .HasError = false;
        }
        #endregion"TextErrorCheck"

        #region"PopulateCBO"
        public async void PopulateCbo()
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {
                    var RestService = new iRestServices();
                    ObjCboDepartment = await RestService.GetListDepartment();
                    if (ObjCboDepartment != null)
                    {
                        CboDepartment.DisplayMemberPath = "departmentname";
                        CboDepartment.DataSource = ObjCboDepartment;
                    }
                }
                catch(Exception ex)
                {
                    await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Retrieve Data Error : ", ex.Message), "Error");

                }
            }
                

        }
        #endregion"PopulateCBO"

        #region"SelectedIndexChange"
        public void CboDepartment_SelectionChanged(object  sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {

        }
        #endregion"SelectedIndexChange"

        #region"Button"
        public async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }
        public async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {
                    if (Validation())
                    {
                        var Register = await DisplayAlert("Mindwave UI Apps", "Are you sure you want to register " + EntUserName.Text + " ?", "Yes", "Cancel");
                        if (Register)
                        {
                            await DisplayAlert("Mindwave UI Apps", "Registration Success!", "Okay");
                        }
                        else
                        {
                            return;
                        }
                    }
                     
                    
                }
                catch(Exception ex)
                {
                    await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Register Failed : ", ex.Message), "Error");

                }
            }
                
        }
        #endregion"Button"

        #region"Validate"
        public bool Validation()
        {
            bool res = true;

            if(EntUserName.Text == null || string.IsNullOrEmpty(EntUserName.Text) || string.IsNullOrWhiteSpace(EntUserName.Text))
            {
                UName.HasError = true;
                UName.ErrorText = "Fill Up User Name";
                res = false;
            }

            if (EntIcNo.Text == null || string.IsNullOrEmpty(EntIcNo.Text) || string.IsNullOrWhiteSpace(EntIcNo.Text))
            {
                icnum.HasError = true;
                icnum.ErrorText = "Fill Up Ic Number";
                res = false;
            }

            if (EntPhoneNumber.Text == null || string.IsNullOrEmpty(EntPhoneNumber.Text) || string.IsNullOrWhiteSpace(EntPhoneNumber.Text))
            {
                fonnum.HasError = true;
                fonnum.ErrorText = "Fill Up Phone Number";
                res = false;
            }

            if (EntBloodType.Text == null || string.IsNullOrEmpty(EntBloodType.Text) || string.IsNullOrWhiteSpace(EntBloodType.Text))
            {
                blodtyp.HasError = true;
                blodtyp.ErrorText = "Fill Up Blood Type";
                res = false;
            }

            return res;
        }
        #endregion"Validates"
    }
}