using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.SqlServer.Service;

namespace Pedidos.SqlServer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheMarca : ContentPage
	{
        Marca marcaAtual { get; set; }

		public DetalheMarca (Marca marca)
		{
			InitializeComponent ();
            BindingContext = marca;

            marcaAtual = marca;
        }

        private void GoDeletar(object sender, EventArgs args)
        {
            ServiceWS.DeleteMarca(marcaAtual);
            Navigation.PushAsync(new ListaMarcas());
        }

        private void GoEditar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new CadastrarMarca(marcaAtual));
        }

        private void GoAtualizar(object sender, EventArgs args)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            List<Marca> marcaAtualizada = ServiceWS.GetMarcaPorId(marcaAtual.id);
            BindingContext = marcaAtualizada[0];
        }


	}
}