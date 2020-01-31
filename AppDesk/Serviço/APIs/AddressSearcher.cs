using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes.Auxiliares;
using Modelo.Enums;
using Newtonsoft.Json;

namespace AppDesk.Serviço.APIs
{
    public class AddressSearcher
    {
        //Endereço retornado pela API
        private class APIAddress
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string unidade { get; set; }
            public string ibge { get; set; }
            public string gia { get; set; }
        }

        static HttpClient client = new HttpClient();

        /// <summary>
        /// Retorna um endereço de acordo com o CEP indicado
        /// </summary>
        /// <param name="cep">CEP que será utilizado pela api para buscar o endereço</param>
        /// <returns>Endereço no formato da aplicação</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Endereco> GetEnderecoByCEPAsync(string cep)
        {
            try
            {
                Endereco endereco = new Endereco() { CEP = cep };
                
                HttpResponseMessage request = await client.GetAsync(@"https://viacep.com.br/ws/" + cep + "/json/");
                
                if(request.IsSuccessStatusCode)
                {
                    string jsonString = await request.Content.ReadAsStringAsync();
                    
                    //Checa se a string de retorno contém erros
                    if(jsonString.Contains("erro"))
                    {
                        throw new Exception("CEP inválido");
                    }

                    //Converte a string JSON do endereço em um objeto
                    APIAddress address = JsonConvert.DeserializeObject<APIAddress>(jsonString);

                    endereco.Bairro = address.bairro;
                    endereco.Cidade = address.localidade;
                    endereco.Rua = address.logradouro;
                    endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), address.uf);
                }
                else
                {
                    throw new Exception("Falha ao conectar com o serviço de Busca!");
                }

                return endereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
