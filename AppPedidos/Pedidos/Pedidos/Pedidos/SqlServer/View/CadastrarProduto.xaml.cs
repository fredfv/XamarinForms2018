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
	public partial class CadastrarProduto : ContentPage
	{
        bool isCadastro { get; set; }
        bool ok { get; set; }
        Produto produtoNaPagina { get; set; }
        ListaProdutosPorMarca listaParaAtualizar { get; set; }
        DetalheProduto detalheParaAtualizar { get; set; }
        Marca marcaNaPagina { get; set; }

        //CADASTRAR
        public CadastrarProduto(ListaProdutosPorMarca lista, Marca marca)
        {
            InitializeComponent();

            marcaNaPagina = marca;
            listaParaAtualizar = lista;

            Cabecalho.Text = "Cadastrar";
            BtnCadastro.Text = "Enviar";
            isCadastro = true;
        }

        //EDITAR
        public CadastrarProduto(DetalheProduto detalhe, Produto produto)
        {
            InitializeComponent();
            BindingContext = produto;

            produtoNaPagina = produto;
            detalheParaAtualizar = detalhe;

            Cabecalho.Text = "Editar";
            BtnCadastro.Text = "Salvar";
            isCadastro = false;
        }

        private void EnviarDados(object sender, EventArgs args)
        {
            if (ValidaMarca() == 1)
            {
                Produto novoProduto = new Produto();
                novoProduto.nome = Nome.Text;
                novoProduto.codigo = int.Parse(Codigo.Text);

                if (!isCadastro)
                {
                    novoProduto.id = produtoNaPagina.id;
                    ok = ServiceWS.UpdateProduto(novoProduto, produtoNaPagina.idMarca);
                }
                else
                {
                    ok = ServiceWS.InsertProduto(novoProduto, marcaNaPagina.id);
                }

                if (ok)
                {
                    if (isCadastro)
                    {
                        Mensagem.Text = "Cadastro efetuado com sucesso";
                        listaParaAtualizar.Atualizar();
                    }
                    else
                    {
                        Mensagem.Text = "Dados alterados com sucesso";
                        detalheParaAtualizar.Atualizar();
                        //listaParaAtualizar.Atualizar();
                        //((App.Current.MainPage as MasterDetailPage).Detail as ListaProdutosPorMarca).Atualizar();
                    }
                }
                else
                {
                    if (isCadastro)
                    {
                        Mensagem.Text = "Ocorreu um erro no cadastro";
                    }
                    else
                    {
                        Mensagem.Text = "Ocorreu um erro durante a alteração dos dados";
                    }
                }
            }
            else if (ValidaMarca() == 2)
            {
                DisplayAlert("Error", "Favor verificar o preenchimento dos campos", "Ok");
            }
            else if (ValidaMarca() == 3)
            {
                DisplayAlert("Error", "Dados inconsistentes", "Ok");
            }


        }

        private int ValidaMarca()
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
    }
}