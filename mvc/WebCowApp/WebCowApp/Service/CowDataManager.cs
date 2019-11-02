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
                .Select((entity) => CowEntityToVM(entity));
        }

        public IEnumerable<CowVM> GetCowByBreedVMs(int id)
        {
            return Repo.GetCows()
                .Where((entity) => entity.BreedID == id)
                .Select((entity) => CowEntityToVM(entity));
        }

        public IEnumerable<BreedVM> GetBreedVMs()
        {
            return Repo.GetBreeds()
                .Select((breed) => BreedEntityToVM(breed));
        }

        private BreedVM BreedEntityToVM(Breed breed)
        {
            return new BreedVM
            {
                Id = breed.IDBreed,
                Name = breed.Name,
            };
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

        internal void UpdateCowPicture(int cowID, string picturePath)
        {
            Cow entity = Repo.GetCowById(cowID);
            entity.PicturePath = picturePath;
            Repo.UpdateCow(entity);
        }

        internal CowVM GetCowById(int id)
        {
            return GetCowVMs()
                .Where((cow) => cow.CowID == id)
                .FirstOrDefault();
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