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
            Models.Member member = new Models.Member();
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            member.memname = SCDC.Members.Where(m => m.Memname == user).Select(m => m.Memname).First();
            member.allergens = new List<Allergen>();
            foreach (var allergen in SCDC.Member_Allergens.Where(m => m.Memname == member.memname))
            {
                FoodItem item = new FoodItem { FoodName = allergen.Foodname };
                member.allergens.Add(new Allergen { FoodItem = item });
            }
            member.groups = new List<Models.Member_Group>();
            foreach (var group in SCDC.Member_Groups.Where(m => m.Groupadmin == member.memname))
            {
                member.groups.Add(new Models.Member_Group { Name = group.Groupname, adminName = member.memname });
            }
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = member;
            return json;
        }
    }
}