using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileSharing.Models
{
    public class FileViewModel
    {
        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Author Id")]
        public Guid AuthorId { get; set; }
    }
}