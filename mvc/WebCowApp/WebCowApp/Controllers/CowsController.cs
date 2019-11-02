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
            List<BreedVM> model = new List<BreedVM>();
            model.Add(new BreedVM { Id = 0, Name = "Show All" });
            model.AddRange(CowDataManager.GetBreedVMs());
            return View(model);
        }

        public ActionResult CowsForBreed(int id)
        {
            IEnumerable<CowVM> model = id == 0
                ? CowDataManager.GetCowVMs()
                : CowDataManager.GetCowByBreedVMs(id);
            return PartialView(model);
        }

        public ActionResult ModalMilkDetails(int id)
        {
            MilkForCowDetailsVM details = CowDataManager.GetMilkDetailsForCow(id);
            return PartialView(details);
        }

        public ActionResult EditPicture(int id)
        {
            CowVM cow = CowDataManager.GetCowById(id);
            return View(cow);
        }

        [HttpPost]
        public ActionResult EditPicture(CowPictureEditVM cow)
        {
            CowDataManager.UpdateCowPicture(cow.CowID, cow.PicturePath);
            Console.WriteLine(cow);
            return RedirectToAction("Cows");
        }


    }
}
