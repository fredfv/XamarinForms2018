using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App02_Tarefa.Modelos;

namespace App02_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        public byte Prioridade { get; set; }

        public Cadastro ()
		{
			InitializeComponent ();
		}

        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            //cada stack layout dentro do stack pai, é filho
            //pegamos ele e dizemos que ele é uma lista de stack layout
            //*
            //var Stacks = SLPrioridades.Children as List<StackLayout>;
            //*
            //ou fazendo assim
            var Stacks = SLPrioridades.Children;

            foreach (var Linha in Stacks)
            {
                //ou assim fazendo a conversao direta na atribuicao, e chamo ele dizendo que ele é uma label
                Label LblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                LblPrioridade.TextColor = Color.Gray;
            }

            //Recebemos o sender, agora acessar a label, pegando o children no indice 1 que e a label
            //Colocando o label antes, falamos que a estrutura e uma label
            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            //Fazendo assim as vc forca
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;


            //Usando o replace podemos substituir o conteudo da string
            //fazendo o check para cada plataforma
            if (Device.RuntimePlatform == Device.UWP)
            {
                String Prioridade = Source.File.ToString().Replace("Images/", "").Replace(".png", "");
                this.Prioridade = byte.Parse(Prioridade);
            }
            else
            {
                String Prioridade = Source.File.ToString().Replace("i", "").Replace(".png", "");
                this.Prioridade = byte.Parse(Prioridade);
            }
        }

        public void SalvarAction(object sender, EventArgs args)
        {
            bool ErroExiste = false;
            //VERIFICAMOS COM O .TRIM, SE O CAMPO FOI PREENCHIDO, O TRIM TIRA TODOS OS CAMPOS EM BRANCO
            if (!(TxtNome.Text.Trim().Length > 0))
            {
                ErroExiste = true;
                DisplayAlert("Error", "Nome não preenchido", "Okey");
            }

            if (!(this.Prioridade > 0))
            {
                ErroExiste = true;
                DisplayAlert("Error", "Prioridade não informada", "Okey");
            }

            if (!ErroExiste)
            {
                //instanciando a tarefa para salcar
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = TxtNome.Text.Trim();
                tarefa.Prioridade = this.Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                //TxtNome.Text = new GerenciadorTarefa().Listar().Count.ToString();

                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}