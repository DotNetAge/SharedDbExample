using DNA.Web;
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

        [SiteDashboard(Text = "Products", Group = "Store")]
        public ActionResult List()
        {
            var ctx = new SharedDbContext();
            var ps = ctx.Products.ToList();
            ViewBag.Products = ps;
            return View();
        }

        [SiteDashboard]
        public ActionResult Detail(int id)
        {
            var ctx = new SharedDbContext();
            var ps = ctx.Products.FirstOrDefault(c => c.ID == id);
            //ViewBag.Products = ps;
            return View(ps);
        }


        [SiteDashboard]
        public ActionResult New() { return View(); }


        [SiteDashboard]
        public ActionResult Edit(int id)
        {
            var ctx = new SharedDbContext();
            var ps = ctx.Products.Find(id);
            return View(ps);
        }


        [HttpPost, SiteDashboard, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection foms)
        {
            if (ModelState.IsValid)
            {

                var ctx = new SharedDbContext();
                var ps = ctx.Products.Find(id);

                if (this.TryUpdateModel(ps))
                {

                    ctx.SaveChanges();
                }
                return RedirectToAction("Detail", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });
        }


        [HttpPost, SiteDashboard, ValidateAntiForgeryToken]
        public ActionResult New(Product product)
        {
            if (ModelState.IsValid)
            {
                var ctx = new SharedDbContext();
                ctx.Products.Add(product);
                ctx.SaveChanges();
                return RedirectToAction("Detail", new { id = product.ID });
            }
            return View();
        }

        [SiteDashboard, HttpPost]
        public ActionResult Delete(int id)
        {
            var ctx = new SharedDbContext();

            var ps = ctx.Products.FirstOrDefault(c => c.ID == id);

            ctx.Products.Remove(ps);
            ctx.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

