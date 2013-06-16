using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KcCauldronCapo.Model;
using Twilio;
using System.Web.Configuration;


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

            var AccountSid = WebConfigurationManager.AppSettings["AccountSid"];
            var AuthToken = WebConfigurationManager.AppSettings["AuthToken"];
            var fromNumber = WebConfigurationManager.AppSettings["FromNumber"];

            foreach(var user in userList)
            {
                var twilio = new TwilioRestClient(AccountSid, AuthToken);

                var formattedPhoneNumber = "+1" + user.PHONE_NUMBER;

                var textMsg = twilio.SendSmsMessage(fromNumber, formattedPhoneNumber, message, "");
 
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
