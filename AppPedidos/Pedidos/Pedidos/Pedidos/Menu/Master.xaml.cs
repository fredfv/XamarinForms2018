using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.SqlServer.Service;

namespace Pedidos.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public static int IdLogado { get; set; }
        //1 adm
        //2 supervisor
        //3 promotor
        public static int Permissao { get; set; }
        public static Color CorPermissao{get; set;}

        private Pessoa pessoa { get; set; }
        private Usuario usuario { get; set; }

        public Master (Pessoa pessoaLogada, Usuario usuarioLogado)
		{
			InitializeComponent ();
            TratarPermisao(pessoaLogada, usuarioLogado);

            Detail = new NavigationPage(new Home()) { BarBackgroundColor = CorPermissao };

            pessoa = pessoaLogada;
            usuario = usuarioLogado;
            IdLogado = pessoaLogada.idPessoa;
        }

        //TRATAR USUARIO
        private void TratarPermisao(Pessoa p, Usuario u)
        {
            switch (u.Funcao)
            {
                case "ADMIN":
                    isAdm.IsVisible = true;
                    isSuper.IsVisible = true;
                    isPromotor.IsVisible = true;
                    Permissao = 1;
                    CorPermissao = Color.Black;
                    break;
                case "SUPERVISOR":
                    isAdm.IsVisible = false;
                    isSuper.IsVisible = true;
                    isPromotor.IsVisible = true;
                    Permissao = 2;
                    CorPermissao = Color.DarkGreen;
                    break;
                case "PROMOTOR":
                    isAdm.IsVisible = false;
                    isSuper.IsVisible = false;
                    isPromotor.IsVisible = true;
                    Permissao = 3;
                    CorPermissao = Color.DarkBlue;
                    break;
                default:
                    App.Current.MainPage = new LoginPage();
                    break;
            }

            lblNomeUsuario.Text = p.nome;
            lblTipoUsuario.Text = u.Funcao;
            SlTitulo.BackgroundColor = CorPermissao;
        }

        //LISTA PESSOAS
        private void GoListaPessoas(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                Detail = new NavigationPage(new SqlServer.View.ListaPessoas()) { BarBackgroundColor = CorPermissao };
                IsPresented = false;
            }
            else
            {
                SemConexao();
            }
        }

        //LISTA MARCAS
        private void GoListaMarcas(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                Detail = new NavigationPage(new SqlServer.View.ListaMarcas(1)) { BarBackgroundColor = CorPermissao };
                IsPresented = false;
            }
            else
            {
                SemConexao();
            }
        }

        //LISTA PRODUTOS
        private void GoListaProdutos(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                Detail = new NavigationPage(new SqlServer.View.ListaMarcas(2)) { BarBackgroundColor = CorPermissao };
                IsPresented = false;
            }
            else
            {
                SemConexao();
            }
        }

        //LISTA PEDIDOS
        private void GoListaPedidos(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                Detail = new NavigationPage(new SqlServer.View.ListaPedidos()) { BarBackgroundColor = CorPermissao };
                IsPresented = false;
            }
            else
            {
                SemConexao();
            }
        }

        //NOVO PEDIDO
        private void GoNovoPedido(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                Detail = new NavigationPage(new SqlServer.View.ListaMarcas(3)) { BarBackgroundColor = CorPermissao };
                IsPresented = false;
            }
            else
            {
                SemConexao();
            }
        }

        //VER PERFIL
        private void GoPerfil(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                Detail = new NavigationPage(new SqlServer.View.DetalhePessoa(pessoa)) { BarBackgroundColor = CorPermissao };
                IsPresented = false;
            }
            else
            {
                SemConexao();
            }
        }

        //SAIR
        private void Sair(object sender, EventArgs args)
        {
            App.Current.MainPage = new LoginPage();
        }

        private void SemConexao()
        {
            DisplayAlert("Error", "Não há conexão com a Internet", "Ok");
        }
    }
}