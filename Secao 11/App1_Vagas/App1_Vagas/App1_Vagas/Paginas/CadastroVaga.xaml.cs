using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroVaga : ContentPage
	{
		public CadastroVaga ()
		{
			InitializeComponent ();
		}

        public void SalvarAction(object sender, EventArgs args)
        {
            //TODO - Validar dados do cadastro
            Vaga vaga = new Vaga();

            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            //FAZER POR MEIO DE UM OPERADOR TERNARIO UMA COMPARACAO 
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT" ;
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            DataBase database = new DataBase();
            database.Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultaVagas());

        }

	}
}