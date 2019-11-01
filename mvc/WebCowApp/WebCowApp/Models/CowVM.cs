using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCowApp.Models
{
    public class CowVM
    {
        public int CowID { get; set; }
        [Display(Name="Cow Name")]
        public string Name { get; set; }
        public int BreedID { get; set; }
        [Display(Name = "Breed")]
        public string BreedName { get; set; }
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }
        [Display(Name = "Date of Arrival")]
        public string DateOfArrival { get; set; }
        [Display(Name = "Veterinary ID")]
        public string VetID { get; set; }
        [Display(Name = "Number of Calf")]
        public int CalfCount { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
    }
}