using System.Linq;
using System.Web.Mvc;

namespace SharedContextTest.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            var ctx = new SharedDbContext();
            var ps = ctx.Products.ToList();
            ViewBag.Products = ps;
            return View();
        }
    }
}

