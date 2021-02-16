using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestAPI.Dtos
{
    public class CommandReadDTO
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        // Removendo Platform como exemplo de DTO
        //public string Platform { get; set; } 
    }
}
