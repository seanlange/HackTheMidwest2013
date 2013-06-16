﻿using System;
using System.Collections.Generic;
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
                //USER_ID = Convert.ToInt32(Request.Cookies["userId"]),
            };

            var entities = new Hackathon_TestEntities();
            entities.VOTES.Add(vote);
            entities.SaveChanges();

            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult TopVotes()
        {
            var entities = new Hackathon_TestEntities();

            var votes = entities.VOTES
                .Include("Chant")
                .Take(200)
                .OrderByDescending(v => v.DATE_ADDED_DT_TM)
                .ToList();

            IList<TopVote> topVotes  = new List<TopVote>();

            foreach (var vote in votes)
            {
                var topVote = topVotes.FirstOrDefault(v => v.Chant == vote.Chant.CHANT_NAME);

                if (topVote == null)
                {
                    topVote = new TopVote {Chant = vote.Chant.CHANT_NAME};
                    topVotes.Add(topVote);
                }

                topVote.Count++;
            }

            return View(topVotes);
        }
    }

    public class TopVote
    {
        public string Chant { get; set; }
        public int Count { get; set; }
    }
}
