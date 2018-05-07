using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.Sqlite.Modelos;
using Pedidos.Sqlite.Banco;

namespace Pedidos.Sqlite.Paginas.Marca
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultar : ContentPage
	{
        List<Modelos.Marca> Lista { get; set; }

        public Consultar ()
		{
			InitializeComponent ();

            DataBase database = new DataBase();

            Lista = database.MarcaConsultar();

            ListaMarcas.ItemsSource = Lista;
            lblCount.Text = Lista.Count.ToString();

		}

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastrar());
             

        }

        public void GoMinhasMarcas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasMarcas());

        }

        public void AbrirAction(object sender, EventArgs args)
        {

            Label lblDetalhe = (Label)sender;
            Modelos.Marca marca = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Modelos.Marca;


            Navigation.PushAsync(new Detalhes(marca));

        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaMarcas.ItemsSource =  Lista.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
        }

    }
}