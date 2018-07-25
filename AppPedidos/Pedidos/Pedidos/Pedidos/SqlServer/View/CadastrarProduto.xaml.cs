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
	public partial class CadastrarProduto : ContentPage
	{
        bool isCadastro { get; set; }
        Produto produtoNaPagina { get; set; }
        Marca marcaNaPagina { get; set; }
        ListaProdutos listaParaAtualizar { get; set; }
        DetalheProduto detalheParaAtualizar { get; set; }
        private string nomeProdutoOriginal { get; set; }
        private int codigoProdutoOriginal { get; set; }

        //CADASTRAR
        public CadastrarProduto(ListaProdutos lista, Marca marca)
        {
            InitializeComponent();

            marcaNaPagina = marca;
            listaParaAtualizar = lista;

            Cabecalho.Text = "Cadastrar";
            BtnEnviar.Text = "Enviar";

            isCadastro = true;
        }

        //EDITAR
        public CadastrarProduto(DetalheProduto detalhe, Produto produto)
        {
            InitializeComponent();

            nomeProdutoOriginal = detalhe.produtoAtual.nome;
            codigoProdutoOriginal = detalhe.produtoAtual.codigo;

            produtoNaPagina = produto;
            
            BindingContext = detalhe.produtoAtual;

            detalheParaAtualizar = detalhe;

            Cabecalho.Text = "Editar";
            BtnEnviar.Text = "Salvar";

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

            if (Nome.Text == nomeProdutoOriginal)
                alterado++;
            if (int.Parse(Codigo.Text) == codigoProdutoOriginal)
                alterado++;

            if (alterado == 2)
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
                    var resultado = await DisplayAlert("Atualizar?", "Deseja atualizar os dados de:\n" + nomeProdutoOriginal + "?", "NÂO", "SIM");
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
                    if (ValidaProduto() == 1)
                    {
                        Nome.IsEnabled = false;
                        Codigo.IsEnabled = false;
                        BtnEnviar.IsEnabled = false;

                        Produto novoProduto = new Produto
                        {
                            nome = Nome.Text,
                            codigo = int.Parse(Codigo.Text)
                        };

                        if (!isCadastro)
                        {
                            novoProduto.id = produtoNaPagina.id;
                            try
                            {
                                bool ok = await ServiceWS.UpdateProdutoAsync(novoProduto, produtoNaPagina.idMarca);
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
                                bool ok = await ServiceWS.InsertProdutoAsync(novoProduto, marcaNaPagina.id);
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
                    else if (ValidaProduto() == 2)
                    {
                        await DisplayAlert("Error", "Favor verificar o preenchimento dos campos", "Ok");
                    }
                    else if (ValidaProduto() == 3)
                    {
                        await DisplayAlert("Error", "Dados inconsistentes", "Ok");
                    }
                }
                else
                {
                    SemConexao();
                }
            }
            Carregando.IsVisible = false;
        }

        private int ValidaProduto()
        {
            /*
             1 = ok
             2 = campo vazio
             3 = campo com valores errados
             */
            bool sNome = string.IsNullOrEmpty(Nome.Text);
            bool sCodigo = string.IsNullOrEmpty(Codigo.Text);

            if (!sNome && !sCodigo)
            {
                bool bCodigo = Codigo.Text.All(char.IsDigit);

                if (bCodigo)
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