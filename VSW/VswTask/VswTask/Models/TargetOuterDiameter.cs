namespace VswTask.Models
{
    public class TargetOuterDiameter
    {
        public int Id { get; set; }
        public double TargetOuterDiameters { get; set; }
        public ICollection<BasicModel>? BasicModels { get; set; }
    }
}
