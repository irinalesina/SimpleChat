using Storage;
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

        [HttpGet]
        public List<Message> GetAllMessages()
        {
            return chatStorage.GetAllMessages();
        }
        

        [HttpPost]
        public bool IsNameFreeAdd(UserViewModel user)
        {
            if (chatStorage.GetUserByUniqueName(user.UniqueName) == null)
            {
                chatStorage.AddUser(new Storage.User() { UniqueName = user.UniqueName });
                return true;
            }
            return false;
        }
    }
}
