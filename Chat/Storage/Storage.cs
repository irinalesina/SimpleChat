using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Storage
{
    public class Storage : IStorage
    {
        private static readonly int allMessagesCount = 20;
        private static readonly string storageUrl = "chatStorage.xml";
        private static List<User> users = new List<User>();
        

        public Storage()
        {
            Storage.GetData();
        }


        public void AddUser(User user)
        {
            if (Storage.users.Find(u => u.UniqueName == user.UniqueName)== null)
                throw new InvalidOperationException("User with this name already exist!");
            Storage.users.Add(user);
            Storage.SaveChanges();
        }

        public User GetUserByUniqueName(string name)
        {
            return users.Find(u => u.UniqueName.CompareTo(name) == 0);
        }


        public List<Message> GetUserMessages(User user)
        {
            return user.GetMessages();
        }


        public List<Message> GetAllMessages()
        {
            List<Message> allMessages = new List<Message>();
            foreach (var user in Storage.users)
            {
                allMessages.AddRange(user.GetMessages());
            }
            allMessages.Sort(delegate (Message a, Message b) 
            {
                return a.AddDateTime.CompareTo(b.AddDateTime);
            });
            return allMessages.GetRange(0, allMessages.Count > allMessagesCount ? allMessagesCount : allMessages.Count);
        }


        public void AddMessage(User user, Message message)
        {
            user.AddMessage(message);
            Storage.SaveChanges();
        }


        private static void SaveChanges()
        {
            List<User> users;
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream(storageUrl, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Storage.users);
            }
        }


        private static void GetData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream(storageUrl, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                    Storage.users = (List<User>)formatter.Deserialize(fs);
            }
        }
    }
}
