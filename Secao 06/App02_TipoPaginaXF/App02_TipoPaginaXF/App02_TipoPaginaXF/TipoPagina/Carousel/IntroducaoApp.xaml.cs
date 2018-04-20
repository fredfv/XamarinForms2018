using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


//AQUI VAMOS TRANSFORMAR ELA EM UM CAROUSEL


namespace App02_TipoPaginaXF.TipoPagina.Carousel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntroducaoApp : CarouselPage
	{
		public IntroducaoApp ()
		{
			InitializeComponent ();
		}
	}
}