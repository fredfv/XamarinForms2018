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
	public partial class MarcaView : ContentPage
	{

        private List<Marca> ListaInternaMarcas { get; set; }
        private List<Marca> ListaFiltradaMarcas { get; set; }

        public MarcaView ()
		{
			InitializeComponent ();
            ListaInternaMarcas = Service.Service.GetMarcas();
            ListaMarcas.ItemsSource = ListaInternaMarcas; 
		}


        private void MarcaSelecionada(object sender, SelectedItemChangedEventArgs args)
        {
            Marca marca = (Marca)args.SelectedItem;

            Navigation.PushAsync(new ProdutoView(marca));
        }

        private void BuscaMarca(object sender, TextChangedEventArgs args)
        {
            ListaFiltradaMarcas = ListaInternaMarcas.Where(a => a.nome.Contains(args.NewTextValue)).ToList();
            ListaMarcas.ItemsSource = ListaFiltradaMarcas;
        }
    }
}