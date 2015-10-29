using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using SpeedyChefApi;
using System.Globalization;

namespace SpeedyChefApi.Controllers
{
    public class CalendarScreenController : Controller
    {
        // GET: /CalendarScreenController/
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: /CalendarScreenController/
        public void Post([FromBody]string value)
        {
        }

        // PUT: /CalendarScreenController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: /CalendarScreenController/5
        public void Delete(int id)
        {
        }


        public ActionResult Index()
        {
            return View();
        }

        /**
        * Used to call the stored procedure GetMealForDay
        * @param user - current user to get meals for 
        * @param date - String format of YYYY-MM-DD
        *               for day
        * 
        * @test - /CalendarScreen/GetMealDay?user=tester&date=2015-10-30
        **/
        public ActionResult GetMealDay(string user, string date)
        {
            if (user == null || date == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            SpeedyChefDataContext scdc = new SpeedyChefDataContext();
            IEnumerable<GetMealForDayResult> gmfdr = null;
            //System.Diagnostics.Debug.WriteLine(date);
            
            gmfdr = scdc.GetMealForDay(user, date);
            return Json(gmfdr, JsonRequestBehavior.AllowGet);
        }
    }
}