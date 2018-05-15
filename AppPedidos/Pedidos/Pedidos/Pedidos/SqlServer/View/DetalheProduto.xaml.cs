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
	public partial class DetalheProduto : ContentPage
	{
        Produto produtoAtual { get; set; }

        public DetalheProduto (Produto produto)
		{
			InitializeComponent ();
            BindingContext = produto;

            produtoAtual = produto;
		}


        private void GoDeletar(object sender, EventArgs args)
        {
            List<Marca> marcaAux = ServiceWS.GetMarcaPorId(produtoAtual.idMarca);
            ServiceWS.DeleteProduto(produtoAtual);
            Navigation.PushAsync(new ListaProdutosPorMarca(marcaAux[0]));
        }

        private void GoEditar(object sender, EventArgs args)
        {
            List<Marca> marcaAux = ServiceWS.GetMarcaPorId(produtoAtual.idMarca);
            Navigation.PushModalAsync(new CadastrarProduto(marcaAux[0], produtoAtual));
        }

        private void AtualizarAction(object sender, EventArgs args)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            List<Produto> produtoAtualizado = ServiceWS.GetProdutoPorId(produtoAtual.id);
            BindingContext = produtoAtualizado[0];
        }

    }
}