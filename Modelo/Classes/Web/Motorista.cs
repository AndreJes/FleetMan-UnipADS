using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    public class Motorista
    {
        #region Props principais
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long? MotoristaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string NumeroCNH { get; set; }
        public int PontosCNH { get; set; }
        public Endereco Endereco { get; set; }
        public bool MotoristaProprio { get; set; }
        public CategoriasCNH Categoria { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime VencimentoExame { get; set; }
        #endregion
        #region Enums
        public EstadosDeMotorista Estado { get; set; }
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
        public string ProprioTxt
        {
            get
            {
                return MotoristaProprio ? "Sim" : "Não";
            }
        }
        #endregion

        public long? ClienteId { get; set; }
        public Clientes.Cliente Cliente { get; set; }

        public virtual ICollection<Multa> Multas { get; set; }
        public virtual ICollection<Sinistro> Sinistros { get; set; }
        public virtual ICollection<Viagem> Viagens { get; set; }

    }
}
