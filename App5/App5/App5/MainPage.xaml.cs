using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			/*
			- Para chamar em um construtor basta chamar sem o Await. Assim:
			Service.ServiceCEP.GetCepAsync("72318204"); Mas não deve ser esperado a informação de retorno, aqui uma boa opção é implementar o DownloadCompleted para esta modalidade.

			- Se quiser esperar o retorno use 2 métodos seguintes:
			var ResultadoString = Service.ServiceCEP.GetCepAsync("72318204").GetAwaiter().GetResult();
			*/

		}
		public async void Buscar(object sender, EventArgs args)
		{
			string resultado = await Service.ServiceCEP.GetCepAsync("72318204");
			Resultado.Text = resultado;

		}
	}
}
