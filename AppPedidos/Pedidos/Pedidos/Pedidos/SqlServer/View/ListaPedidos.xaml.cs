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
        private bool podeBuscar { get; set; }

        public ListaPedidos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AtualizarAsync();
        }

        public async void AtualizarAsync()
        {
            podeBuscar = false;
            Carregando.IsVisible = true;

            try
            {
                DateTime dataDeHoje = DateTime.Now;
                calendario.MaximumDate = DateTime.Now;
                ListaInterna = await Service.ServiceWS.GetPedidosAsync(dataDeHoje.ToString("dd/MM/yy"));
                podeBuscar = true;
                Lista.ItemsSource = ListaInterna;
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar pedidos", "Ok");
                podeBuscar = false;
                ErrorLista.IsVisible = true;
            }
            Carregando.IsVisible = false;

            if (ListaInterna != null)
            {
                podeBuscar = true;
            }
        }

        private async void Buscar(object sender, DateChangedEventArgs args)
        {
            if (podeBuscar)
            {
                try
                {
                    ListaInterna = await Service.ServiceWS.GetPedidosAsync(args.NewDate.ToString("dd/MM/yy"));
                    Lista.ItemsSource = ListaInterna;
                }
                catch
                {
                    await DisplayAlert("Error", "Erro ao carregar pedidos", "Ok");
                    podeBuscar = false;
                    ErrorLista.IsVisible = true;
                }
            }
        }

        private void GoDetalhe(object sender, ItemTappedEventArgs args)
        {
            Pedido pedido = (Pedido)args.Item;
            (sender as ListView).SelectedItem = null;
            Navigation.PushAsync(new DetalhePedido(this, pedido));
        }
    }
}
