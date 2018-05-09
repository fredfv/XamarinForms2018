﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Models;

namespace Pedidos.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
        public static int IdLogado { get; set; }
        private Pessoa usuario { get; set; }

		public Master (Pessoa usuarioLogado)
		{
			InitializeComponent ();
            Detail = new NavigationPage(new Home());
            usuario = usuarioLogado;
            IdLogado = usuarioLogado.idPessoa;

            Nome.Text = usuarioLogado.nome;
            Tipo.Text = IdLogado.ToString();
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

        private void AbrirPerfil(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SqlServer.Pages.PessoaPerfil(usuario));
            IsPresented = false;
        }

    }
}