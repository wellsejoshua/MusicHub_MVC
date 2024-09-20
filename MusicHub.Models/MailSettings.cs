using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Models
{
    public class MailSettings
    {
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? MailPassword { get; set; }
        public string? MailHost { get; set; }
        public int MailPort { get; set; }
    }
}
