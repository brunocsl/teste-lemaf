using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public class WestCar : ILoja
    {
        public static string Nome = "WestCar";
        public static string Categoria = "Esportivo";
        public static IList<Carro> Carros = new List<Carro>();
        public double taxa { get; set; }

        public static IList<Carro> retornaLista()
        {
            return Carros;
        }

        public double CalculaTaxa(bool fimDeSemana, bool fidelidade)
        {
            if (fimDeSemana == true)
            {
                if (fidelidade == true)
                {
                    this.taxa = 90;
                }
                else
                {
                    this.taxa = 200;
                }
            }
            else
            {
                if (fidelidade == true)
                {
                    this.taxa = 150;
                }
                else
                {
                    this.taxa = 530;
                }
            }
            return this.taxa;
        }
    }
}
