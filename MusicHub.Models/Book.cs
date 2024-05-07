using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Models
{
    public class Book : Product
    {
        [Required]
        [DisplayName("Title")]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        public string? ISBN { get; set; }

        [Required]
        public string? Author { get; set; }


    }
}
