using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storage;

namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        XmlStorage chatStorage = new XmlStorage();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserMessages()
        {
            var userMessages = chatStorage.GetUserMessages("demo");
            return View();
        }

        public ActionResult AllUsersMesages()
        {
            var allMessages = chatStorage.GetAllMessages();
            return View();
        }
    }

}