namespace WebCowApp.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyMilkProduction")]
    public partial class DailyMilkProduction
    {
        [Key]
        public int IDDailyMilkProduction { get; set; }

        [Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }

        [Required]
        public int CowID { get; set; }

        [Required]
        public decimal MilkInLiters { get; set; }

        public decimal? AverageFat { get; set; }

        public decimal? AverageMicroorganisms { get; set; }

        public virtual Cow Cow { get; set; }
    }
}
