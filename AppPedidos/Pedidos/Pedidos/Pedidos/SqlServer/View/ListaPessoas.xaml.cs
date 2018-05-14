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
	public partial class ListaPessoas : ContentPage
	{

        private List<Pessoa> ListaInterna { get; set; }
        private List<Pessoa> ListaFiltrada { get; set; }

        public ListaPessoas()
        {
            InitializeComponent();
            //ListaInterna = Service.Service.GetPessoas();
            ListaInterna = Service.ServiceWS.GetPessoas();
            Lista.ItemsSource = ListaInterna;
        }

        private void GoDetalhe(object sender, SelectedItemChangedEventArgs args)
        {
            Pessoa pessoa = (Pessoa)args.SelectedItem;

            Navigation.PushAsync(new DetalhePessoa(pessoa));
        }

        private void Buscar(object sender, TextChangedEventArgs args)
        {
            ListaFiltrada = ListaInterna.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = ListaFiltrada;
        }
    }
}