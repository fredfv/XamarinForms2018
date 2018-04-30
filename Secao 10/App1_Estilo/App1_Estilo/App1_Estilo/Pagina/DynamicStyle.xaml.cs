using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Estilo.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DynamicStyle : ContentPage
	{
		public DynamicStyle ()
		{
			InitializeComponent ();
		}

        private void MudarCor(object sender, EventArgs args)
        {
            //pegando pelo   <ContentPage.Resources> usando o This.Resources
            //achando ele pelo indice "LblColor
            //dessa forma se altera um stylo via c#
            this.Resources["LblColor"] = Color.Orange;
            this.Resources["Lbl"] = this.Resources["NewLbl"];
        }

    }
}