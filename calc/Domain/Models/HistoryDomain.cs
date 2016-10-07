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
        [Display(Name = "First variable")]
        public virtual int X { get; set; }

        [Required]
        [Display(Name = "Second variable")]
        public virtual int Y { get; set; }

        [Display(Name = "Result")]
        public virtual double Result { get; set; }

        [Display(Name = "Operation")]
        public virtual string Operation { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public virtual DateTime CreationDate { get; set; }
    }
}
