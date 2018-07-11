using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using TNKLFEAPI.Models;
using TkLfeModel;
using TkLfeBAL;

namespace TNKLFEAPI.Controllers
{
    public class UserController : ApiController
    {
       
        public List<User> GetUsers()
        {
            UserBL userBL = new UserBL();
            return userBL.GetUsers();
        }
    }
}