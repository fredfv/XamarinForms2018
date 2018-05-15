using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;

namespace Pedidos.SqlServer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaProdutosPorMarca : ContentPage
	{
        private List<Produto> ListaInterna { get; set; }
        private List<Produto> ListaFiltrada { get; set; }
        Marca marcaAtual { get; set; }

        public ListaProdutosPorMarca (Marca marca)
		{
			InitializeComponent ();
            marcaAtual = marca;
            Atualizar();
        }

        private void Atualizar()
        {
            ListaInterna = Service.ServiceWS.GetProdutos(marcaAtual.id);
            Lista.ItemsSource = ListaInterna;
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Produto produto = (Produto)args.SelectedItem;
            Navigation.PushAsync(new CadastrarPedido(produto));
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarProduto(marcaAtual));
        }

        private void AtualizarAction(object sender, EventArgs args)
        {
            Atualizar();
        }

    }
}