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
        Produto produtoNaPagina { get; set; }

        Marca marcaNaPagina { get; set; }
        bool ok { get; set; }

        public CadastrarProduto (Marca marca, Produto produto = null)
		{
			InitializeComponent ();
            BindingContext = produto;
            marcaNaPagina = marca;

            if (produto != null)
            {
                BtnCadastro.Text = "Salvar";
                isCadastro = false;
                produtoNaPagina = produto;
            }
            else
            {
                BtnCadastro.Text = "Cadastrar";
                isCadastro = true;
            }
        }

        private void Cadastrar(object sender, EventArgs args)
        {
            Produto novoProduto = new Produto();
            novoProduto.nome = Nome.Text;
            novoProduto.codigo = int.Parse(Codigo.Text);

            if (!isCadastro)
            {
                novoProduto.id = produtoNaPagina.id;
                ok = ServiceWS.UpdateProduto(novoProduto, marcaNaPagina.id);
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
                }
                else
                {
                    Mensagem.Text = "Dados alterados com sucesso";
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

        private void FecharModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}