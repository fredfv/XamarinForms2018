using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Estilo.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
		public Master ()
		{
			InitializeComponent ();
            //Detail = new NavigationPage(new MainPage());
		}

        private void GoPagina1(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.ImplicitStyle());
            IsPresented = false;
        }
        private void GoPagina2(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.ExplicitStyle());
            IsPresented = false;
        }

        private void GoPagina3(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.GlobalStyle());
            IsPresented = false;
        }

    }
}

//ESTILOS
//O Estilo é uma forma de centralizar todas as questoes relaciondas a aparencia em um arquivo, pois ao centralizar
//facilita a manuseabilidade, ao manter em um arquivo vc referencia esse arquivo de outros assim mudar, muda só em um
//vamos aprender varias formas de usar

    //existem 3 formas de usar o stilo
    
    //1 layouts

    //2 paginas , vamos aprender esse

    //3 todo projeto