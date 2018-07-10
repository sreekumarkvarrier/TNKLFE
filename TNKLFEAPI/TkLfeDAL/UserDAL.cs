using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TkLfeDAL
{
    public class UserDAL
    {
        public static DataSet GetUsers()
        {
            DataSet ds = new DataSet();
            DBProvider dbProvider = new DBProvider();
            ds = dbProvider.ExecuteDataset("TkLfUserList");
            return ds;
        }
    }
}
