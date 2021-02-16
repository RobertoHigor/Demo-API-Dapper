using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3RestAPI.Data
{
    // Context é a classe de Data Acess responsável pela conexão com o banco
    // Nesse caso, está no exemplo por ser baseado em entity framework
    // Para isso, ele herda DbContext
    public class CommandContext

    {
        public CommandContext()
        {
            // Construtor com DbContextOptions

            //DbSet para mapear uma entidade
        }
    }
}
