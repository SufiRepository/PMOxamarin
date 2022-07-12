using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMOApp.Models
{
    #region"SnapImageClass"
    public class FileAttach
    {

        [PrimaryKey, AutoIncrement]
        public int idDB { get; set; }
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileTypeId { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        public string UrlPath { get; set; }
        public string ModifiedDate { get; set; }
        //public string ModBy { get; set; }
        public string ImageBinary { get; set; }
        public Boolean isEdit { get; set; }
        public int stat { get; set; }
    }
    #endregion"SnapImageClass"
    public class UserItemOffline
    {
        [PrimaryKey, AutoIncrement] //IMPORTANT TO PUT THIS FOR OFFLINE VERSION
        public int ID { get; set; } //ID IS PRIMARY KEY AND WILL SET AS AUTOINCREMENT
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

    public class ListContentOffline
    {
        [PrimaryKey, AutoIncrement] //IMPORTANT TO PUT THIS FOR OFFLINE VERSION
        public int ID { get; set; } //ID IS PRIMARY KEY AND WILL SET AS AUTOINCREMENT
        public string username { get; set; }
        public string contactno { get; set; }
        public string department { get; set; }
    }

    public class sufi
    {
        [PrimaryKey, AutoIncrement] //IMPORTANT TO PUT THIS FOR OFFLINE VERSION
        public int ID { get; set; } //ID IS PRIMARY KEY AND WILL SET AS AUTOINCREMENT

        public string namabetul { get; set; }
    }
}
