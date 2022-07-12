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

namespace PMOApp.Views.MainListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainListview : TabbedPage
    {
        public List<ListContent> ObjListContent;
        iRestServices RestServices = new iRestServices();
        public MainListview()
        {
            InitializeComponent();
            PopulateAllData();
            PopulateDataByCondition();
        }



        #region"PopulateData"
        private async void PopulateAllData()
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {
                   
                    ObjListContent = await RestServices.GetListContent();
                    if(ObjListContent.Count > 0)
                    {
                        MindListView.ItemsSource = ObjListContent;
                    }
                    else
                    {
                        MsgError.IsVisible = true;
                        MsgError.TextColor = Color.Red;
                        MsgError.Text = "No Record Available";
                    }

                }
                catch (Exception ex)
                {
                    await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Retrieve Data Error :", ex.Message), "Error");

                }
            }

        }

        private async void PopulateDataByCondition()
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {
                    ObjListContent = await RestServices.GetListContent();
                    var ObjCondition = ObjListContent.Where(p => p.department == "INFORMATION TECHNOLOGY");
                    if(ObjCondition != null)
                    {
                        MindListView2.ItemsSource = ObjCondition;
                    }
                    else
                    {
                        MsgError2.IsVisible = true;
                        MsgError2.TextColor = Color.Red;
                        MsgError2.Text = "No Record Available";
                    }

                }
                catch(Exception ex)
                {
                    await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Retrieve Data Error : ", ex.Message), "Error");
                }
            }
        }
        #endregion"PopulateData"

        #region"Button"
        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }

        private async void BtnBack2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }
        #endregion"Button"

        #region"Tapped"
        private async void TappedSelect(object sender, EventArgs e)
        {
            try
            {
                var obj = ((TappedEventArgs)e).Parameter;
                var selecteditem = obj as ListContent;
                var res = await DisplayAlert("Mindwave UI Apps","Display This Record?", "Yes", "No");
                if (res)
                {
                    await DisplayAlert("Mindwave UI Apps","Name : " + selecteditem.username + ". Department : " + selecteditem.department + " ","Okay");
                }
                else
                {
                    return; 
                }

            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Retrieve Data Error :", ex.Message), "Error");
            }
        }
        private async void TappedSelect2(object sender, EventArgs e)
        {
            try
            {
                var obj = ((TappedEventArgs)e).Parameter;
                var selecteditem = obj as ListContent;
                var res = await DisplayAlert("Mindwave UI Apps", "Display This Record?", "Yes", "No");
                if (res)
                {
                    await DisplayAlert("Mindwave UI Apps", "Name : " + selecteditem.username + ". Department : " + selecteditem.department + " ", "Okay");
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Retrieve Data Error :", ex.Message), "Error");
            }
        }
        #endregion"Tapped"

        #region"SearchBar"
        private void SearchContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            MsgError.IsVisible = false;
            if (ObjListContent != null)
            {
                string Criteria = e.NewTextValue.ToString().ToUpper();
                var Search = ObjListContent.Where(p => p.username.ToString().ToUpper().Contains(Criteria)
                || p.department.ToString().ToUpper().Contains(Criteria)
                || p.contactno.ToString().ToUpper().Contains(Criteria));
                MindListView.ItemsSource = Search;
            }
        }
        private void SearchContent2_TextChanged(object sender, TextChangedEventArgs e)
        {
            MsgError2.IsVisible = false;
            if (ObjListContent != null)
            {
                string Criteria = e.NewTextValue.ToString().ToUpper();
                var Search = ObjListContent.Where(p => p.username.ToString().ToUpper().Contains(Criteria)
                || p.department.ToString().ToUpper().Contains(Criteria) && p.department == "INFORMATION TECHNOLOGY"
                || p.contactno.ToString().ToUpper().Contains(Criteria));
                MindListView2.ItemsSource = Search;
            }
        }
        #endregion"SearchBar"
    }
}