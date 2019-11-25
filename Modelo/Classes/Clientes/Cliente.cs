using Modelo.Classes.Auxiliares;
using Modelo.Classes.Web;
using Modelo.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes.Clientes
{
    public abstract class Cliente
    {
        #region Props Principais
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long? ClienteId { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public TipoCliente Tipo { get; set; }
        #endregion

        #region Props de carregamento
        [JsonIgnore]
        public virtual ICollection<Veiculo> Veiculos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Motorista> Motoristas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Aluguel> Alugueis { get; set; }
        [JsonIgnore]
        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
        #endregion

        #region Props não Mapeadas
        [NotMapped]
        [JsonIgnore]
        public string AtivoTxt
        {
            get
            {
                return Ativo ? "Ativo" : "Inativo";
            }
        }
        #endregion

    }
}
