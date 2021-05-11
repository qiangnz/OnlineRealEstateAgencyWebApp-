using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qiang_Zhang_Assignment2.Models;

namespace Qiang_Zhang_Assignment2.Controllers
{
    public class SearchHouseController : Controller
    {
        // GET: SearchHouse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult search(string Suburb,string PropertyType)
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();

       
            List<PropertyTable> SearchHouse = db.PropertyTables.Where(x => x.Suburb==Suburb && x.PropertyType==PropertyType).ToList();

            return View(SearchHouse);
        }
    }
}