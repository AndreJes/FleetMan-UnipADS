using Modelo.Classes.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Desk
{
    public class Funcionario
    {
        #region Props principais
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long? FuncionarioId { get; set; }
        public string Nome { get; set; }
        [StringLength(11)]
        [Index(IsUnique = true)]
        public string CPF { get; set; }
        public string RG { get; set; }
        [StringLength(100)]
        [Index(IsUnique = true)]
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
