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

namespace PMOApp.Views.TaskDashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDashboard : TabbedPage
    {

        public List<ListSubTask> ObjListSubTask;
        iRestServices RestServices = new iRestServices();
        public TaskDashboard()
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

                    ObjListSubTask = await RestServices.GetListSubTask();
                    if (ObjListSubTask.Count > 0)
                    {
                        ListTaskView.ItemsSource = ObjListSubTask;
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
        #endregion"Tapped"

        #region"SearchBar"
        private void SearchContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            MsgError.IsVisible = false;
            if (ObjListSubTask != null)
            {
                string Criteria = e.NewTextValue.ToString().ToUpper();
                var Search = ObjListSubTask.Where(p => p.subtaskname.ToString().ToUpper().Contains(Criteria)
                || p.status.ToString().ToUpper().Contains(Criteria)
                || p.priority.ToString().ToUpper().Contains(Criteria));
                ListTaskView.ItemsSource = Search;
            }
        }

        #endregion"SearchBar"

    }


}