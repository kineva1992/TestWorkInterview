using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseVsw.Models
{
    public class DbContextPipe : DbContext
    {
        public DbSet<ModelPipe> modelPipes { get; set; }
        public DbSet<TargetExternalDiametrOfTipe> targetExternalDiametrOfTipes { get; set; }

        public DbContextPipe(DbContextOptions<DbContextPipe> context) : base(context)
            {
            Database.EnsureCreated();
            }
    }
}
