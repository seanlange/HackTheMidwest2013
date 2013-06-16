using System;
using System.Linq;
using System.Web.Mvc;
using KcCauldronCapo.Model;

namespace KcCauldronCapo.Controllers
{
    public class CapoController : Controller
    {
        public ActionResult Index()
        {
            var entities = new Hackathon_TestEntities();
            entities.Configuration.LazyLoadingEnabled = false;

            var chants = entities
                .CHANT_COUNT
                .OrderBy(c => c.CHANT_NAME)
                .ToList();

            return View(chants);
        }

        //
        // GET: /Capo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Capo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Capo/Create

        [HttpPost]
        public ActionResult Create(int chantId)
        {
            var entities = new Hackathon_TestEntities();

            var chantHistory = new ChantHistory
            {
                CHANT_ID = chantId,
                DATE_PLAYED_DT_TM = DateTime.Now,
            };

            entities.ChantHistories.Add(chantHistory);
            entities.SaveChanges();

            var chants = entities
            .CHANT_COUNT
            .OrderBy(c => c.CHANT_NAME)
            .ToList();

            return View("Index",chants);
        }

        [HttpPost]
        public ActionResult CreateAlert(string alert, string section)
        {
            return new EmptyResult();
        }

        //
        // GET: /Capo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Capo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Capo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Capo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
