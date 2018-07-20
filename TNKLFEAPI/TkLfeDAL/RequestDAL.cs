using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TkLfeModel;

namespace TkLfeDAL
{
    public class RequestDAL
    {
        public static DataSet GetRequests()
        {
            DataSet ds = new DataSet();
            DBProvider dbProvider = new DBProvider();
            ds = dbProvider.ExecuteDataset("TkLfRequestList");
            return ds;
        }

        public static DataSet GetRequests(int id)
        {
            DataSet ds = new DataSet();
            DBProvider dbProvider = new DBProvider();
            dbProvider.AddParam("Id", id);
            ds = dbProvider.ExecuteDataset("TkLfRequestById");
            return ds;
        }

        public static int UpdateRequest(TnkLfeRequest request)
        {
            DBProvider dbProvider = new DBProvider();
            dbProvider.AddParam("Id",request.Id);
            dbProvider.AddParam("Summary", request.Summary);
            dbProvider.AddParam("Description", request.Description);
            int affctedRows = dbProvider.ExcuteStoredProcedure("TkLfRequestUpdate");
            return affctedRows;
        }
    }
}
