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
	public partial class CadastrarPedido : ContentPage
	{
        private int IdProduto { get; set; }

		public CadastrarPedido (Produto produto)
		{
			InitializeComponent ();
            BindingContext = produto;
            AtualizarAsync(produto);
		}

        private async void AtualizarAsync(Produto prod)
        {
            List<Marca> marca = await ServiceWS.GetMarcaPorIdAsync(prod.idMarca);
            Marca.Text = marca[0].nome;
            IdProduto = prod.id;
            Carregando.IsVisible = false;
        }

        private async void Cadastrar(object sender, EventArgs args)
        {
            Carregando.IsVisible = true;
            if (ValidaPedido() == 1)
            {
                Perda.IsEnabled = false;
                Troca.IsEnabled = false;
                Quantidade.IsEnabled = false;
                Obs.IsEnabled = false;
                BtnCadastro.IsEnabled = false;

                Pedido novoPedido = new Pedido()
                {
                    idUsuarioInclusao = Pedidos.Menu.Master.IdLogado,
                    idProduto = IdProduto,
                    perda = int.Parse(Perda.Text),
                    troca = int.Parse(Troca.Text),
                    quantidade = int.Parse(Quantidade.Text),
                    obs = Obs.Text
                };

                bool ok = await ServiceWS.InsertPedidoAsync(novoPedido);
                if (ok)
                {
                    await DisplayAlert("Error", "Cadastro efetuado com sucesso", "Ok");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Ocorreu um erro no cadastro", "Ok");
                }
            }
            else if (ValidaPedido() == 2)
            {
                await DisplayAlert("Error", "Favor verificar o preenchimento dos campos", "Ok");
            }
            else if (ValidaPedido() == 3)
            {
                await DisplayAlert("Error", "Dados inconsistentes", "Ok");
            }
            Carregando.IsVisible = false;
        }

        private int ValidaPedido()
        {
            /*
             1 = ok
             2 = campo vazio
             3 = campo com valores errados
             */
            bool sPerda = string.IsNullOrEmpty(Perda.Text);
            bool sTroca = string.IsNullOrEmpty(Troca.Text);
            bool sQuantidade = string.IsNullOrEmpty(Quantidade.Text);

            if (!sPerda && !sTroca && !sQuantidade)
            {
                bool bPerda = Perda.Text.All(char.IsDigit);
                bool bTroca = Troca.Text.All(char.IsDigit);
                bool bQuantidade = Quantidade.Text.All(char.IsDigit);

                if (bPerda && bTroca && bQuantidade)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }
        }

        private void FecharModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}