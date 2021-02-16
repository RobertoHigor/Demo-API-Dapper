using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestAPI.Models
{
    public class Command
    {
        /* Existe a annotation [Required] do EntityFramework que transforma
         * o erro de campo null em um Bad Request para o cliente.
         * Assim, o cliente não recebe uma exception
         */
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }

    }
}
