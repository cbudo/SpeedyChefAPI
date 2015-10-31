using SpeedyChefApi.Models;
using SpeedyChefAPIv2;
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
            ViewBag.allergens = getAllAllergens().ToString();
            return View();
        }
        [HttpPost]
        public ActionResult Allergies(string tags)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Appliances(string ovens, string burners)
        {
            return RedirectToAction("Index");
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
        public JsonResult getGroups(string user, string pass)
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            var json = new JsonResult();
            json.Data = SCDC.Get_Groups(user, pass).ToList();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public JsonResult getAllergens(string user, string password)
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            var allergens = SCDC.GET_Allergens_User(user, password).ToList();
            var json = new JsonResult();
            json.Data = allergens;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public JsonResult getAllAllergens()
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            var json = new JsonResult();
            json.Data = SCDC.GET_Allergens().ToList();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public JsonResult addAllergen(string user, string password, string allergen)
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            var json = new JsonResult();
            SCDC.ADD_Allergy_User(user, password, allergen);
            json.Data = true;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public JsonResult setBurnerInfo(string user, string password, string toolId, string pwrType, string number)
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            var json = new JsonResult();
            try
            {
                SCDC.SET_StoveInfo(user, password, Convert.ToInt32(toolId), Convert.ToInt32(number), pwrType);
                json.Data = true;
            }
            catch
            {
                json.Data = false;
            }
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        public JsonResult getApplianceInfo(string user, string password)
        {
            SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            var json = new JsonResult();
            json.Data = SCDC.GET_ApplianceInfo(user, password).ToList();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}
