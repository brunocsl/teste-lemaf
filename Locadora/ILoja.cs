using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora
{
    public interface ILoja
    {
        double CalculaTaxa(bool fimDeSemana, bool fidelidade);
    }
}
