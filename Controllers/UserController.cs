using System;
using System.Web;
using System.Web.Mvc;
using KcCauldronCapo.Model;

namespace KcCauldronCapo.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string number, string section)
        {
            var user = new User
            {
                DATE_ADDED_DT_TM = DateTime.Now,
                PHONE_NUMBER = number,
                SECTION = section,
            };

            var entities = new Hackathon_TestEntities();
            entities.Users1.Add(user);
            entities.SaveChanges();

            Response.Cookies.Add(new HttpCookie("userId", user.USER_ID.ToString()));
            Response.Cookies.Add(new HttpCookie("number", number));
            Response.Cookies.Add(new HttpCookie("section", section));

            return View("Index");
        }
    }
}
