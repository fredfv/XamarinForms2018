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
        private static string URLPessoas = "http://192.168.1.31/api/pessoa/obtertodas";

        private static string URLMarcas = "http://192.168.1.31/api/marca/obtertodas";

        private static string URLProdutos = "http://192.168.1.31/api/produto/obtertodas/{0}";

       
        public static  List<Pessoa> GetPessoas()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(URLPessoas);

            return JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);  
        }

        public static List<Marca> GetMarcas()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(URLMarcas);

            return JsonConvert.DeserializeObject<List<Marca>>(conteudo);
        }

        public static List<Produto> GetProdutos(int marca)
        {
            string NewURL = string.Format(URLProdutos, marca);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NewURL);

            return JsonConvert.DeserializeObject<List<Produto>>(conteudo);
        }

    }
}
