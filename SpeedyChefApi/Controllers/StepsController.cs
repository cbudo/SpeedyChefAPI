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
        public List<string> Index()
        {
            List<string> temp = new List<string>();
            temp.Add("Step 1");
            temp.Add("Step 2");
            temp.Add("Step 3");
            return temp;
        }
	}
}