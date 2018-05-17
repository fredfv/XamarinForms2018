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
	public partial class DetalhePedido : ContentPage
	{
        Pedido pedidoAtual { get; set; }

        public DetalhePedido (Pedido pedido)
		{
			InitializeComponent ();
            BindingContext = pedido;

            pedidoAtual = pedido;

            Atualizar();
		}

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new EditarPedido(pedidoAtual));
        }

        private void Atualizar()
        {
            NomeProduto.Text = pedidoAtual.nomeProduto;

            List<Produto> produto = Service.ServiceWS.GetProdutoPorId(pedidoAtual.idProduto);

            NomeMarca.Text = produto[0].nomeMarca;
        }
    }
}