namespace Fooidity.Management.Web.Controllers
{
    using System.Web.Mvc;
    using Switching.Features;


    public class HomeController :
        Controller
    {
        readonly ICodeSwitch<Feature_NewScreen> _newScreenSwitch;

        public HomeController(ICodeSwitch<Feature_NewScreen> newScreenSwitch)
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