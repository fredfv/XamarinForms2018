using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPromotor : MasterDetailPage
    {
		public MasterPromotor ()
		{
			InitializeComponent ();
		}

        private void AbrirMarcas(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.Pages.MarcaView());
            IsPresented = false;
        }

        private void AbrirPedidos(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.Pages.PedidoView());
            IsPresented = false;
        }
    }
}