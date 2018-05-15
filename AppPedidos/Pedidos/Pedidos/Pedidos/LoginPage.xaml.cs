using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.SqlServer.Service;

namespace Pedidos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{

        private List<Pessoa> usuarioLogado { get; set; }

        public LoginPage()
		{
			InitializeComponent();
            Login.Text = "5";
            Senha.Text = "5";

        }

        private void VerSenha(object sender, EventArgs args)
        {
            Senha.IsPassword = !Senha.IsPassword;
        }

        private void Logar(object sender, EventArgs args)
        {
            Carregando.IsRunning = true;

            Login.IsEnabled = false;
            Senha.IsEnabled = false;

            int login = int.Parse(Login.Text);

            //usuarioLogado = Service.GetPessoaPorId(login);
            usuarioLogado = ServiceWS.GetPessoaPorId(login);


            if (usuarioLogado[0].cep == Senha.Text)
            {
                App.Current.MainPage = new Pedidos.Menu.Master(usuarioLogado[0]);
            }
            else
            {
                Carregando.IsRunning = false;

                DisplayAlert("Erro ao logar", "Usuario ou senha errados!", "Okey");

                Login.Text = "";
                Senha.Text = "";

                Login.IsEnabled = true;
                Senha.IsEnabled = true;
            }
        }
    }
}