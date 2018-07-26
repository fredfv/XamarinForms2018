using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.Menu;

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
            tipoAcao = acao;
            switch (tipoAcao)
            {
                case 1:
                    if (Master.Permissao != 1)
                    {
                        ToolbarItems.RemoveAt(0);
                    }
                    break;
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

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            podeBuscar = false;
            buscarEntry.Text = "";
            ErrorLista.IsVisible = false;
        }

        public async void AtualizarAsync()
        {
            podeBuscar = false;
            Carregando.IsVisible = true;
            try
            {
                ListaInterna = await Service.ServiceWS.GetMarcasAsync();
                podeBuscar = true;
                Lista.ItemsSource = ListaInterna;
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar Marcas", "Ok");
                podeBuscar = false;
                ErrorLista.IsVisible = true;
            }
            Carregando.IsVisible = false;

            if (ListaInterna != null)
            {
                podeBuscar = true;
                buscarEntry.Placeholder = "Pesquisar. . . Nome ou Código . . .";
                buscarEntry.IsEnabled = true;
            }
            else
            {
                buscarEntry.IsEnabled = false;
                buscarEntry.Placeholder = "Nenhum Produto encontrado";
            }
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
                    Navigation.PushAsync(new ListaProdutos(1, marca) { Title = "Produtos de: "+marca.nome});
                    break;
                case 3:
                    (sender as ListView).SelectedItem = null;
                    Navigation.PushAsync(new ListaProdutos(2, marca) { Title = "Produtos de: "+marca.nome});
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
            ToolbarItems.RemoveAt(0);
        }
    }
}