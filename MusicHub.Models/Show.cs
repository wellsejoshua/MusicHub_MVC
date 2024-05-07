using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Venue { get; set; }
        public string? Location { get; set; }
    }
}
