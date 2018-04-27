using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using Newtonsoft.Json;

using App2_ListaBrasil.Modelo;
namespace App2_ListaBrasil.Servico
{
    public class Servico
    {
        private static string URLEstado = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/";
        //{0} PARAMETRO 0
        private static string URLMunicipio = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";


        public static List<Estado> GetEstados()
        {
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(URLEstado);
            return JsonConvert.DeserializeObject<List<Estado>>(conteudo);
        }

        public static List<Municipio> GetMunicipio(int estado)
        {
            //usando o string.format para adicionar na string o elemento ESTADO que é o ID 
            string newUrl = string.Format(URLMunicipio, estado);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(newUrl);
            return JsonConvert.DeserializeObject<List<Municipio>>(conteudo);
        }
    }
}

//CASO OCORRER ERROS, DEVE SE USAR UM TRY CATCH VERIFICAR QUAL SITUACAO
//VER AS EXCPTIONS, PARA TRATAR TAIS ERROS.