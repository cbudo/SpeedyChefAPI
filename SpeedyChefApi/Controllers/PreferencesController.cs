using SpeedyChefApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedyChefApi.Controllers
{
    public class PreferencesController : Controller
    {
        // GET: Preferences
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getUserProperties(string user)
        {
            JsonResult json = new JsonResult();
            Preferences prefs = new Preferences();
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            json.Data = prefs;
            return json;
        }
    }
}