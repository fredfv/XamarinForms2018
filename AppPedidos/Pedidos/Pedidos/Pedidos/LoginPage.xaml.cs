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
        private Usuario usuarioParaLogar { get; set; }
        private int login { get; set; }
        private bool ver { get; set; }

        public LoginPage()
        {
            ver = false;
			InitializeComponent();
            Login.Text = "adm";
            Senha.Text = "123456";
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
                    Carregando.IsRunning = true;

                    usuarioParaLogar = await ServiceWS.Logar(Login.Text, Senha.Text);

                    usuarioLogado = await ServiceWS.GetPessoaPorIdAsync(usuarioParaLogar.IdPessoa);

                    if (usuarioParaLogar.Login == Login.Text)
                    {
                        App.Current.MainPage = new Pedidos.Menu.Master(usuarioLogado[0], usuarioParaLogar);
                    }
                    else
                    {
                        msg();
                    }
                }
                catch
                {
                    msgInternet();
                }
            }
            else
            {
                await DisplayAlert("Error", "Sem conexão com a Internet", "Ok");
            }
        }

        private void msg()
        {
            Carregando.IsRunning = false;

            DisplayAlert("Erro ao logar", "Usuario ou senha errados!", "Ok");

            Login.Text = "";
            Senha.Text = "";

            VerPass.IsEnabled = true;
            btnLogar.Text = "Logar";
            area.IsEnabled = true;
            Carregando.IsRunning = false;
        }

        private void msgInternet()
        {
            Carregando.IsRunning = false;

            DisplayAlert("Error", "Sem conexão com a Internet", "Ok");

            VerPass.IsEnabled = true;
            btnLogar.Text = "Logar";
            area.IsEnabled = true;
            Carregando.IsRunning = false;
        }
    }
}