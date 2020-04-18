using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CyberU.Models
{
    public class Breach
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumberAffected { get; set; }
        public string Description { get; set; }
    }
}
