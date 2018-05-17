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
        bool isCadastro { get; set; }
        Marca marcaNaPagina { get; set; }
        ListaMarcas listaParaAtualizar { get; set; }
        DetalheMarca detalheParaAtualizar { get; set; }
        
        //------------------------
        //CADASTRAR
        //------------------------
        public CadastrarMarca (ListaMarcas lista)
		{
			InitializeComponent ();
            listaParaAtualizar = lista;

            Cabecalho.Text = "Cadastrar";
            BtnEnviar.Text = "Enviar";

            isCadastro = true;
        }
        
        //------------------------
        //EDITAR
        //------------------------
        public CadastrarMarca(ListaMarcas lista, DetalheMarca detalhe)
        {
            InitializeComponent();
            BindingContext = detalhe.marcaAtual;

            marcaNaPagina = detalhe.marcaAtual;
            listaParaAtualizar = lista;
            detalheParaAtualizar = detalhe;

            Cabecalho.Text = "Editar";
            BtnEnviar.Text = "Salvar";

            isCadastro = false;
        }

        private void EnviarDados(object sender, EventArgs args)
        {
            Marca novaMarca = new Marca();
            novaMarca.nome = Nome.Text;
            novaMarca.codigo = int.Parse(Codigo.Text);

            if (!isCadastro)
            {
                novaMarca.id = marcaNaPagina.id;
                teste.Text = marcaNaPagina.id.ToString();
            }

            bool ok = ServiceWS.InsertMarca(novaMarca, Menu.Master.IdLogado);

            if (ok)
            {
                if (isCadastro)
                {
                    Mensagem.Text = "Cadastro efetuado com sucesso";
                    Nome.IsEnabled = false;
                    Codigo.IsEnabled = false;
                    BtnEnviar.IsEnabled = false;
                }
                else
                {
                    Mensagem.Text = "Dados alterados com sucesso";
                }
            }
            else
            {
                if (isCadastro)
                {
                    Mensagem.Text = "Ocorreu um erro no cadastro";
                }
                else
                {
                    Mensagem.Text = "Ocorreu um erro durante a alteração dos dados";
                }
            }
        }

        private void FecharModal(object sender, EventArgs args)
        {
            if (isCadastro)
            {
                listaParaAtualizar.Atualizar();
            }
            else
            {
                listaParaAtualizar.Atualizar();
                detalheParaAtualizar.Atualizar();
            }

            Navigation.PopModalAsync();
        }

    }
}