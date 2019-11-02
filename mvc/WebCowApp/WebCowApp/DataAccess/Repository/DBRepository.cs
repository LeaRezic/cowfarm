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
    }
}