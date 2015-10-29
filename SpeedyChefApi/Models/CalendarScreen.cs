using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedyChefApi.Models
{
    public class CalendarScreen
    {
    }

    public class Meal
    {

        /**
        * Name of meal. 
        **/ 
        public string mealName { get; set; }

        /**
        * List of recipes for a given day.
        * A meal can have as many recipes for a day.
        * The structure of the recipe object will be 
        * changed from a string or the defined 
        * class in this object.
        **/
        public List<string> recipes { get; set; }

        /**
        * The date the meal the user selected.
        * This should only be a date, no time included.
        **/
        public DateTime mealDate { get; set; }

        /**
        * Number of diners for the given meal
        **/
        public int diners { get; set; }

    }

    public class RecipeTemp
    {

        /**
        * Name of the recipe
        **/
        public string name { get; set; }

        /**
        * Description of recipe
        **/
        public string desc { get; set; }
    }

}