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
    public partial class ListaMarcas : ContentPage
    {
        private List<Marca> ListaInterna { get; set; }
        private List<Marca> ListaFiltrada { get; set; }
        private bool podeBuscar { get; set; }

        public ListaMarcas()
        {
            InitializeComponent();
            AtualizarAsync();
        }

        public async void AtualizarAsync()
        {
            podeBuscar = false;
            Carregando.IsVisible = true;
            ListaInterna = await Service.ServiceWS.GetMarcasAsync();
            Lista.ItemsSource = ListaInterna;
            Carregando.IsVisible = false;
            podeBuscar = true;
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            if (podeBuscar)
            {
                ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower()) || a.codigo.ToString().Contains(args.NewTextValue)).ToList();
                Lista.ItemsSource = ListaFiltrada;
            }
        }

        private void GoDetalhe(object sender, ItemTappedEventArgs args)
        {
            Marca marca = (Marca)args.Item;
            (sender as ListView).SelectedItem = null;
            Navigation.PushAsync(new DetalheMarca(this, marca));
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarMarca(this));
        }
    }
}