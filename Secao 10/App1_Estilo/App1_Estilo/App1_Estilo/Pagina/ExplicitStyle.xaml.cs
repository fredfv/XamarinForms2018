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
	public partial class ExplicitStyle : ContentPage
	{
		public ExplicitStyle ()
		{
			InitializeComponent ();
		}
	}
}

// DIFERENCA ENTRE INPLICIT E EXPLICIT