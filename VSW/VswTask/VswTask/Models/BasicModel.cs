using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VswTask.Models
{
    public class BasicModel
    {
        private string note;

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Номер трубы\" обязательное для заполнения")]
        [Display(Name = "Номер трубы")]
        public int NumberTube { get; set; }

        [Required(ErrorMessage = "Поле \"Целевой внешний диаметр трубы\" обязательное для заполнения")]
        [Display(Name = "Целевой внешний диаметр трубы, мм")]
        public double MeasuredDiameter1 { get; set; }

        [Required(ErrorMessage = "Поле \"Измеренный внешний диаметр по концу трубы 1\" обязательное для заполнения")]
        [Display(Name = "Измеренный внешний диаметр по концу трубы 1, мм")]
        public double MeasuredDiameter2 { get; set; }

        [Required(ErrorMessage = "Поле \"Измеренный внешний диаметр по концу трубы 2\" обязательное для заполнения")]
        [Display(Name = "Измеренный внешний диаметр по концу трубы 2, мм")]
        public double MeasuredDiameter3 { get; set; }

        [Required(ErrorMessage = "Поле \"Максимальное отклонение измеренных диаметров от целевого\" обязательное для заполнения")]
        [Display(Name = "Максимальное отклонение измеренных диаметров от целевого, мм")]
        public double MaxDeviation { get; set; }

        [Display(Name = "Примечание")]
        public string Note { get => note; set => note = value; }


        //[Required(ErrorMessage = "Поле \"Номенклатура трубы\" обязательное для заполнения")]

        #region TargetOuterDiameter Model
        [ForeignKey("TargetDiameterId")]
        
        public int TargetDiameterId { get; set; }

        [Display(Name = "Номенклатура трубы")]
        public virtual TargetOuterDiameter? TargetOuterDiameter { get; set; }
        #endregion

        #region DateValue

        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        #endregion
    }
}
