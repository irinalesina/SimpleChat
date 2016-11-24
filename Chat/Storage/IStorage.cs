using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    interface IStorage
    {
        void AddUser(User user);
        List<Message> GetUserMessages(string user);
        List<Message> GetAllMessages();
        void AddMessage(Message message);
    }
}
