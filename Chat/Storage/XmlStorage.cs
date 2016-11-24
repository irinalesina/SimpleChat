using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Storage
{
    public class XmlStorage : IStorage
    {
        private static readonly int allMessagesCount = 20;
        private static readonly string storageUrl = "chatStorage.xml";
        
        private static List<Message> messages = new List<Message>();
        private static List<User> users = new List<User>();


        static XmlStorage()
        {
            XmlStorage.GetDataFromStorage();
        }


        public void AddUser(User user)
        {
            if (users.Find(m => m.UniqueName == user.UniqueName) != null)
                throw new InvalidOperationException("User with this name already exist!");
            XmlStorage.users.Add(user);
        }


        public User GetUserByUniqueName(string name)
        {
            return users.Find(u => u.UniqueName.CompareTo(name) == 0);
        }


        public List<Message> GetUserMessages(string userUniqueName)
        {
            return messages.FindAll(m => m.UserUniqueName.CompareTo(userUniqueName) == 0);
        }


        public List<Message> GetAllMessages()
        {
            messages.Sort(delegate (Message a, Message b) 
            {
                return a.AddDateTime.CompareTo(b.AddDateTime);
            });
            return messages;
        }


        public void AddMessage(Message message)
        {
            var allUserMessages = GetUserMessages(message.UserUniqueName);
            if (allUserMessages.Count == User.GetMessageCountToShow())
            {
                allUserMessages.Sort(delegate(Message a, Message b) { return a.AddDateTime.CompareTo(b.AddDateTime); });
                messages.Remove(allUserMessages.First());
            }
            messages.Add(message);
            XmlStorage.SaveChanges();
        }


        private static void SaveChanges()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Message>));

            using (FileStream fs = new FileStream(storageUrl, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, messages);
            }
        }


        private static void GetDataFromStorage()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Message>));

            using (FileStream fs = new FileStream(storageUrl, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    messages = (List<Message>)formatter.Deserialize(fs);
                    foreach (var message in messages.GroupBy(x => x.UserUniqueName))
                    {
                        XmlStorage.users.Add(new User() { UniqueName = message.Key });
                    }
                }
                   
            }
        }
    }
}
