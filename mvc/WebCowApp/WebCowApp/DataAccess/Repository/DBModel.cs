namespace WebCowApp.DataAccess.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WebCowApp.DataAccess.Entities;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Cow> Cows { get; set; }
        public virtual DbSet<DailyMilkProduction> DailyMilkProductions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>()
                .HasMany(e => e.Cows)
                .WithRequired(e => e.Breed)
                .HasForeignKey(e => e.BreedID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cow>()
                .HasMany(e => e.DailyMilkProductions)
                .WithRequired(e => e.Cow)
                .HasForeignKey(e => e.CowID);

            modelBuilder.Entity<DailyMilkProduction>()
                .Property(e => e.MilkInLiters)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DailyMilkProduction>()
                .Property(e => e.AverageFat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DailyMilkProduction>()
                .Property(e => e.AverageMicroorganisms)
                .HasPrecision(18, 0);
        }
    }
}
