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
    
    public class ChatController : ApiController
    {
        Storage.XmlStorage chatStorage = new Storage.XmlStorage();

        
        [HttpGet]
        public List<Message> GetAllUsersMessages()
        {
            return chatStorage.GetAllMessages();
        }
        

        [HttpPost]
        public void AddNewUserMessage(MessageViewModel sendMessage)
        {
            chatStorage.AddMessage(new Message() { UserUniqueName = sendMessage.UserUniqueName, Text = sendMessage.Text, AddDateTime = sendMessage.AddDateTime });
        }
    }
}
