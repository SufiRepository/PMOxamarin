using Acr.UserDialogs;
using PMOApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMOApp.Data
{
    public class OfflineDatabase
    {
        readonly SQLiteAsyncConnection database;

        public OfflineDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserItemOffline>().Wait(); //THIS ONE MUST PUT EVERYTIME WE ADD NEW CLASS MODEL IF YOU WANT TO USE FOR OFFLINE VERSION.. THIS IS BECAUSE LOCAL DATABASE WILL CREATE THE TABLE FIRST.. IF NOT, APPS SAMPAH
            database.CreateTableAsync<ListContentOffline>().Wait();
            database.CreateTableAsync<sufi>().Wait();
        }

        #region"CRUDOPERATION"
        public Task<List<UserItemOffline>> GetContentList()
        {
            return database.Table<UserItemOffline>().ToListAsync();
        }
         



        public Task<List<UserItemOffline>> GetItemWithCondition(int _Id)
        {
            return database.QueryAsync<UserItemOffline>("SELECT * FROM [UserItemOffline] WHERE id  = " + _Id + "");
        }

        public Task<List<UserItemOffline>> GetContentListByCondition(string _ObjUsername)
        {
            return database.Table<UserItemOffline>().Where(i => i.username == _ObjUsername).ToListAsync();
        }
 
        public Task<int> DeleteItemAsync(UserItemOffline item)
        {
            return database.DeleteAsync(item);

        }

        public async Task<bool> CrudOperation(UserItemOffline itemObj, int idtask)
        {
            bool res = false;
            int resultC = 0;
            try
            {
                UserItemOffline objSelected = await database.Table<UserItemOffline>().Where(p => p.ID  == idtask).FirstOrDefaultAsync();
                if (objSelected == null)
                {
                    resultC = await Task.Run(() => database.InsertAsync(itemObj));
                }
                else
                {
                    itemObj.ID = objSelected.ID;
                    resultC = await Task.Run(() => database.UpdateAsync(itemObj));
                }

                if (resultC > 0)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("{0}{1}", "failed:", ex.Message), "Error");
            }
            return res;

        }
        #endregion"CRUDOPERATION"


    }
}
