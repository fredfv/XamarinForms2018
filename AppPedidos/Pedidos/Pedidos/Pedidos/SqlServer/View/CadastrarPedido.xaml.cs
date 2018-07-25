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
    public partial class CadastrarPedido : ContentPage
    {
        private bool isCadastro { get; set; }
        private int IdProduto { get; set; }
        private int IdPedido { get; set; }
        
        private int perdaOriginal { get; set; }
        private int trocaOriginal { get; set; }
        private int quantidadeOriginal {get; set; }
        private string obsOriginal {get; set; }

        ListaProdutos listaParaAtualizar { get; set; }
        DetalhePedido detalheParaAtualizar { get; set; }

        //CADASTRAR
		public CadastrarPedido (Produto produto, ListaProdutos lista)
		{
			InitializeComponent ();
            listaParaAtualizar = lista;
            BtnCadastro.Text = "Cadastrar";
            Cabecalho.Text = "Gerar novo pedido";

            MarcaProduto.Text = produto.nomeMarca;
            NomeProduto.Text = produto.nome;
            IdProduto = produto.id;

            Carregando.IsVisible = false;
            isCadastro = true;
		}

        //EDITAR
        public CadastrarPedido(Pedido pedido, Produto produto, DetalhePedido detalhe)
        {
            InitializeComponent();
            detalheParaAtualizar = detalhe;
            IdPedido = pedido.id;
            IdProduto = produto.id;

            BtnCadastro.Text = "Editar";
            Cabecalho.Text = "Editar pedido";

            NomeProduto.Text = pedido.nomeProduto;
            MarcaProduto.Text = produto.nomeMarca;
            Perda.Text = pedido.perda.ToString();
            perdaOriginal = pedido.perda;
            Troca.Text = pedido.troca.ToString();
            trocaOriginal = pedido.troca;
            Quantidade.Text = pedido.quantidade.ToString();
            quantidadeOriginal = pedido.quantidade;
            Obs.Text = pedido.obs;
            obsOriginal = pedido.obs;

            Carregando.IsVisible = false;
            isCadastro = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SlTitulo.BackgroundColor = Master.CorPermissao;
        }

        private bool checarAlteracao()
        {
            int alterado = 0;

            if (int.Parse(Perda.Text) == perdaOriginal)
                alterado++;
            if (int.Parse(Troca.Text) == trocaOriginal)
                alterado++;
            if (int.Parse(Quantidade.Text) == quantidadeOriginal)
                alterado++;
            if (Obs.Text == obsOriginal)
                alterado++;


            if (alterado == 4)
                return false;
            else
                return true;
        }

        private async void EnviarDados(object sender, EventArgs args)
        {
            bool podeAtualizar = false;
            Carregando.IsVisible = true;

            if (checarAlteracao())
            {
                if (!isCadastro)
                {
                    var resultado = await DisplayAlert("Atualizar?", "Deseja atualizar o Pedido?", "NÂO", "SIM");
                    podeAtualizar = resultado ? false : true;
                }
                else
                {
                    podeAtualizar = true;
                }
            }
            else
            {
                await DisplayAlert("Error", "Não ocorreu nenhuma alteração de dados", "Ok");
            }

            if (podeAtualizar)
            {
                if (VerificarConexao.TemInternet())
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
                            idProduto = IdProduto,
                            perda = int.Parse(Perda.Text),
                            troca = int.Parse(Troca.Text),
                            quantidade = int.Parse(Quantidade.Text),
                            obs = Obs.Text
                        };

                        if (!isCadastro)
                        {
                            novoPedido.id = IdPedido;
                            try
                            {
                                bool ok = await ServiceWS.UpdatePedidoAsync(novoPedido);
                                if (ok)
                                {
                                    detalheParaAtualizar.AtualizarAsync();
                                    await Navigation.PopModalAsync();
                                }
                                else
                                {
                                    await DisplayAlert("Error", "Ocorreu um erro durante a alteração dos dados", "Ok");
                                    await Navigation.PopModalAsync();
                                }
                            }
                            catch
                            {
                                await DisplayAlert("Error", "Ocorreu um erro durante a alteração dos dados", "Ok");
                                await Navigation.PopModalAsync();
                            }
                        }
                        else
                        {
                            try
                            {
                                bool ok = await ServiceWS.InsertPedidoAsync(novoPedido);
                                if (ok)
                                {
                                    listaParaAtualizar.AtualizarAsync();
                                    await Navigation.PopModalAsync();
                                }
                                else
                                {
                                    await DisplayAlert("Error", "Ocorreu um erro no cadastro", "Ok");
                                    await Navigation.PopModalAsync();
                                }
                            }
                            catch
                            {
                                await DisplayAlert("Error", "Ocorreu um erro no cadastro", "Ok");
                                await Navigation.PopModalAsync();
                            }
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
                else
                {
                    SemConexao();
                }
                Carregando.IsVisible = false;
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

        private void SemConexao()
        {
            DisplayAlert("Error", "Não há conexão com a Internet", "Ok");
        }
    }
}