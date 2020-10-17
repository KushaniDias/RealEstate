using Real_estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_estate.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        //create object to context class
        private RealEstateContext rec = new RealEstateContext();

        public ActionResult Index()
        {
            List<Branch> AllBranches = rec.Branches.ToList();
            return View(AllBranches);
        }

        //create action for Branch -----------------------------------------
        public ActionResult Create()
        {
            //Branch name and id in dropdownlist
            ViewBag.BranchDetails = rec.Branches;
            return View();
        }
        //Action to actually insert the data into Branch--------------------------
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            ViewBag.BranchDetails = rec.Branches;
            rec.Branches.Add(branch);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }

        //To display the full details of the Branches ------------------------------
        public ActionResult Details(String id)
        {
            Branch branch = rec.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        //to delete the details--------------------------------------
        public ActionResult Delete(String id)
        {
            Branch branch = rec.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteBranche(string id)
        {
            Branch branch = rec.Branches.SingleOrDefault(x => x.BranchNo == id);
            rec.Branches.Remove(branch);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }


        //to edit or update the details--------------------------
        public ActionResult Edit(String id)
        {
            Branch branch = rec.Branches.SingleOrDefault(x => x.BranchNo == id);
            ViewBag.BranchDetails =new SelectList(rec.Branches,"BranchNo","Name");
            return View(branch);
        }

        [HttpPost]
        public ActionResult Edit(String id,Branch updatesBranch)
        {
            Branch branch = rec.Branches.SingleOrDefault(x => x.BranchNo == id);
            branch.BranchNo = updatesBranch.BranchNo;
            branch.Street = updatesBranch.Street;
            branch.City = updatesBranch.City;
            branch.Postcode = updatesBranch.Postcode;
            rec.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}