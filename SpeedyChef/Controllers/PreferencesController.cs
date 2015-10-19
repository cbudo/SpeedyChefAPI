using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedyChef.Controllers
{
    public class PreferencesController : Controller
    {
        // GET: Preferences
        public ActionResult Index()
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            SCDC.Ovens.Where(m => m.Toolname == "");
            return View();
        }
    }
}