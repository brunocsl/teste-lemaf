using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public class CategoriaDoCarro
    {
        public string Nome { get; set; }
        public int LimiteDePessoas { get; set; }
        public static IList<CategoriaDoCarro> Categorias = new List<CategoriaDoCarro>();
      
        public static IList<CategoriaDoCarro> retornaLista()
        {
            return Categorias;
        }
    }
}
