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

namespace PMOApp.Views.ProjectList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectList : ContentPage
    {
        public List<ListProject> ObjListProject;
        iRestServices RestServices = new iRestServices();
        public ProjectList()
        {
            InitializeComponent();
            PopulateAllData();
            
        }



        #region"PopulateData"
        private async void PopulateAllData()
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {

                    ObjListProject = await RestServices.GetListProject();
                    if(ObjListProject.Count > 0)
                    {
                        MindListView.ItemsSource = ObjListProject;
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
            if (ObjListProject != null)
            {
                string Criteria = e.NewTextValue.ToString().ToUpper();
                var Search = ObjListProject.Where(p => p.projectname.ToString().ToUpper().Contains(Criteria)
                || p.enddate.ToString().ToUpper().Contains(Criteria)
                || p.contractno.ToString().ToUpper().Contains(Criteria));
                MindListView.ItemsSource = Search;
            }
        }
        
        #endregion"SearchBar"
    }
}