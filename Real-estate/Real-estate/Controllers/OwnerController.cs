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

        //To display the full details of the Owner 
        public ActionResult Details(String id)
        {
            Owner owner = rec.Owners.SingleOrDefault(x=> x.OwnerNo == id); 
            return View(owner);
        }    


    }
}