using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    /// <summary>
    /// Модель для расчета значений
    /// </summary>
    public class CalcModel
    {
        [Required]
        [Display(Name="First variable")]
        public int X { get; set; }

        [Required]
        [Display(Name = "Second variable")]
        public int Y { get; set; }

        [Display(Name = "Result")]
        public double Result { get; set; }

        [Required]
        public String Operation { get; set; }
    }
}