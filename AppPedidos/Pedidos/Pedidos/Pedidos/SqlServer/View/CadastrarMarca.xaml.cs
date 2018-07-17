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
        
        //CADASTRAR
        public CadastrarMarca (ListaMarcas lista)
		{
			InitializeComponent ();
            listaParaAtualizar = lista;

            Cabecalho.Text = "Cadastrar";
            BtnEnviar.Text = "Enviar";

            isCadastro = true;
        }

        //EDITAR
        public CadastrarMarca(DetalheMarca detalhe)
        {
            InitializeComponent();
            BindingContext = detalhe.marcaAtual;

            marcaNaPagina = detalhe.marcaAtual;
            detalheParaAtualizar = detalhe;

            Cabecalho.Text = "Editar";
            BtnEnviar.Text = "Salvar";

            isCadastro = false;
        }

        private void EnviarDados(object sender, EventArgs args)
        {
            if (VerificarConexao.TemInternet())
            {
                if (ValidaMarca() == 1)
                {
                    Nome.IsEnabled = false;
                    Codigo.IsEnabled = false;
                    BtnEnviar.IsEnabled = false;

                    Marca novaMarca = new Marca
                    {
                        nome = Nome.Text,
                        codigo = int.Parse(Codigo.Text)
                    };

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
                            listaParaAtualizar.AtualizarAsync();
                        }
                        else
                        {
                            Mensagem.Text = "Dados alterados com sucesso";
                            detalheParaAtualizar.Atualizar();
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
                else if (ValidaMarca() == 2)
                {
                    DisplayAlert("Error", "Favor verificar o preenchimento dos campos", "Ok");
                }
                else if (ValidaMarca() == 3)
                {
                    DisplayAlert("Error", "Dados inconsistentes", "Ok");
                }
            }
            else
            {
                SemConexao();   
            }
        }

        private int ValidaMarca()
        {
            /*
             1 = ok
             2 = campo vazio
             3 = campo com valores errados
             */
            bool sNome = string.IsNullOrEmpty(Nome.Text);
            bool sCodigo = string.IsNullOrEmpty(Codigo.Text);

            if (!sNome && !sCodigo)
            {
                bool bCodigo = Codigo.Text.All(char.IsDigit);

                if (bCodigo)
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

        private void SemConexao()
        {
            DisplayAlert("Error", "Não há conexão com a Internet", "Ok");
        }
    }
}