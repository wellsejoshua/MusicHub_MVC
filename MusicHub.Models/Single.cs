using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Models
{
    public class Single : Product
    {
        [Required]
        public string? Artist { get; set; }

        public string? Album { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public List<string>? Collaborators { get; set; }

        [Required]
        public string? Label { get; set; }


    }
}
