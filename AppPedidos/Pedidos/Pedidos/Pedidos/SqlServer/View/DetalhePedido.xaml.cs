using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;

namespace Pedidos.SqlServer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePedido : ContentPage
	{
		public DetalhePedido (Pedido pedido)
		{
			InitializeComponent ();
            BindingContext = pedido;

            NomeProduto.Text = pedido.nomeProduto;

            List<Produto> produto = Service.ServiceWS.GetProdutoPorId(pedido.idProduto);

            NomeMarca.Text = produto[0].nomeMarca;

		}
	}
}