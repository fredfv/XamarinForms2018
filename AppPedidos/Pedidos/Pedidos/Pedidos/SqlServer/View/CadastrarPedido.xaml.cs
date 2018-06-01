﻿using System;
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
	public partial class CadastrarPedido : ContentPage
	{
        private int IdProduto { get; set; }

		public CadastrarPedido (Produto produto)
		{
			InitializeComponent ();
            BindingContext = produto;

            List<Marca> marca = ServiceWS.GetMarcaPorId(produto.idMarca);
            Marca.Text = marca[0].nome;

            IdProduto = produto.id;
		}

        private void Cadastrar(object sender, EventArgs args)
        {
            if (ValidaPedido() == 1)
            {
                Perda.IsEnabled = false;
                Troca.IsEnabled = false;
                Quantidade.IsEnabled = false;
                Obs.IsEnabled = false;
                BtnCadastro.IsEnabled = false;

                Pedido novoPedido = new Pedido()
                {
                    idUsuarioInclusao = Pedidos.Menu.Master.IdLogado,
                    idProduto = IdProduto,
                    perda = int.Parse(Perda.Text),
                    troca = int.Parse(Troca.Text),
                    quantidade = int.Parse(Quantidade.Text),
                    obs = Obs.Text
                };

                bool ok = ServiceWS.InsertPedido(novoPedido);
                if (ok)
                {
                    Mensagem.Text = "Cadastro efetuado com sucesso";
                }
                else
                {
                    Mensagem.Text = "Ocorreu um erro no cadastro";
                }
            }
            else if (ValidaPedido() == 2)
            {
                DisplayAlert("Error", "Favor verificar o preenchimento dos campos", "Ok");
            }
            else if (ValidaPedido() == 3)
            {
                DisplayAlert("Error", "Dados inconsistentes", "Ok");
            }
        }

        private int ValidaPedido()
        {
            /*
             1 = ok
             2 = campo vazio
             3 = campo com valores errados
             */
            bool sPerda = string.IsNullOrEmpty(Perda.Text);
            bool sTroca = string.IsNullOrEmpty(Troca.Text);
            bool sQuantidade = string.IsNullOrEmpty(Quantidade.Text);

            if (!sPerda && !sTroca && !sQuantidade)
            {
                bool bPerda = Perda.Text.All(char.IsDigit);
                bool bTroca = Troca.Text.All(char.IsDigit);
                bool bQuantidade = Quantidade.Text.All(char.IsDigit);

                if (bPerda && bTroca && bQuantidade)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }
        }

        private void FecharModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}