using System;
using System.Collections.Generic;
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
    }
}
