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
        void UpdateCow(Cow cow);
    }
}
