using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.Sqlite.Modelos;

namespace Pedidos.Sqlite.Paginas.Marca
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhes : ContentPage
	{
		public Detalhes (Modelos.Marca marca)
		{
			InitializeComponent ();

            //DisplayAlert("MSG", marca.Nome, "OK");

            BindingContext = marca;

            if (marca.Ativo == 1)
            {
                Ativo.Text = "Ativo";
            }
            else
            {
                Ativo.Text = "Desativado";
            }

		}
	}
}