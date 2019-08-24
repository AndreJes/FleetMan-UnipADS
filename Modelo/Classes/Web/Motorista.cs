using Modelo.Classes.Auxiliares;
using Modelo.Classes.Desk;
using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Web
{
    public class Motorista
    {
        #region Props principais
        public long? MotoristaId { get; set; }
        public string NumeroCNH { get; set; }
        public int PontosCNH { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
        public bool MotoristaProprio { get; set; }
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
                return CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
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

        public List<Multa> Multas { get; set; }
        public List<Sinistro> Sinistros { get; set; }
        public List<Viagem> Viagens { get; set; }

    }
}
