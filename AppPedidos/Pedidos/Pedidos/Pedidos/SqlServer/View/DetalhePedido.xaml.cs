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

        public DetalhePedido (Pedido pedido)
		{
			InitializeComponent ();
            if (Master.Permissao != 1)
            {
                ToolbarItems.RemoveAt(0);
            }
            BindingContext = pedido;
            pedidoAtual = pedido;
            Atualizar();
		}

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new EditarPedido(pedidoAtual));
        }

        private async void Atualizar()
        {
            NomeProduto.Text = pedidoAtual.nomeProduto;

            List<Produto> produto = await ServiceWS.GetProdutoPorIdAsync(pedidoAtual.idProduto);

            NomeMarca.Text = produto[0].nomeMarca;
        }
    }
}