using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Storage
{
    public class User
    {
        private static readonly int messagesCount = 10;
        public string UniqueName { get; set; }
        public string Password { get; set; }
        private Queue<Message> messages;

        public User()
        {
            messages = new Queue<Message>();
        }

        public List<Message> GetMessages()
        {
            return messages.ToList();
        }
        public void AddMessage(Message message)
        {
            if (messages.Count == User.messagesCount)
            {
                messages.Dequeue();
            }
            messages.Enqueue(message);
        }
    }
}
