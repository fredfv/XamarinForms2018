using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace App5.Service
{
	public class ServiceCEP
	{
		private static string url = "http://viacep.com.br/ws/{0}/json/";

		public async static Task<string> GetCepAsync(string cep)
		{
			var URL = string.Format(url, cep);

			WebClient web = new WebClient();

			string Resultado = await web.DownloadStringTaskAsync(new Uri(URL));

			return Resultado;
		}
		public static void GetCepAssincrono(string cep)
		{
			var URL = string.Format(url, cep);

			WebClient web = new WebClient();

			web.DownloadStringAsync(new Uri(URL));
			web.DownloadStringCompleted += AposFinalizarChamarEsteMetodo;
		}
		public static void AposFinalizarChamarEsteMetodo(object sender, DownloadStringCompletedEventArgs args)
		{
			//Faça algo.
			//Exemplo: Altera o valor de uma propriedade de uma classe que esteja vinculado a tela, uma propriedade bindable (MVVM).
		}
	}
}
