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
            MilkForCowDetailsVM details = CowDataManager.GetMilkDetailsForCow(id);
            return Json(details, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModalMilkDetails(int id)
        {
            MilkForCowDetailsVM details = CowDataManager.GetMilkDetailsForCow(id);
            return PartialView(details);
        }
    }
}