using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qiang_Zhang_Assignment2.Models;

namespace Qiang_Zhang_Assignment2.Controllers
{
    public class SellerRegistrationController : Controller
    {
        // GET: SellerRegistration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addNewSeller([Bind(Include = "FirstName,LastName,Address,PhoneNumber,EmailAddress")] SellerTable SellerRegistration)
        {
            using (OREDatabaseEntities1 db = new OREDatabaseEntities1())
            {
                db.SellerTables.Add(SellerRegistration);
                db.SaveChanges();
            }
            return View(SellerRegistration);
        }

        public string regSeller(SellerTable model)
        {
            try
            {
                OREDatabaseEntities1 db1 = new OREDatabaseEntities1();
                db1.SellerTables.Add(model);
                db1.SaveChanges();
                return "Done";
            }
            catch
            {
                return "Invalid";
            }
        }

    }
}