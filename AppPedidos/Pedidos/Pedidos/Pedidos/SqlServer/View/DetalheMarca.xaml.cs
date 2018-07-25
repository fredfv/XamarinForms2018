using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.SqlServer.Service;
using Pedidos.Menu;

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
            if (Master.Permissao != 1)
            {
                ToolbarItems.RemoveAt(0);
                ToolbarItems.RemoveAt(0);
            }
            BindingContext = marca;
            listaParaAtualizar = lista;
            marcaAtual = marca;
        }

        private async void GoDeletar(object sender, EventArgs args)
        {
            Carregando.IsVisible = true;
            bool podeDeletar = false;

            var resultado = await DisplayAlert("EXCLUIR?", "Confirmar exclusão de:\n" + marcaAtual.nome + " ?", "NÃO", "SIM");
            podeDeletar = resultado ? false : true ;

            if (podeDeletar)
            {
                try
                {
                    bool ok = await ServiceWS.DeleteMarcaAsync(marcaAtual);
                    if (ok)
                    {
                        await Navigation.PopAsync();
                        listaParaAtualizar.AtualizarAsync();
                    }
                }
                catch
                {
                    await DisplayAlert("Error", "Erro ao excluir marca", "Ok");
                    Carregando.IsVisible = false;
                }
            }
            else
            {
                Carregando.IsVisible = false;
            }
        }

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarMarca(this));
        }

        public async void AtualizarAsync()
        {
            try
            {
                List<Marca> marca = await ServiceWS.GetMarcaPorIdAsync(marcaAtual.id);
                BindingContext = marca[0];
                marcaAtual = marca[0];
                listaParaAtualizar.AtualizarAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar pagina", "Ok");
            }
       
        }
	}
}