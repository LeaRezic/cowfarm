using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCowApp.DataAccess.Entities;
using System.Data.Entity;

namespace WebCowApp.DataAccess.Repository
{
    public class DBRepository : IRepository
    {
        public IEnumerable<Breed> GetBreeds()
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    return _db.Breeds
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cow GetCowById(int cowID)
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    return _db.Cows
                        .Include(c => c.Breed)
                        .ToList()
                        .Find(c => c.IDCow == cowID);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Cow> GetCows()
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    return _db.Cows
                        .Include(c => c.Breed)
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Cow> GetCowsForBreed(int breedId)
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    return _db.Cows
                        .Include(c => c.Breed)
                        .Where(cow => cow.BreedID == breedId)
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DailyMilkProduction> GetDailyMilkProductionsForCow(int cowId)
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    return _db.DailyMilkProductions
                        .Include(dpm => dpm.Cow)
                        .Where(dmp => dmp.CowID == cowId)
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCow(Cow entity)
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}