using Acr.UserDialogs;
using PMOApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PMOApp.Data
{
    public class iRestServices
    {
        public static string urlService = "http://192.168.213.135/emediaapi_core/api/"; //CONNECTION TO API. http://<url>/solutioname/route/
        public HttpClient _client = new HttpClient();

        #region"Login"
        public async Task<JsonResponse> LoginAsync(string Id, string Password)
        {
            JsonResponse Jrespon = new JsonResponse();
            try
            {

                User objUser = new User();
                objUser.staffuserid = Id;
                objUser.staffpassword = Password;
                var content = JsonConvert.SerializeObject(objUser);
                string url = string.Format("{0}{1}", urlService, "User/login"); //controller/context
                var resp = new StringContent(content, Encoding.UTF8, "application/json");
                var contentres = await _client.PostAsync(url, resp);
                if (contentres.IsSuccessStatusCode)
                {
                    string msgreturn = await contentres.Content.ReadAsStringAsync();
                    var obJJ = JsonConvert.DeserializeObject(msgreturn);
                    if (obJJ != null)
                    {
                        JObject jObject = JObject.Parse(msgreturn);
                        JToken jUser = jObject["Data"];

                        Jrespon.Result = bool.Parse(jObject["Result"].ToString());
                        Jrespon.Message = jObject["Message"].ToString();
                        if (Jrespon.Result)
                        {
                            jUser = jUser[0];
                            UserItem objuserLog = new UserItem()
                            {
                                user_id = jUser["user_id"].ToString(),
                                username = jUser["username"].ToString(),
                                password = jUser["password"].ToString(),
                                email = jUser["email"].ToString(),
                                status = jUser["status"].ToString(),
                                name = jUser["name"].ToString(),
                                rank = jUser["rank"].ToString(),
                                mobile_no = jUser["mobile_no"].ToString(),
                                companyIdx = jUser["companyIdx"].ToString(),
                                user_type = jUser["user_type"].ToString(),
                                usertype = jUser["usertype"].ToString(),
                                token = jUser["token"].ToString()



                            };

                            App.Current.Properties["UserId"] = objuserLog.user_id;
                            App.Current.Properties["UserName"] = objuserLog.username;
                            App.Current.Properties["Password"] = objuserLog.password;
                            App.Current.Properties["Email"] = objuserLog.email;
                            App.Current.Properties["Status"] = objuserLog.status;
                            App.Current.Properties["Name"] = objuserLog.name;
                            App.Current.Properties["Rank"] = objuserLog.rank;
                            App.Current.Properties["MobileNo"] = objuserLog.mobile_no;
                            App.Current.Properties["CompanyIdx"] = objuserLog.companyIdx;
                            App.Current.Properties["UserType"] = objuserLog.user_type;
                            App.Current.Properties["UserType"] = objuserLog.usertype;
                            App.Current.Properties["typeConn"] = 0;//online
                            App.Current.Properties["token"] = objuserLog.token;



                            //RunBackGroundGetList();
                            //RunDevicetoken();
                            //GetAllDevieToken();
                            return Jrespon;
                        }
                        else
                        {
                            return Jrespon;
                        }

                    }
                    else
                    {
                        Debug.WriteLine(@"\login successfully saved.");
                        Jrespon.Result = false;
                        Jrespon.Message = "Failed To Login";
                        return Jrespon;
                    }
                }
                else
                {
                    Jrespon.Result = false;
                    Jrespon.Message = "Failed To Login. Problem to connect with server. Please contact Jabatan Penerangan Admin";
                    return Jrespon;
                }


            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                Jrespon.Result = false;
                Jrespon.Message = "Failed To Login:" + errMsg;
                return Jrespon;
            }
        }
        #endregion"Login"

        #region"GetData"
        public async Task<List<ListContent>> GetListContent()
        {
            List<ListContent> ObjList = new List<ListContent>();
            try
            {
                ObjList.Add(new ListContent
                {
                    username = "IRWAN AHMAD",
                    department ="INFORMATION TECHNOLOGY",
                    contactno = "0125979748"
                });
                ObjList.Add(new ListContent
                {
                    username = "NORAZMAN SHAHABUDIN",
                    department = "INFORMATION TECHNOLOGY",
                    contactno = "0125656412"
                });
                ObjList.Add(new ListContent
                {
                    username = "AZNITA RAMLI",
                    department = "HUMAN RESOURCE",
                    contactno = "0125632478"
                });
                ObjList.Add(new ListContent
                {
                    username = "SHAMSUL AKRAM",
                    department = "MARKETING",
                    contactno = "0134632587"
                });
                ObjList.Add(new ListContent
                {
                    username = "AZIM AZMAN",
                    department = "INFORMATION TECHNOLOGY",
                    contactno = "0123542125"
                });
                ObjList.Add(new ListContent
                {
                    username = "SUFI YANG HILANG",
                    department = "HUMAN RESOURCE",
                    contactno = "0118974587"
                });
                ObjList.Add(new ListContent
                {
                    username = "FAREEZ SUBARU",
                    department = "MARKETING",
                    contactno = "0136569859"
                });
                ObjList.Add(new ListContent
                {
                    username = "LIYANA AHMAD SAFRI",
                    department = "HUMAN RESOURCE",
                    contactno = "0123565478"
                });
                ObjList.Add(new ListContent
                {
                    username = "FATIN BADERSHAH",
                    department = "INFORMATION TECHNOLOGY",
                    contactno = "0125645874"
                });

                
            }
            catch (Exception  ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Error :", ex.Message), "Error");
            }
            return ObjList;
        }
        #endregion"GetData"

        #region"GetListProject"
        public async Task<List<ListProject>> GetListProject()
        {
            List<ListProject> ObjList = new List<ListProject>();
            try
            {
                ObjList.Add(new ListProject
                {
                    projectname = "Nexus asset",
                    enddate = "10 JAN 2022",
                    contractno = "NXS034"
                });
                ObjList.Add(new ListProject
                {
                    projectname = "Pemasangan Kabel",
                    enddate = "5 FEB 2022",
                    contractno = "PTL112"
                });
                ObjList.Add(new ListProject
                {
                    projectname = "Pembelian Server",
                    enddate = "13 FEB 2022",
                    contractno = "PBS345"
                });
                ObjList.Add(new ListProject
                {
                    projectname = "DBP maintainance",
                    enddate = "9 JAN 2023",
                    contractno = "DBP098"
                });
                ObjList.Add(new ListProject
                {
                    projectname = "PMO testing",
                    enddate = "21 JAN 2022",
                    contractno = "PMO023"
                });



            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Error :", ex.Message), "Error");
            }
            return ObjList;
        }
        #endregion"GetListProject"

        #region"Insert/update"

        // ========== This one you can use for insert, update and delete. all you need is, just pas all the object in JSON format and API will do the function either insert delete update
        public async Task<JsonResponse> InsertUpdate(UserItem Objregister)
        {
            JsonResponse jRes = new JsonResponse();
            try
            {
                var content = JsonConvert.SerializeObject(Objregister);
                string url = string.Format("{0}{1}", urlService, "<controlleranme>/<route>");
                var TokenValue = commonModel.ParseString(App.Current.Properties["token"]);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenValue);
                var resp = new StringContent("[" + content + "]", Encoding.UTF8, "application/json");
                var contentres = await _client.PostAsync(url, resp); //method POST use for insert, update and delete.. makesure api also using HttpPost, if not, you will fuckup
                if (contentres.IsSuccessStatusCode)
                {
                    string msgreturn = await contentres.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject(msgreturn);
                    if (obj != null)
                    {
                        JObject jObject = JObject.Parse(msgreturn);
                        jRes.Message = jObject["Message"].ToString();
                        jRes.Result = bool.Parse(jObject["Result"].ToString());

                    }
                    else
                    {
                        jRes.Message = "Fail: Object return null";
                        jRes.Result = false;

                    }

                }
                else
                {
                    jRes.Message = "Fail to connect";
                    jRes.Result = false;
                }

            }
            catch (Exception ex)
            {
                jRes.Message = ex.Message.ToString();
                jRes.Result = false;
            }

            return jRes;

        }
        #endregion"Insert/update"

        #region"GetData"
        // ========== This one you can use for Get Data
        public async Task<List<ListContent>> GetList()
        {

            List<ListContent> ls = new List<ListContent>();
            try
            {
                bool res = false;
                string url = string.Format("{0}{1}", urlService, "Agencies/ListAgencies");
                var TokenValue = commonModel.ParseString(App.Current.Properties["token"]);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenValue);

                var resp = new StringContent("", Encoding.UTF8, "application/json");
                var contentres = await _client.GetAsync(url);//method GET use for get data.. makesure api also using HttpGet, if not, you will fuckup
                if (contentres.IsSuccessStatusCode)
                {
                    string msgreturn = await contentres.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject(msgreturn);
                    if (obj != null)
                    {
                        JObject jObject = JObject.Parse(msgreturn);
                        res = bool.Parse(jObject["Result"].ToString());
                        if (res)
                        {
                            //ls = JsonConvert.DeserializeObject<List<ListContent>>(jObject["Data"].ToString());
                            var lsobj = JsonConvert.DeserializeObject<List<ObjListContent>>(jObject["Data"].ToString());


                            foreach (ObjListContent Item in lsobj)
                            {
                                ListContent ObjSenAgency = new ListContent
                                {
                                    username = Item.username,
                                    contactno = Item.contactno,
                                    department = Item.department
                                };
                                ls.Add(ObjSenAgency);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            return ls;
        }
        #endregion"GetData"

        #region"GetDataDepartment"
        public async Task<List<Department>> GetListDepartment()
        {
            List<Department> ObjList = new List<Department>();
            try
            {
                ObjList.Add(new Department
                {
                    id = "1",
                    departmentname = "INFORMATION TECHNOLOGY"
                });
                ObjList.Add(new Department
                {
                    id = "2",
                    departmentname = "HUMAN RESOURCE"
                });
                ObjList.Add(new Department
                {
                    id = "3",
                    departmentname = "MARKETING"
                });
                ObjList.Add(new Department
                {
                    id = "4",
                    departmentname = "SALES"
                });
                 

            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Error :", ex.Message), "Error");
            }
            return ObjList;
        }
        #endregion"GetDataDepatment"

        #region"GetListTask"
        public async Task<List<ListTask>> GetListTask()
        {
            List<ListTask> ObjList = new List<ListTask>();
            try
            {
                ObjList.Add(new ListTask
                {
                    taskname = "task 1",
                    status = "Completed",
                    priority = "High"
                });
                ObjList.Add(new ListTask
                {
                    taskname = "task 2",
                    status = "Delayed",
                    priority = "Low"
                });
                ObjList.Add(new ListTask
                {
                    taskname = "task 3",
                    status = "Ongoing",
                    priority = "High"
                });
                ObjList.Add(new ListTask
                {
                    taskname = "task 4",
                    status = "Upcoming",
                    priority = "Medium"
                });
                ObjList.Add(new ListTask
                {
                    taskname = "task 5",
                    status = "Upcoming",
                    priority = "High"
                });
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Error :", ex.Message), "Error");
            }
            return ObjList;
        }
        #endregion"GetListTask"

        #region"GetListSubTask"
        public async Task<List<ListSubTask>> GetListSubTask()
        {
            List<ListSubTask> ObjList = new List<ListSubTask>();
            try
            {
                ObjList.Add(new ListSubTask
                {
                    subtaskname = "subtask 1",
                    status = "Completed",
                    priority = "High"
                });
                ObjList.Add(new ListSubTask
                {
                    subtaskname = "subtask 2",
                    status = "Delayed",
                    priority = "Medium"
                });
                ObjList.Add(new ListSubTask
                {
                    subtaskname = "subtask 3",
                    status = "Ongoing",
                    priority = "Low"
                });
                ObjList.Add(new ListSubTask
                {
                    subtaskname = "subtask 4",
                    status = "Upcoming",
                    priority = "High"
                });
                ObjList.Add(new ListSubTask
                {
                    subtaskname = "subtask 5",
                    status = "Upcoming",
                    priority = "Medium"
                });
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Error :", ex.Message), "Error");
            }
            return ObjList;
        }
        #endregion"GetListSubTask"

        #region"GetListIssue"
        public async Task<List<ListIssue>> GetListIssue()
        {
            List<ListIssue> ObjList = new List<ListIssue>();
            try
            {
                ObjList.Add(new ListIssue
                {
                    name = "Issue 1",
                    status = "Completed",
                    priority = "High"
                });
                ObjList.Add(new ListIssue
                {
                    name = "Issue 2",
                    status = "Completed",
                    priority = "High"
                });
                ObjList.Add(new ListIssue
                {
                    name = "Issue 3",
                    status = "Completed",
                    priority = "High"
                });
                ObjList.Add(new ListIssue
                {
                    name = "Issue 4",
                    status = "Completed",
                    priority = "High"
                });
                ObjList.Add(new ListIssue
                {
                    name = "Issue 5",
                    status = "Completed",
                    priority = "High"
                });
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "Error :", ex.Message), "Error");
            }
            return ObjList;
        }
        #endregion"GetListIssue"
    }
}
