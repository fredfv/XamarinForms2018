using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Pedidos.SqlServer.Models;
using Newtonsoft.Json;

namespace Pedidos.SqlServer.Service
{
    class Service
    {
        private static string URLBase = "http://192.168.1.38/api/";
        
        private static string URLPessoas = URLBase+"pessoa/obtertodas";
        private static string URLPessoaPorId = URLBase+"pessoa/obterporid/{0}";

        private static string URLMarcas = URLBase+"marca/obtertodas";
        private static string URLMarcaPorId = URLBase+"marca/obterporid/{0}";

        private static string URLProdutos = URLBase+"produto/obtertodas/{0}";
        private static string URLProdutoPorId = URLBase+"produto/obterporid/{0}";

        private static string URLPedidos = URLBase+"pedido/obterTodas/{0}";
        private static string URLPedidoPorId = URLBase+"pedido/obterporid/{0}";

        //-------------------
        //PESSOAS
        public static List<Pessoa> GetPessoas()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(URLPessoas);

            return JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);  
        }

        public static List<Pessoa> GetPessoaPorId(int id)
        {
            string NewURL = string.Format(URLPessoaPorId, id);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);
        }
        //-------------------
        //MARCAS
        public static List<Marca> GetMarcas()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(URLMarcas);

            return JsonConvert.DeserializeObject<List<Marca>>(conteudo);
        }

        public static List<Marca> GetMarcaPorId(int id)
        {
            string NewURL = string.Format(URLMarcaPorId, id);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Marca>>(conteudo);
        }
        //-------------------
        //PRODUTOS
        public static List<Produto> GetProdutos(int marca)
        {
            string NewURL = string.Format(URLProdutos, marca);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Produto>>(conteudo);
        }

        public static List<Produto> GetProdutoPorId(int id)
        {
            string NewURL = string.Format(URLProdutoPorId, id);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Produto>>(conteudo);
        }
        //-------------------
        //PEDIDOS
        public static List<Pedido> GetPedidos(string data)
        {
            string dataParaEnvio = "?Data=" + data;

            string NewURL = string.Format(URLPedidos, dataParaEnvio);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Pedido>>(conteudo);
        }

        public static List<Pedido> GetPedidoPorId(int id)
        {
            string NewURL = string.Format(URLPedidoPorId, id);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Pedido>>(conteudo);
        }
    }
}
