using System.Linq;
using System.Web.Http;
using KcCauldronCapo.Model;

namespace KcCauldronCapo.Controllers
{
    public class LatestChantController : ApiController
    {
        [HttpGet]
        public Chant GetLatestChant()
        {
            var entities = new Hackathon_TestEntities();
            entities.Configuration.LazyLoadingEnabled = false;

            var chantHistory = entities
                .ChantHistories
                .Include("Chant")
                .OrderByDescending(c => c.CHANT_HISTORY_ID)
                .FirstOrDefault();

            if (chantHistory != null)
                return chantHistory.Chant;

            return null;
        }
    }
}
