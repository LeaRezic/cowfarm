using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCowApp.Models
{
    public class CowPictureEditVM
    {
        public int CowID { get; set; }
        public string Name { get; set; }
        public string VetID { get; set; }
        public string PicturePath { get; set; }
    }
}