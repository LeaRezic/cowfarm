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

        public MilkForCowDetailsVM GetMilkDetailsForCow(int cowId)
        {
            MilkForCowDetailsVM result = new MilkForCowDetailsVM();
            List<DailyMilkProduction> milkEntries = Repo.GetDailyMilkProductions()
                .Where((dmp) => dmp.CowID == cowId)
                .ToList();
            if (milkEntries.Count > 0)
            {
                result.CowID = milkEntries[0].CowID;
                result.CowName = milkEntries[0].Cow.Name;
                result.MilkEntries = milkEntries.Select((dmp) => MilkEntryEntityToVM(dmp))
                    .ToList();
            }
            return result;
        }

        private MilkEntryVM MilkEntryEntityToVM(DailyMilkProduction dmp)
        {
            return new MilkEntryVM
            {
                Date = dmp.EntryDate.ToLongDateString(),
                Liters = dmp.MilkInLiters
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