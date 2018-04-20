using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        public void MudarPagina1(object sender, EventArgs args)
        {
            //QUANDO VOCE PRECISA DE CHAMAR UMA PAGINA QUE USA NAVIGATION VC PRECISA INSTACIAR O NAVIGATUION
            Detail = new NavigationPage(new Navigation.Pagina1());
            //Esconde o menu
            IsPresented = false;
        }

        public void MudarPagina2(object sender, EventArgs args)
        {
            Detail = new Navigation.Pagina2();
            IsPresented = false;
        }

        public void MudarPagina3(object sender, EventArgs args)
        {
            Detail = new Conteudo();
            IsPresented = false;
        }

    }
}