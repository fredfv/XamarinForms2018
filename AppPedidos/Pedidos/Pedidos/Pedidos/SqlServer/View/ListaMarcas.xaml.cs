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

        public ListaMarcas()
        {
            InitializeComponent();
            Atualizar();
        }

        private void Atualizar()
        {
            ListaInterna = Service.ServiceWS.GetMarcas();
            Lista.ItemsSource = ListaInterna;
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Marca marca = (Marca)args.SelectedItem;
            Navigation.PushAsync(new DetalheMarca(marca));
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarMarca());
        }

        private void AtualizarAction(object sender, EventArgs args)
        {
            Atualizar();
        }
    }
}