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

            //List<Produto> produto = Service.Service.GetProdutoPorId(pedido.idProduto);
            //NomeProduto.Text = produto[0].nome;

            //List<Marca> marca = Service.Service.GetMarcaPorId(produto[0].)


            BindingContext = pedido;
		}
	}
}