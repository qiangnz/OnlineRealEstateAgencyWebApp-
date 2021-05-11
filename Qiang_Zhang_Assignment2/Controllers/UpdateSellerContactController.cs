using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qiang_Zhang_Assignment2.Models;

namespace Qiang_Zhang_Assignment2.Controllers
{
    public class UpdateSellerContactController : Controller
    {
        // GET: UpdateSellerContact
        public ActionResult Index()
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            var seller = from e in db.SellerTables orderby e.SId select e;
            return View(seller);
        }

        public ActionResult SellerUpdated()
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            var seller = from e in db.SellerTables orderby e.SId select e;
            return View(seller);
        }

        public ActionResult SellerUpdatedFailed()
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            var seller = from e in db.SellerTables orderby e.SId select e;
            return View(seller);
        }



        public ActionResult updSeller(int ID, string emadd, String add)
        {
            OREDatabaseEntities1 db = new OREDatabaseEntities1();
            try
            {
                var seller = db.SellerTables.First(a => a.SId == ID);
                seller.EmailAddress = emadd;
                seller.Address = add;
                db.SaveChanges();

                return RedirectToAction("SellerUpdated");
            }
            catch (Exception)
            {
                return RedirectToAction("SellerUpdatedFailed");
            }
        }
    }
}







//public string updSeller(int ID, string emadd, String add)
//{
//    OREDatabaseEntities1 db = new OREDatabaseEntities1();
//    try
//    {
//        var seller = db.SellerTables.First(a => a.SId == ID);
//        seller.EmailAddress = emadd;
//        seller.Address = add;
//        db.SaveChanges();

//        return "Done";
//    }
//    catch (Exception)
//    {
//        return "Seller Does not Exists";
//    }
//}