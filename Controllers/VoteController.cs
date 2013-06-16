using System;
using System.Linq;
using System.Web.Mvc;
using KcCauldronCapo.Model;

namespace KcCauldronCapo.Controllers
{
    public class VoteController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var entities = new Hackathon_TestEntities();
            entities.Configuration.LazyLoadingEnabled = false;

            var chants = entities
                .CHANTS
                .OrderBy(c => c.CHANT_NAME)
                .ToList();

            return View(chants);
        }

        [HttpPost]
        public ActionResult AddVote(int chantId)
        {
            var vote = new Vote
            {
                CHANT_ID = chantId,
                DATE_ADDED_DT_TM = DateTime.Now,
                USER_ID = Convert.ToInt32(Request.Cookies["userId"]),
            };

            var entities = new Hackathon_TestEntities();
            entities.VOTES.Add(vote);
            entities.SaveChanges();

            return new EmptyResult();
        }
    }
}
