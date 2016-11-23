using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Storage
{
    [Serializable]
    public class User
    {
        private static readonly int messagesCount = 10;
        [XmlAttribute]
        public string UniqueName { get; set; }

        private Queue<Message> messages = new Queue<Message>();

        [XmlArray("Messages")]
        [XmlArrayItem("Message", typeof(Message))]
        public List<Message> Messages
        {
            get
            {
                return messages.ToList();
            }
            set
            {
                messages = new Queue<Message>(value);
            }
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
