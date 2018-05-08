using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.Sqlite.Banco;
using Pedidos.Sqlite.Modelos;

namespace Pedidos.Sqlite.Paginas.MarcaView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        private Marca marca { get; set; }

        public Editar(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;

            Nome.Text = marca.Nome;
            Codigo.Text = marca.Codigo.ToString();
            Ativo.IsToggled = (marca.Ativo == 0) ? false : true;

        //    if (marca.Ativo == 1)
        //    {
        //        Ativo.IsToggled = true;
        //    }
        //    else
        //    {
        //        Ativo.IsToggled = false;
        //    }
        }

        public void AtualizarAction(object sender, EventArgs args)
        {
            //obter da tela e atualizar no banco
            marca.Nome = Nome.Text;
            marca.Codigo = int.Parse(Codigo.Text);
            marca.Ativo = (Ativo.IsToggled) ? 1 : 0;
            marca.DataInclusao = DateTime.Now;
            //o id usuario vai vir de quem esta logado
            marca.IdUsuarioInclusao = 2;

            DataBase database = new DataBase();
            database.MarcaAtualizar(marca);

            App.Current.MainPage = new NavigationPage(new MinhasMarcas());


        }

    }
}