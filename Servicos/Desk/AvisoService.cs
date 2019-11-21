using Modelo.Classes.Desk;
using Modelo.Classes.Web;
using Modelo.Enums;
using Servicos.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Desk
{
    public class AvisoService
    {
        private AluguelService AluguelService = new AluguelService();
        private VeiculoService VeiculoService = new VeiculoService();
        private MotoristaService MotoristaService = new MotoristaService();
        private ViagemService ViagemService = new ViagemService();
        private FinancaService FinancaService = new FinancaService();

        public List<Aviso> ObterTodosOsAvisos()
        {
            try
            {
                List<Aviso> avisos = new List<Aviso>();
                avisos.AddRange(GerarAvisosDeAluguel());
                avisos.AddRange(GerarAvisosDeFinanca());
                avisos.AddRange(GerarAvisosDeMotorista());
                avisos.AddRange(GerarAvisosDeVeiculo());
                avisos.AddRange(GerarAvisosDeViagem());
                return avisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Aviso> GerarAvisosDeAluguel()
        {
            try
            {
                List<Aviso> avisos = new List<Aviso>();
                List<Aluguel> alugueis = AluguelService.ObterAlugueisOrdPorId().Where(a => a.EstadoDoAluguel == EstadosAluguel.VENCIDO || a.EstadoDoPagamento == EstadosDePagamento.VENCIDO).ToList();
                if (alugueis != null)
                {
                    foreach (Aluguel a in alugueis)
                    {
                        Aviso aviso = new Aviso();
                        aviso.Tipo = TiposDeAviso.ALUGUEL_IRREGULAR;
                        if (a.EstadoDoAluguel == EstadosAluguel.VENCIDO)
                        {
                            aviso.Mensagem = "O Aluguel de ID: " + a.AluguelId + ", expirou";
                        }
                        if (a.EstadoDoPagamento == EstadosDePagamento.VENCIDO)
                        {
                            aviso.Mensagem = "O Aluguel de ID: " + a.AluguelId + ", está com o pagamento vencido";
                        }
                        aviso.idObjeto = a.AluguelId;
                        avisos.Add(aviso);
                    }
                }
                return avisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Aviso> GerarAvisosDeVeiculo()
        {
            try
            {
                string mp;
                List<Aviso> avisos = new List<Aviso>();
                List<Veiculo> veiculos = VeiculoService.ObterVeiculosOrdPorId()
                    .Where(v => v.EstadoDoVeiculo == EstadosDeVeiculo.ACIDENTADO || v.EstadoDoVeiculo == EstadosDeVeiculo.SEM_COMBUSTIVEL)
                    .ToList();
                if (veiculos != null)
                {
                    foreach (Veiculo v in veiculos)
                    {
                        mp = "Veiculo de Placa: " + v.Placa + ", se encontra ";
                        Aviso aviso = new Aviso();
                        aviso.idObjeto = v.VeiculoId;
                        aviso.Tipo = TiposDeAviso.VEICULO_IRREGULAR;
                        if (v.EstadoDoVeiculo == EstadosDeVeiculo.SEM_COMBUSTIVEL)
                        {
                            aviso.Mensagem = mp + "sem combustível";
                        }
                        if (v.EstadoDoVeiculo == EstadosDeVeiculo.ACIDENTADO)
                        {
                            aviso.Mensagem = mp + "acidentado";
                        }
                        avisos.Add(aviso);
                    }
                }
                return avisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Aviso> GerarAvisosDeMotorista()
        {
            try
            {
                string mp;
                List<Aviso> avisos = new List<Aviso>();
                List<Motorista> motoristas = MotoristaService.ObterMotoristasOrdPorId()
                    .Where(m => m.Estado == EstadosDeMotorista.EXAME_MEDICO_VENCIDO ||
                                m.Estado == EstadosDeMotorista.PONTOS_CNH_ESTOURADOS ||
                                m.Estado == EstadosDeMotorista.ACIDENTADO).ToList();
                if (motoristas != null)
                {
                    foreach (Motorista m in motoristas)
                    {
                        mp = "Motorista de CPF: " + m.CPFTxt + ", se encontra ";
                        Aviso aviso = new Aviso();
                        aviso.idObjeto = m.MotoristaId;
                        aviso.Tipo = TiposDeAviso.MOTORISTA_IRREGULAR;
                        if (m.Estado == EstadosDeMotorista.EXAME_MEDICO_VENCIDO)
                        {
                            aviso.Mensagem = mp + "com exame vencido";
                        }
                        if (m.Estado == EstadosDeMotorista.PONTOS_CNH_ESTOURADOS)
                        {
                            aviso.Mensagem = mp + "com os pontos da cnh estourados";
                        }
                        if (m.Estado == EstadosDeMotorista.ACIDENTADO)
                        {
                            aviso.Mensagem = mp + "acidentado";
                        }
                        avisos.Add(aviso);
                    }
                }
                return avisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Aviso> GerarAvisosDeViagem()
        {
            try
            {
                string mp;
                List<Aviso> avisos = new List<Aviso>();
                List<Viagem> viagens = ViagemService.ObterViagensOrdPorId().Where(v => v.EstadoDaViagem == EstadosDeViagem.AGUARDANDO_INICIO && v.DataSaida < DateTime.Now).ToList();

                if (viagens != null)
                {
                    foreach (Viagem v in viagens)
                    {
                        mp = "Viagem de ID: " + v.ViagemId + ", ainda não foi iniciada e está atrasada";
                        Aviso aviso = new Aviso();
                        aviso.idObjeto = v.ViagemId;
                        aviso.Tipo = TiposDeAviso.VIAGEM_IRREGULAR;
                        aviso.Mensagem = mp;
                        avisos.Add(aviso);
                    }
                }
                return avisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Aviso> GerarAvisosDeFinanca()
        {
            try
            {
                List<Aviso> avisos = new List<Aviso>();
                List<Financa> financas = FinancaService.ObterFinancasOrdPorId().Where(f => f.EstadoPagamento == EstadosDePagamento.VENCIDO).ToList();

                if (financas != null)
                {
                    foreach (Financa f in financas)
                    {
                        Aviso aviso = new Aviso();
                        aviso.idObjeto = f.FinancaId;
                        aviso.Mensagem = "Finança de codigo: " + f.Codigo + ", está com pagamento atrasado";
                        aviso.Tipo = TiposDeAviso.PAGAMENTO_VENCIDO;
                        avisos.Add(aviso);
                    }
                }
                return avisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
