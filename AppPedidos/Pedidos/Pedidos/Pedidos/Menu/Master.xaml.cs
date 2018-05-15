using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;

namespace Pedidos.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{

        //0 adm 1 promotor
        public static int IdLogado { get; set; }
        private Pessoa usuario { get; set; }

		public Master (Pessoa usuarioLogado)
		{
			InitializeComponent ();
            Detail = new NavigationPage(new Home()) { BarBackgroundColor=Color.Black };
            usuario = usuarioLogado;
            IdLogado = usuarioLogado.idPessoa;

            Nome.Text = usuarioLogado.nome;

            if (usuario.rg.ToString().Contains("1"))
            {
                Tipo.Text = "- Promotor";
                btnMarcas.IsVisible = false;
                btnPessoas.IsVisible = false;
            }
            else
            {
                Tipo.Text = "- Adm";
            }
        }

        private void GoListaPessoas(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.View.ListaPessoas()) { BarBackgroundColor = Color.Black };
            IsPresented = false;
        }

        private void GoListaMarcas(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.View.ListaMarcas()) { BarBackgroundColor = Color.Black };
            IsPresented = false;
        }

        private void GoListaProdutos(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.View.ListaProdutos()) { BarBackgroundColor = Color.Black };
            IsPresented = false;
        }

        private void GoListaPedidos(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.View.ListaPedidos()) { BarBackgroundColor = Color.Black };
            IsPresented = false;
        }

        private void GoPerfil(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.View.DetalhePessoa(usuario)) { BarBackgroundColor = Color.Black };
            IsPresented = false;
        }

        private void Sair(object sender, EventArgs args)
        {
            App.Current.MainPage = new LoginPage();

        }
    }
}