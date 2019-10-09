using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Auxiliares
{
    public static class ConversorBoolNullable
    {
        public static bool ConversorBooleano(bool? BoolNullable)
        {
            return BoolNullable ?? false;
        }
    }
}
