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
        public static int GetMessageCountToShow()
        {
            return messagesCount;
        }
    }
}
