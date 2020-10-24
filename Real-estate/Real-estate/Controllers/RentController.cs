using Real_estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_estate.Controllers
{
    public class RentController : Controller
    {
        //create object to context class
        private RealEstateContext rec = new RealEstateContext();

        // GET: Rent
        public ActionResult Index()
        {
            List<Rent> AllRents = rec.Rents.ToList();
            List<Rent> distinctCity = rec.Rents.GroupBy(x=>x.City).Select(x=>x.FirstOrDefault()).ToList();
            ViewBag.City = new SelectList(distinctCity,"City","City");
            return View(AllRents);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<Rent> distinctCity = rec.Rents.GroupBy(x => x.City).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.City = new SelectList(distinctCity, "City", "City");
            String cty = form["CtyDropDown"]?.ToString();

            if (cty == null)
            {
                List<Rent> filterBuildings = rec.Rents.ToList();
                return View(filterBuildings);
            }
            else {
                List<Rent> filterBuildings = rec.Rents.Where(x=>x.City==cty).ToList();
                return View(filterBuildings);
            }
           
        }

        //create action for Rent -----------------------------------------
        public ActionResult Create()
        {
            ViewBag.StaffDetails = rec.Staffs;
            ViewBag.BranchDetails = rec.Branches;
            ViewBag.OwnerDetails = rec.Owners;
            // ViewBag.RentDetails = rec.Rents;
            return View();
        }
        //Action to actually insert the data into Rent--------------------------
        [HttpPost]
        public ActionResult Create(Rent rent)
        {
            ViewBag.StaffDetails = rec.Staffs;
            ViewBag.BranchDetails = rec.Branches;
            ViewBag.OwnerDetails = rec.Owners;
            //ViewBag.RentDetails = rec.Rents;
            rec.Rents.Add(rent);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }

        //To display the full details of the Rents ------------------------------
        public ActionResult Details(String id)
        {
            Rent rent = rec.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        //to delete the details--------------------------------------
        public ActionResult Delete(String id)
        {
            Rent rent = rec.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRent(string id)
        {
            Rent rent = rec.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rec.Rents.Remove(rent);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }


        //to edit or update the details--------------------------
        public ActionResult Edit(String id)
        {
            ViewBag.StaffDetails = rec.Staffs;
            ViewBag.BranchDetails = rec.Branches;
            ViewBag.OwnerDetails = rec.Owners;
            Rent rent = rec.Rents.SingleOrDefault(x => x.PropertyNo == id);
            //ViewBag.RentDetails = new SelectList(rec.Rents, "PropertyNo", "Name");
            return View(rent);
        }

        [HttpPost]
        public ActionResult Edit(String id, Rent updatedRent)
        {
           // ViewBag.StaffDetails = rec.Staffs;
           // ViewBag.BranchDetails = rec.Branches;
           // ViewBag.OwnerDetails = rec.Owners;
            Rent rent = rec.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.PropertyNo = updatedRent.PropertyNo;
            rent.Street = updatedRent.Street;
            rent.City = updatedRent.City;
            rent.Ptype = updatedRent.Ptype;
            rent.Rooms = updatedRent.Rooms;
            rent.RefOwnerNoRef = updatedRent.RefOwnerNoRef;
            rent.RefStaffNoRef = updatedRent.RefStaffNoRef;
            rent.REfBranchNoRef = updatedRent.REfBranchNoRef;
            rent.rent1 = updatedRent.rent1;
            rec.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}