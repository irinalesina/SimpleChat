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
        Storage.Storage chatStorage = new Storage.Storage();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserMessages()
        {
            var userMessages = chatStorage.GetUserMessages(new User()); //change new User to user from cookie
            return View();
        }

        public ActionResult AllUsersMesages()
        {
            var allMessages = chatStorage.GetAllMessages();
            return View();
        }

        [HttpGet]
        public ActionResult DetermineUser()
        {
            return PartialView("DetermineUserPopup", new User());
        }

    }

}