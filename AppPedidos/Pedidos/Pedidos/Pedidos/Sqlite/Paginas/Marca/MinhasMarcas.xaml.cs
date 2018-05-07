using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Sqlite.Paginas.Marca
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MinhasMarcas : ContentPage
	{
		public MinhasMarcas ()
		{
			InitializeComponent ();
		}

        public void EditarAction(object sender, EventArgs args)
        {

        }

        public void ExcluirAction(object sender, EventArgs args)
        {

        }
	}
}