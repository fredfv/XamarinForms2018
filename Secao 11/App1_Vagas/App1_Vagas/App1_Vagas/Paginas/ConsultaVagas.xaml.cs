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
	public partial class ConsultaVagas : ContentPage
	{
		public ConsultaVagas ()
		{
			InitializeComponent ();


            DataBase database = new DataBase();
            var Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;



            lblCount.Text = Lista.Count.ToString();
		}

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroVaga());
        }

        public void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());

        }

        public void MaisDetalheAction(object sender, EventArgs args)
        {
            //USANDO O CommandParameter PASSANDO PARA O METODO CONSTRUTOR DO OUTRO
            //PASSANDO A VAGA 

            Label LblDetalhe = (Label)sender;

            Vaga vaga = ((TapGestureRecognizer)LblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;

            Navigation.PushAsync(new DetalheVaga(vaga));
        }

    }
}