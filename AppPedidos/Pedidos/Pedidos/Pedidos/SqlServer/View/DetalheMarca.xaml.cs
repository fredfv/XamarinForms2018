using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.SqlServer.Service;

namespace Pedidos.SqlServer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheMarca : ContentPage
	{
        public Marca marcaAtual { get; set; }
        ListaMarcas listaParaAtualizar { get; set; }

		public DetalheMarca (ListaMarcas lista, Marca marca)
		{
			InitializeComponent ();
            BindingContext = marca;
            listaParaAtualizar = lista;
            marcaAtual = marca;
        }

        private async void GoDeletar(object sender, EventArgs args)
        {
            Carregando.IsRunning = true;
            bool ok = await ServiceWS.DeleteMarcaAsync(marcaAtual);
            if (ok)
            {
                await Navigation.PopAsync();
                listaParaAtualizar.AtualizarAsync();
            }
        }

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarMarca(this));
        }

        public void Atualizar()
        {
            List<Marca> marca = ServiceWS.GetMarcaPorId(marcaAtual.id);
            BindingContext = marca[0];
            marcaAtual = marca[0];
            listaParaAtualizar.AtualizarAsync();
        }
	}
}