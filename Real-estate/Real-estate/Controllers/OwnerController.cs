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
            return View();
        }
    }
}