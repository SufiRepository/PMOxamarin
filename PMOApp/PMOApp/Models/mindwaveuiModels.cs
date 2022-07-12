using System;
using System.Collections.Generic;
using System.Text;

namespace PMOApp.Models
{
    #region"Json"
    public class JsonResponse
    {
        public string Message { get; set; }
        public bool Result { get; set; }
    }
    #endregion"Json"

    #region"Login"
    public class User
    {
        public string staffuserid { get; set; }
        public string staffpassword { get; set; }
    }
    public class UserItem
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public string rank { get; set; }
        public string mobile_no { get; set; }
        public string companyIdx { get; set; }
        public string user_type { get; set; }
        public string usertype { get; set; }
        public string token { get; set; }

    }
    #endregion"Login"

    #region"ContentListview"
    public class ListContent
    {
        public string username { get; set; }
        public string contactno { get; set; }
        public string department { get; set; }
    }

    public class ObjListContent
    {
        public string username { get; set; }
        public string contactno { get; set; }
        public string department { get; set; }
    }
    #endregion"ContentListview"

    #region"CaroselView"
    public class ImageSlider
    {
        public string imageurl { get; set; }
        public string context { get; set; }
        public string textbutton { get; set; }
    }
    #endregion"CaroselView"

    #region"Department"
    public class Department
    {
        public string id { get; set; }
        public string departmentname { get; set; }
        
    }
    #endregion"Department"

    #region"ProjectList"
    public class ListProject
    {
        public string projectname { get; set; }
        public string contractno { get; set; }
        public string enddate { get; set; }
    }

    public class ObjListProject
    {
        public string projectname { get; set; }
        public string contactno { get; set; }
        public string enddate { get; set; }
    }
    #endregion"ProjectList"

    #region"IssueList"
    public class ListIssue
    {
        public string name { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }

    public class ObjListIssue
    {
        public string name { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }
    #endregion"IssueList"

    #region"TaskList"
    public class ListTask
    {
        public string taskname { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }

    public class ObjListTask
    {
        public string taskname { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }
    #endregion"TaskList"

    #region"SubTaskList"
    public class ListSubTask
    {
        public string subtaskname { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }

    public class ObjListSubTask
    {
        public string subtaskname { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }
    #endregion"SubTaskList"
}
