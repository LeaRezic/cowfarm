using CowApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowApp.DataAccess.Repository
{
    interface IRepository
    {
        IEnumerable<Breed> GetBreeds();
        IEnumerable<Cow> GetCows();
        IEnumerable<DailyMilkProduction> GetDailyMilkProductions();
        Breed GetBreed(int id);
        Cow GetCow(int id);
        void UpdateCow(Cow cow);
    }
}
