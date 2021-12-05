using Microsoft.EntityFrameworkCore;

namespace VswTask.Models
{
    public class DbContextPipe : DbContext
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public DbContextPipe(DbContextOptions<DbContextPipe> options)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder bilder)
        {
            bilder.Entity<BasicModel>().
                HasOne(p => p.TargetOuterDiameter).
                WithMany(t => t.BasicModels).
                HasForeignKey(p => p.TargetDiameterId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<BasicModel> BasicModels { get; set; }
        public DbSet<TargetOuterDiameter> TargetOuterDiameters { get; set; }
        
    }
}
