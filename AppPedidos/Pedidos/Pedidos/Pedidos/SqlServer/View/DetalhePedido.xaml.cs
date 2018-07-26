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
	public partial class DetalhePedido : ContentPage
	{
        Pedido pedidoAtual { get; set; }
        List<Produto> produto { get; set; }
        ListaPedidos listaParaAtualizar { get; set; }

        public DetalhePedido (ListaPedidos lista, Pedido pedido)
		{
			InitializeComponent ();
            if (Master.Permissao != 1)
            {
                ToolbarItems.RemoveAt(0);
            }
            BindingContext = pedido;
            listaParaAtualizar = lista;
            pedidoAtual = pedido;
            PegarMarca();
		}

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarPedido(pedidoAtual, produto[0], this));
        }

        public async void PegarMarca()
        {
            produto = await ServiceWS.GetProdutoPorIdAsync(pedidoAtual.idProduto);
            NomeMarca.Text = produto[0].nomeMarca;
        }

        public async void AtualizarAsync()
        {
            try
            {
                List<Pedido> pedido = await ServiceWS.GetPedidoPorIdAsync(pedidoAtual.id);
                BindingContext = pedido[0];
                pedidoAtual = pedido[0];
                listaParaAtualizar.AtualizarAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar pagina", "Ok");
            }
        }
    }
}