using Real_estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_estate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Object creation for Context class
        private RealEstateContext rec = new RealEstateContext();
        public ActionResult Index()
        {
            List<Branch> AllBranches = rec.Branches.ToList();
            return View(AllBranches);
        }

        public ActionResult Staffs()
        {
            List<Staff> AllStaffs = rec.Staffs.ToList();
            return View(AllStaffs);
        }

        public ActionResult Owners()
        {
            List<Owner> AllOwners = rec.Branches.ToList();
            return View(AllOwners);
        }

        public ActionResult Rents()
        {
            List<Rent> AllRents = rec.Rents.ToList();
            return View(AllRents);
        }

        //to display all the table details 
        public ActionResult BranchDetails(string id)
        {
            Branch branch = rec.Branches
                .SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        public ActionResult StaffDetails(string id)
        {
            Staff staff = rec.Staffs
                .SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult OwnerDetails(string id)
        {
            Owner owner = rec.Branches
                .SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        public ActionResult RentDetals(string id)
        {
            Rent rent = rec.Rents
                .SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }


    }
}