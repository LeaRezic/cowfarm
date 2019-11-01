using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCowApp.Models;
using WebCowApp.Service;

namespace WebCowApp.Controllers
{
    public class CowsController : Controller
    {
        public CowDataManager CowDataManager { get; set; }

        public CowsController()
        {
            CowDataManager = new CowDataManager();
        }

        // GET: Cows
        public ActionResult Cows()
        {
            var model = CowDataManager.GetCowVMs();
            return View(model);
        }

        public ActionResult CowMilkDetails(int id)
        {
            List<MilkForCowDetailsVM> detailsList = CowDataManager.GetMilkDetailsForCow(id).ToList();
            return Json(detailsList, JsonRequestBehavior.AllowGet);
        }
    }
}