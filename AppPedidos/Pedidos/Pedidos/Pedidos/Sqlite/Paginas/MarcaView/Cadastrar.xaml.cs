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
    public partial class Cadastrar : ContentPage
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        public void SalvarAction(object sender, EventArgs args)
        {
            //VALIDAR DADOS
            Marca marca = new Marca();

            marca.Nome = Nome.Text;
            marca.Codigo = int.Parse(Codigo.Text);
            marca.Ativo = (Ativo.IsToggled) ? 1 : 0;
            marca.DataInclusao = DateTime.Now;
            //o id usuario vai vir de quem esta logado
            marca.IdUsuarioInclusao = 2;

            DataBase database = new DataBase();
            database.MarcaCadastrar(marca);

            App.Current.MainPage = new NavigationPage(new Consultar());

        }




    }
}