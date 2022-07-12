using PMOApp.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMOApp.Views.MainSubMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainSubMenu : MasterDetailPage
    {
        public MainSubMenu()
        {
            InitializeComponent();
            ShowSideBarAdmin();
        }
        public List<MasterPageItem> MenuList { get; set; }

        #region"MenuBar"
        private void ShowSideBarAdmin()
        {
            MenuList = new List<MasterPageItem>();
            var page1 = new MasterPageItem() { Title = "Dashboard", Icon = "home.png", TargetType = typeof(MainDashboard.MainDashboard) };
            var page2 = new MasterPageItem() { Title = "List of Projects", Icon = "viewlist.png", TargetType = typeof(ProjectList.ProjectList) };
            var page3 = new MasterPageItem() { Title = "Project Dashboard", Icon = "viewlist.png", TargetType = typeof(ProjectDashboard.ProjectDashboard) };
            var page4 = new MasterPageItem() { Title = "Task Dashboard", Icon = "viewlist.png", TargetType = typeof(TaskDashboard.TaskDashboard) };
            //var page2 = new MasterPageItem() { Title = "List View", Icon = "logout.png", TargetType = typeof(MainListView.MainListview) };
            //var page3 = new MasterPageItem() { Title = "QR/Bar Code Scanner", Icon = "logout.png", TargetType = typeof(MainScan.MainScan) };
            //var page4 = new MasterPageItem() { Title = "Tabbed Page", Icon = "logout.png", TargetType = typeof(MainTabPage.MainTabPage) };
            var page5 = new MasterPageItem() { Title = "Log Out", Icon = "logout.png", TargetType = typeof(MainLogin.MainLogin) };



            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            MenuList.Add(page5);

            navigationDrawerList.ItemsSource = MenuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainDashboard.MainDashboard)));

            this.BindingContext = new
            {

                Image = "logo.png", //logo
                Footer = "MIndwave UI",

            };
        }
        #endregion"MenuBar"

        #region"itemselected"
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            if (item.Title == "Log Out")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var res = await DisplayAlert("PMO APP", "Log Out?", "Yes", "No");

                    if (res)
                    {
                        //App.IsUserLoggedIn = false;
                        Application.Current.Properties.Clear();
                        Application.Current.MainPage = new NavigationPage(new MainLogin.MainLogin());

                    }
                    else
                    {
                        return;
                    }
                });
            }
            else if (item.Title == "Dashboard")
            {
                Detail = new NavigationPage(new MainDashboard.MainDashboard());
                IsPresented = false;
            }
            else if (item.Title == "List of Projects")
            {
                Detail = new NavigationPage(new ProjectList.ProjectList());
                IsPresented = false;
            }
            else if (item.Title == "Project Dashboard")
            {
                Detail = new NavigationPage(new ProjectDashboard.ProjectDashboard());
                IsPresented = false;
            }
            else if (item.Title == "Task Dashboard")
            {
                Detail = new NavigationPage(new TaskDashboard.TaskDashboard());
                IsPresented = false;
            }
            else if (item.Title == "List View")
            {
                Detail = new NavigationPage(new MainListView.MainListview());
                IsPresented = false;
            }
            else if (item.Title == "QR/Bar Code Scanner")
            {
                Detail = new NavigationPage(new MainScan.MainScan());
                IsPresented = false;
            }
            else if (item.Title == "Tabbed Page")
            {
                Detail = new NavigationPage(new MainTabPage.MainTabPage() );
                IsPresented = false;
            }
            

        }
        #endregion"itemselected"

        #region"Tapped"
        public void PilihTapped(object sender, EventArgs e)
        {

        }
        #endregion"Tapped"
    }
}