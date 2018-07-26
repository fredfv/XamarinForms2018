using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Model;
using Pedidos.SqlServer.Service;
using Pedidos.Menu;

namespace Pedidos.SqlServer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastrarMarca : ContentPage
	{
        bool isCadastro { get; set; }
        Marca marcaNaPagina { get; set; }
        ListaMarcas listaParaAtualizar { get; set; }
        DetalheMarca detalheParaAtualizar { get; set; }
        string nomeMarca { get; set; }

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
            nomeMarca = detalhe.marcaAtual.nome;
            marcaNaPagina = detalhe.marcaAtual;
            detalheParaAtualizar = detalhe;
            Cabecalho.Text = "Editar";
            BtnEnviar.Text = "Salvar";
            isCadastro = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SlTitulo.BackgroundColor = Master.CorPermissao;
        }
              
        private async void EnviarDados(object sender, EventArgs args)
        {
            bool podeAtualizar;
            Carregando.IsVisible = true;

            if (!isCadastro)
            {
                var resultado = await DisplayAlert("Atualizar?", "Deseja atualizar os dados de:\n" + nomeMarca + " ?", "NÂO", "SIM");
                podeAtualizar = resultado ? false : true;
            }
            else
            {
                var resultado = await DisplayAlert("Cadastrar?", "Deseja cadastrar :\n" + Nome.Text + " ?", "NÂO", "SIM");
                podeAtualizar = resultado ? false : true;
            }

            if (podeAtualizar)
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
                            try
                            {
                                bool ok = await ServiceWS.UpdateMarcaAsync(novaMarca, Menu.Master.IdLogado);
                                if (ok)
                                {
                                    detalheParaAtualizar.AtualizarAsync();
                                    await Navigation.PopModalAsync();
                                }
                                else
                                {
                                    await DisplayAlert("Error", "Ocorreu um erro durante a alteração dos dados", "Ok");
                                    await Navigation.PopModalAsync();
                                }
                            }
                            catch
                            {
                                await DisplayAlert("Error", "Ocorreu um erro durante a alteração dos dados", "Ok");
                                await Navigation.PopModalAsync();
                            }
                        }
                        else
                        {
                            try
                            {
                                bool ok = await ServiceWS.InsertMarcaAsync(novaMarca, Menu.Master.IdLogado);
                                if (ok)
                                {
                                    listaParaAtualizar.AtualizarAsync();
                                    await Navigation.PopModalAsync();
                                }
                                else
                                {
                                    await DisplayAlert("Error", "Ocorreu um erro no cadastro", "Ok");
                                    await Navigation.PopModalAsync();
                                }
                            }
                            catch
                            {
                                await DisplayAlert("Error", "Ocorreu um erro no cadastro", "Ok");
                                await Navigation.PopModalAsync();
                            }
                        }
                    }
                    else if (ValidaMarca() == 2)
                    {
                        await DisplayAlert("Error", "Favor verificar o preenchimento dos campos", "Ok");
                    }
                    else if (ValidaMarca() == 3)
                    {
                        await DisplayAlert("Error", "Dados inconsistentes", "Ok");
                    }
                }
                else
                {
                    SemConexao();
                }
            }
            Carregando.IsVisible = false;
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