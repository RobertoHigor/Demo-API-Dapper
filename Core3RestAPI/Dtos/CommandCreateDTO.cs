using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestAPI.Dtos
{
    public class CommandCreateDTO
    {
        // Auto increment
        //public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; } 
        [Required]
        public string Platform { get; set; } 
    }
}
