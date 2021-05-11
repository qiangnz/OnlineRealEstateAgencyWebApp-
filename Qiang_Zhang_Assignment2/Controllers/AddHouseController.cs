using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qiang_Zhang_Assignment2.Models;

namespace Qiang_Zhang_Assignment2.Controllers
{
    public class AddHouseController : Controller
    
    {
        // GET: AddHouse
        public ActionResult Index()
        {
            DropDownViewModel model = new DropDownViewModel();
            model.EmailAddressDropDownProperty = GetDetailFroDropDown();
            GetDetailFroDropDown();
            return View(model);
        }

        public ActionResult addNewHouse([Bind(Include ="Suburb,Location,NumberofRooms,PropertyType,FloorArea,LandArea,RV,Email")] PropertyTable AddHouse)
        {
            using (OREDatabaseEntities1 houseEntites = new OREDatabaseEntities1())
            {
                houseEntites.PropertyTables.Add(AddHouse);
                houseEntites.SaveChanges();
            }
            return View(AddHouse);
        }

        public string regHouse(PropertyTable model)
        {
            try
            {
                OREDatabaseEntities1 db1 = new OREDatabaseEntities1();
                db1.PropertyTables.Add(model);
                db1.SaveChanges();
                return "Done";
            }
            catch
            {
                return "Invalid";
            } 
        }

        public List<EmailAddressDropDown> GetDetailFroDropDown()
        {
            OREDatabaseEntities1 db2 = new OREDatabaseEntities1();
            List<EmailAddressDropDown> result = new List<EmailAddressDropDown>();

            var obj = db2.SellerTables.Select(s => s).ToList();
            if (obj!= null && obj.Count()>0)
            {
                foreach(var data in obj)
                {
                    EmailAddressDropDown model = new EmailAddressDropDown();
                    model.EmailAddress = data.EmailAddress;
                    result.Add(model);
                }
            }


            return result;
        }
    



    }
}