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
    public partial class EditarPedido : ContentPage
    {
        private int IdProduto { get; set; }
        List<Produto> produto { get; set; }

        public EditarPedido(Pedido pedido)
        {
            InitializeComponent();
            BindingContext = pedido;

            AtualizarAsync(pedido);

        }

        private async void AtualizarAsync(Pedido pedido)
        {
            produto = await ServiceWS.GetProdutoPorIdAsync(pedido.idProduto);
            Marca.Text = produto[0].nomeMarca;
            IdProduto = pedido.idProduto;
        }

        private async void Editar(object sender, EventArgs args)
        {
            if (ValidaPedido() == 1)
            {
                Perda.IsEnabled = false;
                Troca.IsEnabled = false;
                Quantidade.IsEnabled = false;
                Obs.IsEnabled = false;
                BtnCadastro.IsEnabled = false;

                Pedido novoPedido = new Pedido()
                {
                    idUsuarioInclusao = Menu.Master.IdLogado,
                    idProduto = IdProduto,
                    perda = int.Parse(Perda.Text),
                    troca = int.Parse(Troca.Text),
                    quantidade = int.Parse(Quantidade.Text),
                    obs = Obs.Text
                };

                bool ok = ServiceWS.UpdatePedido(novoPedido, Menu.Master.IdLogado);
                if (ok)
                {
                    await DisplayAlert("Sucesso!", "Pedido atualizado com sucesso", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "Ocorreu um erro na edição do pedido", "Ok");
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