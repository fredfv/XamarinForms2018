using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Carousel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoPagina3 : ContentPage
	{
		public TipoPagina3 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina(object sender, EventArgs args)
        {
            //assim forcamos uma mudanca de pagina
            //criando um fluxo de navegacao usando o navigation
            //com isso ele pode ir chamando as pages e voltando

            //Acessando as propriedades nativas { } usando abrefecha chaves vc pode visualisar as propriedades
            // App.Current.MainPage = new NavigationPage(new Navigation.Pagina1()) { BarBackgroundColor = Color.LightBlue };
            App.Current.MainPage = new Tabbed.Abas();

        }
    }
}