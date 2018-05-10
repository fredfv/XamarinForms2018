using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Models;

namespace Pedidos.SqlServer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaProdutosPorMarca : ContentPage
	{

        private List<Produto> ListaInterna { get; set; }
        private List<Produto> ListaFiltrada { get; set; }

        public ListaProdutosPorMarca (Marca marca)
		{
			InitializeComponent ();

            ListaInterna = Service.Service.GetProdutos(marca.id);
            Lista.ItemsSource = ListaInterna;
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Produto produto = (Produto)args.SelectedItem;

            Navigation.PushAsync(new DetalheProduto(produto));
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }
    }
}