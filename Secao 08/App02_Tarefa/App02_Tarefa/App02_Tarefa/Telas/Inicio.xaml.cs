using App02_Tarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + "," + DateTime.Now.ToString("dd/MM");

            CarregarTarefas();
        }

        public void ActionGoCadastro(object sender, EventArgs args)
        {
            //PARA ISSO CERTIFICAR SE O APP ESTA USANDO O NAVIGTION
            Navigation.PushAsync(new Cadastro());
        }

        private void CarregarTarefas()
        {
            //Assim temos um stack layout vazio
            SLTarefas.Children.Clear();
            //Agora preencher com as linhas que criamos com base no xaml anterior
            //pegar todas as tarefas
            List<Tarefa> Lista = new GerenciadorTarefa().Listar();
            //usar o for each pegando uma tarefa
            //e dizer que essa variaveu vai receber uma tarefa em cada iteracao
            //criando um indice para cada variavel

            int i = 0;
            foreach (Tarefa tarefa in Lista)
            {
                LinhaStackLayout(tarefa, i);
                i++;
            }

        }

        //cria a linha
        public void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Delete.Source = ImageSource.FromFile("Images/Delete.png");
            }
            //Como é uma imagem. precisa adicionar o GestureRecognize
            TapGestureRecognizer DeleteTap = new TapGestureRecognizer();
            //usando o delegate, fica melhor de implementar o metedo
            //E no fim pegamos o deleteTap e adicionamos a imagem

            DeleteTap.Tapped += delegate
            {
                //Aqui sao as acaoes que ele vai trabalhar
                new GerenciadorTarefa().Deletar(index);
                CarregarTarefas();
            };
            Delete.GestureRecognizers.Add(DeleteTap);

            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("i"+tarefa.Prioridade+".png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Prioridade.Source = ImageSource.FromFile("Images/"+ tarefa.Prioridade +".png");
            }

            View StackCentral = null;

            if (tarefa.DataFinizalicao == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                StackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
                //fazer um casting para acessar a propriedade
                ((StackLayout)(StackCentral)).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });
                ((StackLayout)(StackCentral)).Children.Add(new Label() { Text = "Finalizado em "+tarefa.DataFinizalicao.Value.ToString("dd/MM/yyyy/ - hh:mm")+"h", TextColor = Color.Gray, FontSize = 10});
            }

            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("Images/CheckOff.png"); 
            }
            if(tarefa.DataFinizalicao != null)
            {
                Check.Source = ImageSource.FromFile("CheckOn.png");
                if (Device.RuntimePlatform == Device.UWP)
                {
                    Check.Source = ImageSource.FromFile("Images/CheckOn.png");
                }

            }

            TapGestureRecognizer CheckTap = new TapGestureRecognizer();
            CheckTap.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(index, tarefa);
                CarregarTarefas();
            };
            Check.GestureRecognizers.Add(CheckTap);


            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15};

            Linha.Children.Add(Check);
            Linha.Children.Add(StackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
        }

    }
}