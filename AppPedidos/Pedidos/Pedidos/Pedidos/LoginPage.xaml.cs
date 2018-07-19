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
        private int login { get; set; }
        private bool ver { get; set; }

        public LoginPage()
        {
            ver = false;
			InitializeComponent();
            Login.Text = "5";
            Senha.Text = "5";
            btnLogar.Text = "LOGAR";
        }

        private void VerSenha(object sender, EventArgs args)
        {
            ver = !ver;
            Senha.IsPassword = !Senha.IsPassword;

            VerPass.Source = ver ? "verOff" : "verOn";
        }

        private async void Logar(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                btnLogar.Text = "LOGANDO . . .";
                area.IsEnabled = false;
                Carregando.IsRunning = true;
                VerPass.IsEnabled = false;

                try
                {
                    login = int.Parse(Login.Text);
                }
                catch
                {
                    msg();
                    return;
                }

                try
                {
                    Carregando.IsRunning = true;
                    usuarioLogado = await ServiceWS.Login(login);

                    if (usuarioLogado[0].cep == Senha.Text)
                    {
                        App.Current.MainPage = new Pedidos.Menu.Master(usuarioLogado[0]);
                    }
                    else
                    {
                        msg();
                    }
                }
                catch (Exception)
                {
                    msg();
                }
            }
            else
            {
                await DisplayAlert("Error", "Sem conexão com a Internet", "Ok!");
            }
        }

        private void msg()
        {
            Carregando.IsRunning = false;

            DisplayAlert("Erro ao logar", "Usuario ou senha errados!", "Okey");

            Login.Text = "";
            Senha.Text = "";

            VerPass.IsEnabled = true;
            btnLogar.Text = "Logar";
            area.IsEnabled = true;
            Carregando.IsRunning = false;
        }
    }
}