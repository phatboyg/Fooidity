namespace Fooidity.Management.Web.Controllers
{
    using System.Web.Mvc;
    using Features;


    public class HomeController :
        Controller
    {
        readonly CodeSwitch<Feature_NewScreen> _newScreenSwitch;

        public HomeController(CodeSwitch<Feature_NewScreen> newScreenSwitch)
        {
            _newScreenSwitch = newScreenSwitch;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            if (_newScreenSwitch.Enabled)
                ViewBag.Title += " - New Screen Enabled";

            return View();
        }
    }
}