﻿using Real_estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_estate.Controllers
{
    public class StaffController : Controller
    {
        //create object to context class
        private RealEstateContext rec = new RealEstateContext();
        // GET: Staff
        public ActionResult Index()
        {
            List<Staff> AllStaffs = rec.Staffs.ToList();
            return View(AllStaffs);
        }

        //create action for Staff -----------------------------------------
        public ActionResult Create()
        {
            
            ViewBag.StaffDetails = rec.Staffs;
            return View();
        }
        //Action to actually insert the data into Staff--------------------------
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            ViewBag.StaffDetails = rec.Staffs;
            rec.Staffs.Add(staff);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }

        //To display the full details of the Staffs ------------------------------
        public ActionResult Details(String id)
        {
            Staff staff = rec.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        //to delete the details--------------------------------------
        public ActionResult Delete(String id)
        {
            Staff staff = rec.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaffs(string id)
        {
            Staff staff = rec.Staffs.SingleOrDefault(x => x.StaffNo == id);
            rec.Staffs.Remove(staff);
            rec.SaveChanges();
            return RedirectToAction("Index");
        }


        //to edit or update the details--------------------------
        public ActionResult Edit(String id)
        {
            Staff staff = rec.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.StaffDetails = new SelectList(rec.Staffs, "StaffNo", "Name");
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(String id, Staff updatedStaff)
        {
            Staff staff = rec.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.StaffNo = updatedStaff.StaffNo;
            staff.Fname = updatedStaff.Fname;
            staff.Lname = updatedStaff.Lname;
            staff.Position = updatedStaff.Position;
            staff.DOB = updatedStaff.DOB;
            staff.Salary = updatedStaff.Salary;
            staff.Branch_BranchNoRef = updatedStaff.Branch_BranchNoRef;
            rec.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}