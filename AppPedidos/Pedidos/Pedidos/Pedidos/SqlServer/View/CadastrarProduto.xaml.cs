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
        bool isCadastaro { get; set; }
        Produto produtoNaPagina { get; set; }
        Marca marcaNaPagina { get; set; }

        public CadastrarProduto (Marca marca, Produto produto = null)
		{
			InitializeComponent ();
            BindingContext = produto;
            marcaNaPagina = marca;

            if (produto != null)
            {
                BtnCadastro.Text = "Salvar";
                isCadastaro = false;
                produtoNaPagina = produto;
            }
            else
            {
                BtnCadastro.Text = "Cadastrar";
                isCadastaro = true;
            }
        }

        private void Cadastrar(object sender, EventArgs args)
        {
            Produto novoProduto = new Produto();
            novoProduto.nome = Nome.Text;
            novoProduto.codigo = int.Parse(Codigo.Text);

            if (!isCadastaro)
            {
                novoProduto.id = produtoNaPagina.id;
                teste.Text = produtoNaPagina.id.ToString();
            }

            bool ok = ServiceWS.InsertProduto(produtoNaPagina, marcaNaPagina);


            if (ok)
            {
                if (isCadastaro)
                {
                    Mensagem.Text = "Cadastro efetuado com sucesso";
                }
                else
                {
                    Mensagem.Text = "Dados alterados com sucesso";
                }
            }
            else
            {
                if (isCadastaro)
                {
                    Mensagem.Text = "Ocorreu um erro no cadastro";
                }
                else
                {
                    Mensagem.Text = "Ocorreu um erro durante a alteração dos dados";
                }
            }
        }

        private void FecharModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}