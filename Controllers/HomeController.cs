using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIP.Models;

namespace DIP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autorize(string email, string password)
        {
            FirstPageModel db = new FirstPageModel();
            Persons aut = db.GetUser(email);
            if (aut == null)
            {
                ViewBag.Answer = "No such user. Try again.";
                return View("Index");
            }

            if (aut.Password == password)
            {

                return View("MainWindow_cw");

            }
            else
            {


                ViewBag.Answer = "Password is incorect";
                return View("Index");
            }

            // id - имя клиента, заказы которого необходимо выводить на странице.
            // ViewBag.Answer = "No such user. Try again.";

        }
    }
}
