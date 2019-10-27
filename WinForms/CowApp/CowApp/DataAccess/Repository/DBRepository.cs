using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CowApp.DataAccess.Entities;

namespace CowApp.DataAccess.Repository
{
    class DBRepository : IRepository
    {
        public Breed GetBreed(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Breed> GetBreeds()
        {
            try
            {
                using (var _dbContext = new DBModel())
                {
                    return _dbContext.Breeds.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cow GetCow(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cow> GetCows()
        {
            try
            {
                using (var _dbContext = new DBModel())
                {
                    return _dbContext.Cows
                        .Include("Breed")
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DailyMilkProduction> GetDailyMilkProductions()
        {
            throw new NotImplementedException();
        }

        public void UpdateCow(Cow cow)
        {
            this.UpdateOrCreateCow(cow);
        }

        private void UpdateOrCreateCow(Cow cow)
        {
            try
            {
                using (var _dbContext = new DBModel())
                {
                    _dbContext.Entry(cow).State = cow.IDCow == 0 ?
                                                        EntityState.Added :
                                                        EntityState.Modified;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
