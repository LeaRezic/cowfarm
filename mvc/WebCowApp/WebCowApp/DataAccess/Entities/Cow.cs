namespace WebCowApp.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cow")]
    public partial class Cow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cow()
        {
            DailyMilkProductions = new HashSet<DailyMilkProduction>();
        }

        [Key]
        public int IDCow { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int BreedID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(25)]
        public string VeterinaryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfArrival { get; set; }

        public int CalfCount { get; set; }

        [StringLength(255)]
        public string PicturePath { get; set; }

        public virtual Breed Breed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyMilkProduction> DailyMilkProductions { get; set; }
    }
}
