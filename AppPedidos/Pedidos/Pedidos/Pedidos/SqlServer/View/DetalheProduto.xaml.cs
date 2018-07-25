using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.Menu;
using Pedidos.SqlServer.Service;


namespace Pedidos.SqlServer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheProduto : ContentPage
	{
        public Produto produtoAtual { get; set; }
        ListaProdutos listaParaAtualizar { get; set; }

        public DetalheProduto(ListaProdutos lista, Produto produto)
        {
            InitializeComponent();
            if (Master.Permissao != 1)
            {
                ToolbarItems.RemoveAt(0);
                ToolbarItems.RemoveAt(0);
            }
            BindingContext = produto;
            listaParaAtualizar = lista;
            produtoAtual = produto;
        }

        private async void GoDeletar(object sender, EventArgs args)
        {
            Carregando.IsVisible = true;
            bool podeDeletar = false;

            var resultado = await DisplayAlert("EXCLUIR?", "Confirmar exclusão de:\n" + produtoAtual.nome + " ?", "NÃO", "SIM");
            podeDeletar = resultado ? false : true;

            if (podeDeletar)
            {
                try
                {
                    bool ok = await ServiceWS.DeleteProdutoAsync(produtoAtual);
                    if (ok)
                    {
                        await Navigation.PopAsync();
                        listaParaAtualizar.AtualizarAsync();
                    }
                }
                catch
                {
                    await DisplayAlert("Error", "Erro ao excluir produto", "Ok");
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
            Navigation.PushModalAsync(new CadastrarProduto(this, produtoAtual));
        }

        public async void AtualizarAsync()
        {
            try
            {
                List<Produto> produto = await ServiceWS.GetProdutoPorIdAsync(produtoAtual.id);
                BindingContext = produto[0];
                produtoAtual= produto[0];
                listaParaAtualizar.AtualizarAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar pagina", "Ok");
            }

        }
    }
}