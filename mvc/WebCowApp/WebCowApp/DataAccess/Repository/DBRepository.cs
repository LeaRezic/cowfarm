using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCowApp.DataAccess.Entities;

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
                    return _db.Breeds.ToList();
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
                        .Find(cowID);
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
                    return _db.Cows.Include("Breed").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DailyMilkProduction> GetDailyMilkProductions()
        {
            try
            {
                using (DBModel _db = new DBModel())
                {
                    return _db.DailyMilkProductions.Include("Cow").ToList();
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