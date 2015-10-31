using SpeedyChefApi.Models;
using SpeedyChefAPIv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedyChefApi.Controllers
{
    public class StepsController : Controller
    {
        //
        // GET: /Steps/
        public ActionResult Index()
        {
            List<TaskMin> temp = new List<TaskMin>();
            TaskMin t1 = new TaskMin();
            t1.taskName = "First Step";
            t1.taskDesc = "Prepare all of your ingredients by chopping them up.";
            t1.taskTime = 10;
            temp.Add(t1);

            TaskMin t2 = new TaskMin();
            t2.taskName = "Second Step";
            t2.taskDesc = "Put the ingredients into a large casserole dish and make sure that they are spread out evenly.";
            t2.taskTime = 5;
            temp.Add(t2);

            TaskMin t3 = new TaskMin();
            t3.taskName = "Third Step";
            t3.taskDesc = "Put the casserole dish into your preheated oven and bake for 30 minutes.";
            t3.taskTime = 30;
            t3.taskTimeable = true;
            temp.Add(t3);

            TaskMin t4 = new TaskMin();
            t4.taskName = "Final Step";
            t4.taskDesc = "Remove dish from the oven and enjoy.";
            t4.taskTime = 1;
            temp.Add(t4);

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        // GET: /dbtest/
        public ActionResult dbtest()
        {
            SpeedyChefDataContext context = new SpeedyChefDataContext();
            string temp = context.Members.Select(m=>m.Memname).First();
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
	}
}