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

        public void Atualizar()
        {
            ListaInterna = Service.ServiceWS.GetProdutos(marcaAtual.id);
            Lista.ItemsSource = ListaInterna;
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower()) || a.codigo.ToString().Contains(args.NewTextValue)).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }

        private void GoDetalhe(object sender, ItemTappedEventArgs args)
        {
            Produto produto = (Produto)args.Item;
            Navigation.PushAsync(new DetalheProduto(this, produto));
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarProduto(this, marcaAtual));
        }
    }
}