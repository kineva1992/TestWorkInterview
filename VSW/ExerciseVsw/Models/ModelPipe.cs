using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseVsw.Models
{
    public class ModelPipe
    {
        public int Id { get; set; }
        /// <summary>
        /// Номер трубы
        /// </summary>
        [Required]
        public string NumberPipe { get; set; }
        /// <summary>
        /// Номенклатура трубы
        /// </summary>
        [Required]
        public string Nomenclature { get; set; }

        /// <summary>
        /// Измеренный внешний диаметр по концу трубы 1, мм
        /// </summary>
        [Required]
        public double Diam1 { get; set; }
        /// <summary>
        /// Измеренный внешний диаметр по концу трубы 2, мм
        /// </summary>
        [Required]
        public double Diam2 { get; set; }
        /// <summary>
        /// Измеренный внешний диаметр по центру трубы, мм
        /// </summary>
        [Required]
        public double DiamCenter{ get; set; }
        /// <summary>
        /// Максимальное отклонение измеренных диаметров от целевого, мм
        /// </summary>
        [Required]
        public double MaximumDeviation { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

    }
}
