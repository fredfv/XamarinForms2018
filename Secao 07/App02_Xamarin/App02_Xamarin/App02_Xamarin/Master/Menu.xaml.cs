using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_Xamarin.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        public void GoPaginaPerfil1(object sender, EventArgs args)
        {
           Detail = new NavigationPage(new Pages.Perfil1());
            IsPresented = false;
           //Navigation.PushAsync(new Pages.Perfil1());
        }

        public void GoPaginaXamarin(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pages.Xamarin());
            //Navigation.PushAsync(new Pages.Xamarin());
            IsPresented = false;

        }

    }
}