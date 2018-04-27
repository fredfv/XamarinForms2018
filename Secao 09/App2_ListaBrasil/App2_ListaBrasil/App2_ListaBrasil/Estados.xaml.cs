using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2_ListaBrasil.Modelo;

namespace App2_ListaBrasil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Estados : ContentPage
	{
        private List<Estado> ListaInternaEstado;
        private List<Estado> ListaDaBuscaEstado;

		public Estados ()
		{
			InitializeComponent ();
            ListaInternaEstado = Servico.Servico.GetEstados();
            ListaEstados.ItemsSource = ListaInternaEstado;

        }

        private void SelecaoEstadoAction(object sender, SelectedItemChangedEventArgs args)
        {
            //representa o item que acabou de ser clicado
            //sabemos que ele é do tipo estado entao faremos um casting para estado
            Estado estado = (Estado)args.SelectedItem;
            Navigation.PushAsync(new Municipios(estado) { Title="BRASIL Municipios!", BackgroundColor = Color.Black});
        }

        private void BuscaRapida(object sender, TextChangedEventArgs args)
        {
            ListaDaBuscaEstado = ListaInternaEstado.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower()) || a.sigla.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            ListaEstados.ItemsSource = ListaDaBuscaEstado;
        }
    }
}