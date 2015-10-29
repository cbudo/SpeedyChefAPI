using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using SpeedyChefApi;
using System.Data.SqlClient;
using System.Data.Linq;


namespace SpeedyChefApi.Controllers
{
    public class SearchController : Controller
    {
        // GET: /Search/
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: /Search/
        public void Post([FromBody]string value)
        {
        }

        // PUT: /Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: /Search/5
        public void Delete(int id)
        {
        }

        public class SearchSingleComparer : IEqualityComparer<SearchSingleKeywordResult>
        {
            public bool Equals(SearchSingleKeywordResult x, SearchSingleKeywordResult y)
            {
                return x.Recid == y.Recid;
            }

            public int GetHashCode(SearchSingleKeywordResult obj)
            {
                return obj.Recid.GetHashCode();
            }
        }

        public ActionResult Search(string inputKeywords)
        {
            string[] keywordList = inputKeywords.Split(',');
            SpeedyChefDataContext scdc = new SpeedyChefDataContext();
            IEnumerable<SearchSingleKeywordResult> tempRes = null;
            if (keywordList == null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            foreach (string keyword in keywordList)
            {
                if (tempRes != null)
                {
                    tempRes = tempRes.Union(scdc.SearchSingleKeyword(keyword), new SearchSingleComparer());
                }
                else 
                {
                    IEnumerable<SearchSingleKeywordResult> firstRes = new List<SearchSingleKeywordResult>();
                    tempRes = firstRes.Union(scdc.SearchSingleKeyword(keyword), new SearchSingleComparer());

                }
            }
            return Json(tempRes, JsonRequestBehavior.AllowGet);
        }
    }
}