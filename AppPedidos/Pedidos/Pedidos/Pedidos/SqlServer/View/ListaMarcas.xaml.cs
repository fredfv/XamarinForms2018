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
        private int tipoAcao { get; set; }

        //acao
        // 1 - lista simples de marcas
        // 2 - lista de marcas para exibir produto
        // 3 - lista de marcas para exibir pedido
        public ListaMarcas(int acao)
        {
            InitializeComponent();
            OnAppearing();

            tipoAcao = acao;
            switch (tipoAcao)
            {
                case 2:
                    OcultarAdicionar();
                    break;
                case 3:
                    OcultarAdicionar();
                    break;
            }
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
                ListaInterna = await Service.ServiceWS.GetMarcasAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar Marcas", "Ok");
            }
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
            switch (tipoAcao)
            {
                case 2:
                    (sender as ListView).SelectedItem = null;
                    Navigation.PushAsync(new ListaProdutosPorMarca(marca));
                    break;
                case 3:
                    (sender as ListView).SelectedItem = null;
                    Navigation.PushAsync(new ListaProdutosParaNovoPedido(marca));
                    break;
                default:
                    (sender as ListView).SelectedItem = null;
                    Navigation.PushAsync(new DetalheMarca(this, marca));
                    break;
            }
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            if (tipoAcao == 1)
            {
                Navigation.PushModalAsync(new CadastrarMarca(this));
            }
        }

        private void OcultarAdicionar()
        {
            btnAdicionar.Icon = "plus.png";
            btnAdicionar.Text = "";
        }
    }
}