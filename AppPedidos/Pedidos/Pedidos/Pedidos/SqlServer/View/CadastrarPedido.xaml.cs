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

            List<Marca> marca = ServiceWS.GetMarcaPorId(produto.idMarca);
            Marca.Text = marca[0].nome;

            IdProduto = produto.id;
		}

        private void Cadastrar(object sender, EventArgs args)
        {
            Pedido novoPedido = new Pedido()
            {
                idUsuarioInclusao = Pedidos.Menu.Master.IdLogado,
                idProduto = IdProduto,
                perda = int.Parse(Perda.Text),
                troca = int.Parse(Troca.Text),
                quantidade = int.Parse(Quantidade.Text),
                obs = Obs.Text
            };

            bool ok = ServiceWS.InsertPedidos(novoPedido);

            if (ok)
            {
                Mensagem.Text = "Cadastro efetuado com sucesso";
            }
            else
            {
                Mensagem.Text = "Ocorreu um erro no cadastro";
            }
        }


        private void FecharModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}