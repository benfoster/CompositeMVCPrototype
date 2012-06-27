using System.Web.Mvc;
using CompositeMVC.Application;

namespace CompositeMVC.Controllers
{
    public class WidgetController : Controller
    {
        //
        // GET: /Widget/

        public ActionResult Index(string id)
        {
            var pageBuilder = new PageBuilder(new WidgetCatalog());
            var model = pageBuilder.BuildPage(id);
            return View(model);
        }

    }
}
