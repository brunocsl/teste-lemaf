using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
   public class CalculadordeTaxa
    {
        public double MenorTaxa { get; set; }
        public string NomeDaLoja { get; set; }
        public IList<Carro> listaDeCarros { get; set; }

        public CalculadordeTaxa CalculaTaxaLocacao(int numPassageiros, string datas)
        {
            //separando as datas
            var datasLocacao = datas.Split(',');
            double taxaTotalSouthCar = 0;
            double taxaTotalWestCar = 0;
            double taxaTotalNorthCar = 0;

            //analisa cada data dentro do array
            foreach (var data in datasLocacao)
            {
                //verifica se tem fim de semana ou fidelidade
                bool fimDeSemana = IsfimDeSemana(data);
                bool fidelidade = IsFidelidade();

                //calcula a taxa em cada loja
                foreach (var categoria in CategoriaDoCarro.Categorias)
                {
                    if (numPassageiros <= categoria.LimiteDePessoas)
                    {
                        if (categoria.Nome == SouthCar.Categoria)
                        {
                            var lojaSouthCar = new SouthCar();
                            var taxaSouthCar = lojaSouthCar.CalculaTaxa(fimDeSemana, fidelidade);
                            taxaTotalSouthCar = taxaTotalSouthCar + taxaSouthCar;
                        }
                        else if (categoria.Nome == NorthCar.Categoria)
                        {
                            var lojaNorthCar = new NorthCar();
                            var taxaNorthCar = lojaNorthCar.CalculaTaxa(fimDeSemana, fidelidade);
                            taxaTotalNorthCar = taxaTotalNorthCar + taxaNorthCar;
                        }
                        else if (categoria.Nome == WestCar.Categoria)
                        {
                            var lojaWestCar = new WestCar();
                            var taxaWestCar = lojaWestCar.CalculaTaxa(fimDeSemana, fidelidade);
                            taxaTotalWestCar = taxaTotalWestCar + taxaWestCar;
                        }

                    }
                }
            
            }
            Console.WriteLine("Taxa na SouthCar " + taxaTotalSouthCar);
            Console.WriteLine("Taxa na NorthCar " + taxaTotalNorthCar);
            Console.WriteLine("Taxa na WestCar " + taxaTotalWestCar);

            if (taxaTotalNorthCar == 0)
            {
                taxaTotalNorthCar = 999999999;
            }
            if (taxaTotalSouthCar == 0)
            {
                taxaTotalSouthCar = 999999999;
            }
            if (taxaTotalWestCar == 0)
            {
                taxaTotalWestCar = 999999999;
            }
            //Verifica qual é a menor taxa
            double[] taxas =
            {
                taxaTotalNorthCar,
                taxaTotalSouthCar,
                taxaTotalWestCar
            };

            this.MenorTaxa = taxas.Min();

            //Retorna a loja com menor taxa
            if(this.MenorTaxa == taxaTotalNorthCar)
            {
                this.NomeDaLoja = NorthCar.Nome;
                this.listaDeCarros = NorthCar.retornaLista();
            }
            else if (this.MenorTaxa == taxaTotalSouthCar)
            {
                this.NomeDaLoja = SouthCar.Nome;
                this.listaDeCarros = SouthCar.retornaLista();
            }
            else if (this.MenorTaxa == taxaTotalWestCar)
            {
                this.NomeDaLoja = WestCar.Nome;
                this.listaDeCarros = WestCar.retornaLista();
            }
            Console.WriteLine("Menor taxa encontrada na loja " + this.NomeDaLoja + "\n");
            Console.WriteLine("Salvando o resultado no arquivo...");
            return this;
        }

        //Verifica se é fim de semana
        public bool IsfimDeSemana(string data)
        {
            if (data.Contains("sab") | data.Contains("dom"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Verifica sem tem fidelidade
        public bool IsFidelidade()
        {
            //Sempre retorna falso (de acordo com especificação do trabalho)
            return false;
        }
    }
}
