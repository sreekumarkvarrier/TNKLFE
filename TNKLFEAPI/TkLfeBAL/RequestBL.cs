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
    public class RequestBL
    {
        public List<TnkLfeRequest> GetRequests()
        {
            List<TnkLfeRequest> requets = new List<TnkLfeRequest>();
            DataSet ds = RequestDAL.GetRequests();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TnkLfeRequest requet = new TnkLfeRequest();
                    requet.Requester = Convert.ToString(dr["Requester"]);
                    requet.Summary = Convert.ToString(dr["Summary"]);
                    requet.Description = Convert.ToString(dr["Description"]);
                    requet.Id = Convert.ToInt32(dr["Id"]);
                    requets.Add(requet);
                }
            }
            return requets;
        }

        public bool UpdateRequest(TnkLfeRequest request)
        {
           int affectedRows = RequestDAL.UpdateRequest(request);
            if(affectedRows > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
             
        }

        public TnkLfeRequest GetRequest(int id)
        {
            DataSet ds = RequestDAL.GetRequests(id);
            TnkLfeRequest requet = new TnkLfeRequest();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    requet.Id = Convert.ToInt32(dr["Id"]);
                    requet.Requester = Convert.ToString(dr["Requester"]);
                    requet.Summary = Convert.ToString(dr["Summary"]);
                    requet.Description = Convert.ToString(dr["Description"]);
                   
                }
            }
            return requet;
        }
    }
}
