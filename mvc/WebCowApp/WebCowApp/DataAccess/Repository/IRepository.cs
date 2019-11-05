using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCowApp.DataAccess.Entities;

namespace WebCowApp.DataAccess.Repository
{
    interface IRepository
    {
        IEnumerable<Cow> GetCows();
        IEnumerable<Cow> GetCowsForBreed(int breedId);
        IEnumerable<DailyMilkProduction> GetDailyMilkProductionsForCow(int cowId);
        IEnumerable<Breed> GetBreeds();
        Cow GetCowById(int cowID);
        void UpdateCow(Cow entity);
    }
}
