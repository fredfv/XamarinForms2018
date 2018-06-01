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
        ListaProdutosPorMarca listaParaAtualizar { get; set; }

        public DetalheProduto (ListaProdutosPorMarca lista, Produto produto)
		{
			InitializeComponent ();
            BindingContext = produto;

            listaParaAtualizar = lista;
            produtoAtual = produto;
		}

        private void GoDeletar(object sender, EventArgs args)
        {
            ServiceWS.DeleteProduto(produtoAtual);
            Navigation.PopAsync();
            listaParaAtualizar.Atualizar();
        }

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarProduto(this, produtoAtual));
        }

        public void Atualizar()
        {
            List<Produto> produto = ServiceWS.GetProdutoPorId(produtoAtual.id);
            BindingContext = produto[0];
            produtoAtual = produto[0];
            listaParaAtualizar.Atualizar();
        }
    }
}