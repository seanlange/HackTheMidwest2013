using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KcCauldronCapo.Model;


namespace KcCauldronCapo.Controllers
{
    public class AlertController : Controller
    {

        [HttpPost]
        public ActionResult SendMessage(string message)
        {

            var entities = new Hackathon_TestEntities();
            entities.Configuration.LazyLoadingEnabled = false;

            var userList = entities
                .Users1
                .ToList();

            foreach(var user in userList)
            {

            }

            return View("Index");
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
