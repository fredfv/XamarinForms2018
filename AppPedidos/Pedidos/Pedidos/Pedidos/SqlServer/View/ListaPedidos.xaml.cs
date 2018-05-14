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
	public partial class ListaPedidos : ContentPage
	{
        private List<Pedido> ListaInterna { get; set; }
        //private List<Pedido> ListaFiltrada { get; set; }

        public ListaPedidos()
        {
            InitializeComponent();

            DateTime dataDeHoje = DateTime.Now;
            calendario.MaximumDate = DateTime.Now;

            ListaInterna = Service.ServiceWS.GetPedidos(dataDeHoje.ToString("dd/MM/yy"));
            Lista.ItemsSource = ListaInterna;
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Pedido pedido = (Pedido)args.SelectedItem;

            Navigation.PushAsync(new DetalhePedido(pedido));
        }

        private void Buscar(object sender, DateChangedEventArgs args)
        {
            ListaInterna = Service.ServiceWS.GetPedidos(args.NewDate.ToString("dd/MM/yy"));
            Lista.ItemsSource = ListaInterna;
        }
    }
}
