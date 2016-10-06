using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class HistoryDomain
    {
        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name = "Первая переменная")]
        public virtual int X { get; set; }

        [Required]
        [Display(Name = "Вторая переменная")]
        public virtual int Y { get; set; }

        [Display(Name = "Результат")]
        public virtual double Result { get; set; }

        [Display(Name = "Операция")]
        public virtual string Operation { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public virtual DateTime CreationDate { get; set; }
    }
}
