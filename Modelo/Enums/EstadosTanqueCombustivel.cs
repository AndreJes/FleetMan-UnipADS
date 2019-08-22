using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Enums
{
    public enum EstadosTanqueCombustivel : int
    {
        CHEIO = 100,
        TRES_QUARTOS = 75,
        METADE = 50,
        UM_QUARTO = 25,
        VAZIO = 0
    }
}
