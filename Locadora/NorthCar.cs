using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public class NorthCar : ILoja
    {
        public static string Nome = "NorthCar";
        public static string Categoria = "Suv";
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
                    this.taxa = 590;
                }
                else
                {
                    this.taxa = 600;
                }
            }
            else
            {
                if (fidelidade == true)
                {
                    this.taxa = 580;
                }
                else
                {
                    this.taxa = 630;
                }
            }
            return this.taxa;
        }
    }
}
