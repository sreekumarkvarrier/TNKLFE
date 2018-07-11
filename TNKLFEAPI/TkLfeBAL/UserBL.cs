using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TkLfeDAL;
using TkLfeModel;

namespace TkLfeBAL
{
   public class UserBL
    {
        public List<User>  GetUsers()
        {
             List<User> users = new List<User>();
             DataSet ds = UserDAL.GetUsers();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    User usr = new User();
                    usr.Name = Convert.ToString(dr["Name"]);
                    usr.Id = Convert.ToString(dr["Id"]);
                    users.Add(usr);
                }
            }
            return users;
        }
        
    }
}
