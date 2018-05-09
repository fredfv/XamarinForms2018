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
	public partial class PedidoView : ContentPage
	{
        private List<Pedido> ListaInternaPedidos { get; set; }
        private List<Pedido> ListaFiltradaPedidos { get; set; }

        public PedidoView()
        {
            InitializeComponent();
            //ListaInternaPedidos = Service.Service.GetPedidoPorId();
            //ListaPedidos.ItemsSource = ListaInternaPedidos;
        }


        //private void PedidoSelecionado(object sender, SelectedItemChangedEventArgs args)
        //{
        ////    Marca marca = (Marca)args.SelectedItem;

        ////    //Navigation.PushAsync(new PedidoPerfil(marca));
        //}

        private void BuscaPedidos(object sender, TextChangedEventArgs args)
        {
            ListaFiltradaPedidos = Service.Service.GetPedidoPorId(int.Parse(args.NewTextValue));
            ListaPedidos.ItemsSource = ListaFiltradaPedidos;
        }
    }
}