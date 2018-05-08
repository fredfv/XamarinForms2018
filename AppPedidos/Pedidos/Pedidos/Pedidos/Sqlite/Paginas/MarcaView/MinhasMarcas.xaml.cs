using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.Sqlite.Modelos;
using Pedidos.Sqlite.Banco;


namespace Pedidos.Sqlite.Paginas.MarcaView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinhasMarcas : ContentPage
    {

        List<Marca> Lista { get; set; }
        public MinhasMarcas()
        {
            InitializeComponent();
            Consultar();
        }

        private void Consultar()
        {
            DataBase database = new DataBase();

            Lista = database.MarcaConsultar();

            ListaMarcas.ItemsSource = Lista;
            lblCount.Text = Lista.Count.ToString();
        }


        public void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            Marca marca = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Marca;
            
            Navigation.PushAsync(new Editar(marca));
        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            Marca marca = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Marca;

            //Navigation.PushAsync(new Consultar());

            DataBase database = new DataBase();
            database.MarcaExcluir(marca);
            Consultar();
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaMarcas.ItemsSource = Lista.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
        }
    }
}