using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedyChef.Controllers
{
    public class StepsController : Controller
    {
        //
        // GET: /Steps/
        public List<string> Get()
        {
           // string mealId = ""; //TODO get from request params
           // SpeedyChefDataContext SCDC = new SpeedyChefDataContext();
            List<String> temp = new List<string>();
            temp.Add("Step 1");
            temp.Add("Step 2");
            temp.Add("Step 3");
            return temp;
        }
	}
}