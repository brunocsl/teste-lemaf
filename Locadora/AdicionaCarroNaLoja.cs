using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public class AdicionaCarroNaLoja
    {
        //Adiciona os carros em uma lista de carros para cada loja

        public void Add(Carro carro)
        {
            if (string.Compare(carro.Categoria, "Compacto", true)  ==0)
            {
                SouthCar.Carros.Add(carro);            
            }
            else if (string.Compare(carro.Categoria, "Esportivo", true) == 0)
            {
                WestCar.Carros.Add(carro);
            }
            else if (string.Compare(carro.Categoria, "Suv", true) == 0)
            {
                NorthCar.Carros.Add(carro);
            }
        }

    }
}
