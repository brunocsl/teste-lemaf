using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public class SouthCar : ILoja
    {
        public static string Nome = "SouthCar";
        public static string Categoria = "Compacto";
        public static IList<Carro> Carros = new List<Carro>();
        public double taxa { get; set; }

        public static IList<Carro> retornaLista()
        {
            return Carros;
        }

        public double CalculaTaxa(bool fimDeSemana, bool fidelidade)
        {
            if (fimDeSemana == true){
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
                    this.taxa = 210;
                }
            }
            return this.taxa;
        }

        public bool IsFidelidade()
        {
            return false;
        }
        public bool IsFimDeSemana(DateTime data)
        {
            return true;
        }
    }
}
