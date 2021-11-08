using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseVsw.Models
{
    public class TargetExternalDiametrOfTipe
    {
        public int Id { get; set; }
        public double ExternalDiametrPipe { get; set; }

        public List<ModelPipe> modelPipes { get; set; }
    }
}
