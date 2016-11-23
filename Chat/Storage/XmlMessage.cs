using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    [Serializable]
    public class XmlMessage
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime AddDateTime { get; set; }
    }
}
