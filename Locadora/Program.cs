using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    class Program
    {
        static void Main(string[] args)
        {
            //Carregando categorias dos carros

            Console.WriteLine("Carregando categorias dos carros...\n");
            string DirCategorias = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\\..\\..\\..\\categorias.txt";

            string[] linhasCategoria = System.IO.File.ReadAllLines(DirCategorias);
            foreach (string linha in linhasCategoria)
            {
                var categoria = linha.Split(';');
                var novaCategoria = new CategoriaDoCarro();
                novaCategoria.Nome = categoria[0];
                novaCategoria.LimiteDePessoas = Convert.ToInt32(categoria[1]);
                CategoriaDoCarro.Categorias.Add(novaCategoria);
            }

            //Carregando os carros

            Console.WriteLine("Carregando os carros...\n");
            string DirCarros = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\\..\\..\\..\\carros.txt";

            var listaDeCarros = new List<Carro>();
            string[] linhasCarro = System.IO.File.ReadAllLines(DirCarros);
            foreach (string linha in linhasCarro)
            {
                var carro = linha.Split(';');
                var novoCarro = new Carro();
                novoCarro.Nome = carro[0];
                novoCarro.Categoria = carro[1];

                //Se existir categoria criada, adiciona o carro na Lista de Carros cadastrados

                if (CategoriaDoCarro.Categorias.Any(c => c.Nome == novoCarro.Categoria))
                {
                    listaDeCarros.Add(novoCarro);

                    //Adiciona cada modelo de carro em sua respectiva loja

                    AdicionaCarroNaLoja adicionaCarronaLoja = new AdicionaCarroNaLoja();
                    adicionaCarronaLoja.Add(novoCarro);
                }
            }

            //Lendo a entrada de dados do arquivo
            string DirEntrada = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\\..\\..\\..\\entrada.txt";
            string linhaEntrada = System.IO.File.ReadAllText(DirEntrada);

            //Removendo espaço em branco e dividindo a string

            var dadosCarro = linhaEntrada.Replace(" ", "").Split(':');
            var tipoCarro = dadosCarro[0];
            var numPassageiros = Convert.ToInt32(dadosCarro[1]);
            var datasLocacao = dadosCarro[2];

            //Calcula a menor Taxa e recebe a loja junto com sua lista de carros

            var calculador = new CalculadordeTaxa();
            var lojaComMenorTaxa = calculador.CalculaTaxaLocacao(numPassageiros, datasLocacao);

            //Preparando a string para salvar o resultado em um arquivo

            string resultado = "";
            int i = 0;
            foreach (var carro in lojaComMenorTaxa.listaDeCarros)
            {
                if (i == lojaComMenorTaxa.listaDeCarros.Count() - 1)
                {
                    resultado = resultado + carro.Nome;
                }
                else
                {
                    resultado = resultado + carro.Nome + ", ";
                }
                i++;
            }
            resultado = resultado + ":" + lojaComMenorTaxa.NomeDaLoja;

            //Gravando no arquivo resultado.txt
            string DirSaida = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\\..\\..\\..\\saida.txt";
            System.IO.File.WriteAllText(DirSaida, resultado);
            Console.WriteLine("Concluído. Tecle ENTER para Sair.");

            System.Console.ReadLine();
        }
    }
}
