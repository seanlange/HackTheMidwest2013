using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KcCauldronCapo.Model;
using Twilio;
using System.Web.Configuration;


namespace KcCauldronCapo.Controllers
{
    public class SubmissionController : Controller
    {

        [HttpPost]
        public ActionResult SubmitSong(string message)
        {
            var userID = Request.Cookies["userId"].Value;


            var userSubmission = new USER_SUBMITTED_IDEAS
            {
                SUBMISSION_DT_TM = DateTime.Now,
                USER_ID = Convert.ToInt32(userID),
                LYRICS = message

            };

            var entities = new Hackathon_TestEntities();
            entities.USER_SUBMITTED_IDEAS.Add(userSubmission);
            entities.SaveChanges();

            var submissionList = entities
                .USER_SUBMITTED_IDEAS
                .ToList();

            return View("Index", submissionList);
        }


        [HttpGet]
        public ActionResult Index()
        {
            var entities = new Hackathon_TestEntities();
            entities.Configuration.LazyLoadingEnabled = false;

            var submissionList = entities
                .USER_SUBMITTED_IDEAS
                .ToList();

            return View(submissionList);
        }
    }
}
