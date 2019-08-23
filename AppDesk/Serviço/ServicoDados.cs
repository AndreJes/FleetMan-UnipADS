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
    }
}
