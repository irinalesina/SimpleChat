using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebChat.Models.ViewModel;

namespace WebChat.Controllers
{
    public class UserController : ApiController
    {
        Storage.Storage chatStorage = new Storage.Storage();

        [HttpPost]
        public bool IsNameFree(UserViewModel user)
        {
            return chatStorage.GetUserByUniqueName(user.UniqueName) == null;
        }
    }
}
