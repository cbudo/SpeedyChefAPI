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


        /**
        * Used to add recipe id to meal id in Meal_Recipes table.
        * Can be called in a loop to handle a list of recipes since 
        * It would be hard to make an array datatype for the database.
        * It is should only be called <strong>AFTER</strong> 
        * <i>MealNameExists</i> because a valid mealId will be passed back.
        * @param mealId - Integer that is a valid meal
        * @param recipeName - Name of recipe, which is assumed to be valid since
        *                     this is only called after MealNameExists
        * 
        * @return - Return value does not matter
        * 
        * @test - Refer to MealNameExisting
        **/ 
        private int PutRecipesWithMeal(int mealId, string recipeName)
        {
            if (recipeName == null)
            {
                return -1;
            }
            SpeedyChefDataContext scdc = new SpeedyChefDataContext();
            int result;
            result = scdc.AddRecipeToMeal(mealId, recipeName);
            return result;
        }

        /**
        * Method will take a list of the user's meal name for a day and size and put 
        * the information into the database, and then cycle through the list of 
        * recipe names and add them to the the meal in the appropriate table. If
        * the recipe exists with the meal and was included, it will stay with the meal. 
        * Eventually, if a recipe is not included with a meal, then it should be removed. 
        * (Soon to come if not implemented).
        *
        * @param user - Name of user creating meal
        * @param date - Date for meal to be created with (YYYY-MM-DD)
        * @param mealName - Name of meal to be created or updated
        * @param size - Size of meal
        * @param recipeNames - List of recipes that should be in the database. 
        *              <strong>NOTE</strong>: Be careful of spaces between recipes
        * 
        * @testing - /CalendarScreen/MealNameExisting?user=tester&date=2015-11-01&mealName=LastMinuteResort&size=5&recipeNames=Italian%20Pasta,Caesar%20Salad
        * @testing - /CalendarScreen/MealNameExisting?user=tester&date=2015-11-01&mealName=LastMinuteResort&size=5&recipeNames=Budo Budo
        **/
        public ActionResult MealNameExisting(string user, string date, string mealName, int size, string recipeNames)
        {
            if (user == null || date == null || mealName == null ){
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            SpeedyChefDataContext scdc = new SpeedyChefDataContext();
            int? returnValue = -1;
            int result = scdc.MealNameExists(user, date, mealName, size, ref returnValue);
            System.Diagnostics.Debug.WriteLine(recipeNames);
            if (recipeNames != null)
            {
                // Only time PutRecipeWithMeal should be called
                string[] list = recipeNames.Split(',');
                foreach (string keyword in list)
                {
                    System.Diagnostics.Debug.WriteLine(keyword);
                    int temp = PutRecipesWithMeal(returnValue.Value, keyword);
                    if (temp == -1)
                    {
                        System.Diagnostics.Debug.WriteLine("Oh god no");
                    }
                }

            }

            return Json(returnValue, JsonRequestBehavior.AllowGet);
        }
    }
}