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
        Storage.Storage chatStorage = new Storage.Storage();

        
        [HttpGet]
        public List<Message> GetAllUsersMessages()
        {
            return chatStorage.GetAllMessages();
        }
        
        [HttpPost]
        public void AddNewUserMessage(MessageViewModel sendMessage)
        {
            chatStorage.AddMessage(chatStorage.GetUserByUniqueName(sendMessage.UserUniqueName), new Message() { Text = sendMessage.Text, AddDateTime = sendMessage.AddDateTime });
        }
    }
}
