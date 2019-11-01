using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCowApp.DataAccess.Entities;
using WebCowApp.DataAccess.Repository;
using WebCowApp.Models;

namespace WebCowApp.Service
{
    public class CowDataManager
    {

        private IRepository Repo { get; set; }

        public CowDataManager()
        {
            Repo = new DBRepository();
        }

        public IEnumerable<CowVM> GetCowVMs()
        {
            return Repo.GetCows()
                .ToList()
                .Select((entity) => CowEntityToVM(entity));
        }

        public IEnumerable<MilkForCowDetailsVM> GetMilkDetailsForCow(int cowId)
        {
            List<MilkForCowDetailsVM> result = new List<MilkForCowDetailsVM>();
            List<DailyMilkProduction> dmpList = Repo.GetDailyMilkProductions()
                .Where((dmp) => dmp.CowID == cowId)
                .ToList();
            if (dmpList.Count > 0)
            {
                result = dmpList.Select((dmp) => DmpToMilkForCowDetailsVM(dmp))
                    .ToList();
            }
            return result;
        }

        private MilkForCowDetailsVM DmpToMilkForCowDetailsVM(DailyMilkProduction dmp)
        {
            return new MilkForCowDetailsVM
            {
                CowID = dmp.CowID,
                CowName = dmp.Cow.Name,
                Date = dmp.EntryDate.ToString(),
                MilkInLiters = dmp.MilkInLiters
            };
        }

        private CowVM CowEntityToVM(Cow entity)
        {
            return new CowVM
            {
                CowID = entity.IDCow,
                Name = entity.Name,
                BreedID = entity.BreedID,
                BreedName = entity.Breed.Name,
                CalfCount = entity.CalfCount,
                DateOfArrival = entity.DateOfArrival.ToLongDateString(),
                DateOfBirth = entity.DateOfBirth.ToLongDateString(),
                PicturePath = entity.PicturePath,
                VetID = entity.VeterinaryID
            };
        }

        
    }
}