using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Acr.UserDialogs;
using PMOApp.Data;
using PMOApp.Models;

namespace PMOApp.Views.ProjectDashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectDashboard : TabbedPage
    {
        public List<ListTask> ObjListTask;
        public List<ListIssue> ObjListIssue;
        iRestServices RestServices = new iRestServices();
        public ProjectDashboard()
        {
            InitializeComponent();
            PopulateAllData();
        }

        #region"Button"
        private async void btnBackTab1_Click(object sender, EventArgs e)
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

        #region"Tapped"
        private async void TappedSelect(object sender, EventArgs e)
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
            if (ObjListTask != null)
            {
                string Criteria = e.NewTextValue.ToString().ToUpper();
                var Search = ObjListTask.Where(p => p.taskname.ToString().ToUpper().Contains(Criteria)
                || p.status.ToString().ToUpper().Contains(Criteria)
                || p.priority.ToString().ToUpper().Contains(Criteria));
                ListTaskView.ItemsSource = Search;
            }
        }
        private void SearchContent_TextChanged2(object sender, TextChangedEventArgs e)
        {
            MsgError2.IsVisible = false;
            if (ObjListIssue != null)
            {
                string Criteria = e.NewTextValue.ToString().ToUpper();
                var Search = ObjListIssue.Where(p => p.name.ToString().ToUpper().Contains(Criteria)
                || p.status.ToString().ToUpper().Contains(Criteria)
                || p.priority.ToString().ToUpper().Contains(Criteria));
                ListIssueView.ItemsSource = Search;
            }
        }
        #endregion"SearchBar"

        #region"PopulateData"
        private async void PopulateAllData()
        {
            using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
            {
                try
                {

                    ObjListTask = await RestServices.GetListTask();
                    if (ObjListTask.Count > 0)
                    {
                        ListTaskView.ItemsSource = ObjListTask;
                    }
                    else
                    {
                        MsgError.IsVisible = true;
                        MsgError.TextColor = Color.Red;
                        MsgError.Text = "No Record Available";
                    }

                    ObjListIssue = await RestServices.GetListIssue();
                    if (ObjListIssue.Count > 0)
                    {
                        ListIssueView.ItemsSource = ObjListIssue;
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
    }
}