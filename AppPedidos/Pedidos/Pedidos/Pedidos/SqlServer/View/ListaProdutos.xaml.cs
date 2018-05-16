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
    public partial class ListaProdutos : ContentPage
    {
        private List<Marca> ListaInterna { get; set; }
        private List<Marca> ListaFiltrada { get; set; }
        private bool isNovoPedido {get; set;}

        public ListaProdutos(string isNovo = null)
        {
            InitializeComponent();
            ListaInterna = Service.ServiceWS.GetMarcas();
            Lista.ItemsSource = ListaInterna;

            if (isNovo == "novo")
            {
                isNovoPedido = true;
            }
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Marca marca = (Marca)args.SelectedItem;
            if (isNovoPedido)
            {
                Navigation.PushAsync(new ListaProdutosParaNovoPedido(marca));
            }
            else
            {
                Navigation.PushAsync(new ListaProdutosPorMarca(marca));
            }
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }
    }
}