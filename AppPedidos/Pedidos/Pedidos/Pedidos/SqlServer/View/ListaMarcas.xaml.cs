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

        public void Atualizar()
        {
            ListaInterna = Service.ServiceWS.GetMarcas();
            Lista.ItemsSource = ListaInterna;
            barraBusca.Text = "";
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }

        private void GoDetalhe(object sender, ItemTappedEventArgs args)
        {
            Marca marca = (Marca)args.Item;
            Navigation.PushAsync(new DetalheMarca(this, marca));
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarMarca(this));
        }

        private void AtualizarAction(object sender, EventArgs args)
        {
            Atualizar();
        }
    }
}