using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Storage
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime AddDateTime { get; set; }

    }
}
