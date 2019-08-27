using Servicos.Cliente;
using Servicos.Desk;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDesk.Serviço
{
    public static class ServicoDados
    {
        public static VeiculoService ServicoDadosVeiculos = new VeiculoService();
        public static ClienteService ServicoDadosClientes = new ClienteService();
        public static MultaService ServicoDadosMulta = new MultaService();
        public static SinistroService ServicoDadosSinistro = new SinistroService();
        public static MotoristaService ServicoDadosMotorista = new MotoristaService();
        public static GaragemService ServicoDadosGaragem = new GaragemService();
        public static AluguelService ServicoDadosAluguel = new AluguelService();
        public static ViagemService ServicoDadosViagem = new ViagemService();
        public static SolicitacaoService ServicoDadosSolicitacao = new SolicitacaoService();
        public static FinancaService ServicoDadosFinancas = new FinancaService();
    }
}
