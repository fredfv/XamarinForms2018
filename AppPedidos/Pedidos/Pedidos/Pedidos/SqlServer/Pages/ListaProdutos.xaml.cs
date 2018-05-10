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
	public partial class ListaProdutos : ContentPage
	{

        private List<Marca> ListaInterna { get; set; }
        private List<Marca> ListaFiltrada { get; set; }

        public ListaProdutos()
        {
            InitializeComponent();
            ListaInterna = Service.Service.GetMarcas();
            Lista.ItemsSource = ListaInterna;
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Marca marca = (Marca)args.SelectedItem;

            Navigation.PushAsync(new ListaProdutosPorMarca(marca));
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }
    }
}