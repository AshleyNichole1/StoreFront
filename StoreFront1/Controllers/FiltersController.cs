using StoreFront.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

using PagedList;
using PagedList.Mvc;


namespace StoreFront1.Controllers
{
    public class FiltersController : Controller
    {
        private StoreFrontEntities1 db = new StoreFrontEntities1();

        // GET: Filters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeadPhoneQS(string searchFilter, string CategoryFilter)
        {
            #region Without Category DDL
           
            if (string.IsNullOrEmpty(searchFilter))
            {
                var headphone = db.HeadPhoneStores;
                return View(headphone.ToList());

            }
       
            else
            {
                
                var searchResults = db.HeadPhoneStores.Where(h => h.Description.Contains(searchFilter));          
                return View(searchResults);
            }
            #endregion
            


        }

        public ActionResult HeadPhonePaging(string searchString, int page = 1)
        {

            int pageSize = 5;

            var headphone = db.HeadPhoneStores.OrderBy(x => x.HeadPhoneType).ToList();

            #region Search
            if (!String.IsNullOrEmpty(searchString))
            {
                headphone = headphone.Where(x => x.Description.Contains(searchString)).ToList();
            }

            ViewBag.SearchString = searchString;
            #endregion

           
            return View(headphone.ToList());
        }

    }
}