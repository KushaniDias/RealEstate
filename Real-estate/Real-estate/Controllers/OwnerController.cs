using Real_estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_estate.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        //create object for context class
        private RealEstateContext rec = new RealEstateContext();
        public ActionResult Index()
        {
            List<Owner> AllOwners = rec.Owners.ToList();
            return View(AllOwners);
        }

        //add owners
        public ActionResult Create()
        {
            //Owner name and id in dropdownlist
            ViewBag.OwnerDetails = rec.Owners;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            ViewBag.OwnerDetails = rec.Owners;
            rec.Owners.Add(owner);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }

        //To display the full details of the Owner -----------------------------------
        public ActionResult Details(String id)
        {
            Owner owner = rec.Owners.SingleOrDefault(x=> x.OwnerNo == id); 
            return View(owner);
        }


        //to delete the details--------------------------------------
        public ActionResult Delete(String id)
        {
            Owner owner = rec.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOwner(string id)
        {
            Owner owner = rec.Owners.SingleOrDefault(x => x.OwnerNo == id);
            rec.Owners.Remove(owner);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }


        //to edit or update the details--------------------------
        public ActionResult Edit(String id)
        {
            Owner owner = rec.Owners.SingleOrDefault(x => x.OwnerNo == id);
            ViewBag.OwnerDetails = new SelectList(rec.Owners, "OwnerNo", "Name");
            return View(owner);
        }

        [HttpPost]
        public ActionResult Edit(String id, Owner updatedOwner)
        {
            Owner owner = rec.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.OwnerNo = updatedOwner.OwnerNo;
            owner.Fname = updatedOwner.Fname;
            owner.Lname = updatedOwner.Lname;
            owner.Address = updatedOwner.Address;
            owner.TellNo = updatedOwner.TellNo;
            rec.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}