using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qiang_Zhang_Assignment2.Models;

namespace Qiang_Zhang_Assignment2.Controllers
{
    public class DeleteHouseController : Controller
    {
        // GET: DeleteHouse
        public ActionResult Index()
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            var house = from e in db.PropertyTables orderby e.PId select e;
            return View(house);
        }

        public ActionResult PropertyDeleted()
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            var house = from e in db.PropertyTables orderby e.PId select e;
            return View(house);
        }

        public ActionResult PropertyDeletedFailed()
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            var house = from e in db.PropertyTables orderby e.PId select e;
            return View(house);
        }

        public ActionResult del(int ID)
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            try
            {
                PropertyTable property = db.PropertyTables.Find(ID);
                db.PropertyTables.Remove(property);
                db.SaveChanges();
                return RedirectToAction("PropertyDeleted");
            }
            catch (Exception)
            {
                return RedirectToAction("PropertyDeletedFailed");

            }
        }

        public ActionResult del1(string email)
        {
            OREDatabaseEntities1 db1 = new OREDatabaseEntities1();

                List<PropertyTable> pro = db1.PropertyTables.Where(x => x.Email == email).ToList();
  
                foreach (var i in pro)
                {
                    db1.PropertyTables.Remove(i);
                }

            bool listIsEmpty = !pro.Any();
            if (listIsEmpty)
            {
                return RedirectToAction("PropertyDeletedFailed");
            }
            else
            {
                db1.SaveChanges();
                return RedirectToAction("PropertyDeleted");
            }          
        }
    }
}
