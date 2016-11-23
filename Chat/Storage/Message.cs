﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Storage
{
    [Serializable]
    public class Message
    {
        [XmlAttribute]
        public string Text { get; set; }
        [XmlIgnore]
        public DateTime AddDateTime { get; set; }

    }
}
