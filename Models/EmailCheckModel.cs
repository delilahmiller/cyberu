using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberU.Models
{
    public class EmailCheckModel
    {
        public string Email { get; set; }

        public List<EmailCheckResult> Results { get; set; }
    }
}
