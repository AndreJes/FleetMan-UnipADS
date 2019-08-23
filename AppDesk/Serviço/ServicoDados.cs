using Servicos.Cliente;
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
    }
}
