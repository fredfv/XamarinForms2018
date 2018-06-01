using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App3_JWTAsync.Model;


namespace App3_JWTAsync.Service
{
    class JWTService
    {

        private static string BaseURL = "http://ws.spacedu.com.br/xf2018/rest/apix";
        private static string Token;
        private static string TokenType;
        public async static Task<string> GetToken(string nome, string senha)
        {
            var URL = BaseURL + "/token";
            HttpClient requisicao = new HttpClient();

            var param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", nome),
                new KeyValuePair<string,string>("password", senha)
            });

            var resposta = await requisicao.PostAsync(URL, param);

            if(resposta.StatusCode == HttpStatusCode.OK)
            {
                var respostaToken = JsonConvert.DeserializeObject<RespostaToken>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Token = respostaToken.access_token;
                TokenType = respostaToken.token_type;
                return Token;
            }
            else
            {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        public async static Task<string> Verificar()
        {
            var URL = BaseURL + "/verify";

            HttpClient requisicao = new HttpClient();

            requisicao.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(TokenType, Token);
            var resposta = await requisicao.GetAsync(URL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var respostaToken = JsonConvert.DeserializeObject<RespostaToken>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return respostaToken.usuario.nome + " " + respostaToken.usuario.id;
            }
            else
            {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
