using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TkLfeBAL;
using TkLfeModel;

namespace TNKLFEAPI.Controllers
{
    public class RequestController : ApiController
    {

        public List<TnkLfeRequest> Get()
        {
           RequestBL requestBL = new RequestBL();
           return requestBL.GetRequests();
        } 
        public TnkLfeRequest Get(int id)
        {
            RequestBL requestBL = new RequestBL();
            return requestBL.GetRequest(id);
        }
        [HttpPut]
        public string UpdateRequest(TnkLfeRequest request)
        {
            RequestBL requestBL = new RequestBL();
            return Convert.ToString(requestBL.UpdateRequest(request));
        }
    }
}
