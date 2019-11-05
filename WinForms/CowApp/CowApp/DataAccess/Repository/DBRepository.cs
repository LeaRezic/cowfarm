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
                    _dbContext.Entry(cow).State = cow.IDCow == 0
                        ? EntityState.Added
                        : EntityState.Modified;
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
