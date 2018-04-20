using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            //busca na internet
            WebClient wc = new WebClient();
            //Usando metodo sincrono ele trava a tela e nao faz nada em segundo plano


            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            //Tratar exption aqui. pois acessa fora do app



            //Agora precisa deserializar
            //Pegar o texo e converter para um objeto do tipo endereco
            //Aqui eu falo para deserializar o Conteudo e converter no objeto do tipo Endereco
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            //retornando o endereco;
            //se a instancia vier sem valores

            if (end.cep == null) return null;

            return end;
        }
    }
}
