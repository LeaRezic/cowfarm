using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCowApp.Models
{
    public class MilkForCowDetailsVM
    {
        public int CowID { get; set; }
        public string CowName { get; set; }
        public List<MilkEntryVM> MilkEntries { get; set; }
    }
}