using Modelo.Classes.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Funcionario
    {
        #region Props principais
        public long? FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        #endregion

        #region Props não mapeadas
        [NotMapped]
        public string CPFTxt
        {
            get
            {
                return CPF.FormatarCPF();
            }
        }

        [NotMapped]
        public string TelefoneTxt
        {
            get
            {
                return Telefone.FormatarNumCelular();
            }
        }
        #endregion

    }
}
