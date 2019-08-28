using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Auxiliares
{
    public static class StringsFormatersExtentions
    {
        public static string FormatarCPF(this string cpf)
        {
            return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }

        public static string FormatarCNPJ(this string cnpj)
        {
            return cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
        }

        public static string FormatarTelefone(this string telefone)
        {
            return telefone.Insert(0, "(").Insert(3, ") ").Insert(9, "-");
        }
    }
}
