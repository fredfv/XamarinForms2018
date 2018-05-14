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
	public partial class CadastrarMarca : ContentPage
	{
		public CadastrarMarca (Marca marca = null)
		{
			InitializeComponent ();
            BindingContext = marca;

            if (marca != null)
            {
                BtnCadastro.Text = "Salvar";
            }
            else
            {
                BtnCadastro.Text = "Cadastrar";
            }

            
        }

        private void Cadastrar(object sender, EventArgs args)
        {
            Marca novaMarca = new Marca();
            novaMarca.nome = Nome.Text;
            novaMarca.codigo = int.Parse(Codigo.Text);

            bool ok = ServiceWS.InsertMarca(novaMarca, Menu.Master.IdLogado);

            if (ok)
            {
                Mensagem.Text = "Cadastro efetuado com sucesso";
            }
            else
            {
                Mensagem.Text = "Ocorreu um erro no cadastro";
            }

        }

        private void FecharModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

    }
}