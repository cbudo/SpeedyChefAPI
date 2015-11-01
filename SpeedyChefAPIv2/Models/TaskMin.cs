/* The client needs a subset of the database's information on a given task. This condensed model reduces the data transferred. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedyChefApi.Models
{
    public class TaskMin
    {
        public string taskName { get; set; }
        public string taskDesc { get; set; }
        public int taskTime { get; set; }
        public bool taskTimeable { get; set; }
    }
}