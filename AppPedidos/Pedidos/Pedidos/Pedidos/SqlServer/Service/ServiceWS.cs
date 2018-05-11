using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using Pedidos.SqlServer.Models;
using Newtonsoft.Json;


namespace Pedidos.SqlServer.Service
{
    class ServiceWS
    {

        private static string EnderecoBase = "http://192.168.1.38/api";

        public static List<Pessoa> GetPessoaPorId(int id)
        {
            var URL = EnderecoBase+"/pessoa/obterporid/{0}";
            string NewURL = string.Format(URL, id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(NewURL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pessoa> pessoa = JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);
                    return pessoa;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static List<Pessoa> GetPessoas()
        {
            var URL = EnderecoBase + "/pessoa/obtertodas";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pessoa> pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);
                    return pessoas;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
