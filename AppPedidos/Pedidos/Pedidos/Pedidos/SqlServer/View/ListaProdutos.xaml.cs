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
	public partial class ListaProdutos : ContentPage
	{
        private List<Produto> ListaInterna { get; set; }
        private List<Produto> ListaFiltrada { get; set; }
        private bool podeBuscar { get; set; }
        private int tipoAcao { get; set; }
        private Marca marcaAtual { get; set; }

        //acao
        // 1 - lista simples de produtos
        // 2 - lista de produtos para exibir novo pedido
        public ListaProdutos(int acao, Marca marca)
        {
            InitializeComponent();
            marcaAtual = marca;

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
                ListaInterna = await Service.ServiceWS.GetProdutosAsync(marcaAtual.id);
                podeBuscar = true;
                Lista.ItemsSource = ListaInterna;
            }
            catch
            {
                await DisplayAlert("Error", "Erro ao carregar Produtos", "Ok");
                podeBuscar = false;
                ErrorLista.IsVisible = true;
            }
            Carregando.IsVisible = false;
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
            Produto produto = (Produto)args.Item;
            switch (tipoAcao)
            {
                case 2:
                    (sender as ListView).SelectedItem = null;
                    Navigation.PushModalAsync(new CadastrarPedido(produto));
                    break;
                default:
                    (sender as ListView).SelectedItem = null;
                    Navigation.PushAsync(new DetalheProduto(this, produto));
                    break;
            }
        }

        private void GoModalCadastrar(object sender, EventArgs args)
        {
            if (tipoAcao == 1)
            {
                Navigation.PushModalAsync(new CadastrarProduto(this, marcaAtual));
            }
        }

        private void OcultarAdicionar()
        {
            ToolbarItems.RemoveAt(0);
        }
    }
}
