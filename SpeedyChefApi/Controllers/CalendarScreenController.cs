using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using SpeedyChefApi;

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

        public ActionResult Calendar()
        {
            SpeedyChefDataContext context = new SpeedyChefDataContext();
            Member temp = context.Members.First();
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getUserCalendar(string user, DateTime date)
        {
            JsonResult json = new JsonResult();
            Models.Member member = new Models.Member();
            SpeedyChefDataContext scdc = new SpeedyChefDataContext();
            member.memname = scdc.Members.Where(m => m.Memname == user).Select(m=>m.Memname).First();
            // Don't exactly know what I am doing yet, but might as well get started.

            return json;
        }
    }
}