using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models.ViewModel
{
    public class MessageViewModel
    {
        public string UserUniqueName { get; set; }

        public string Text { get; set; }

        public DateTime AddDateTime { get; set; }
        
    }
}