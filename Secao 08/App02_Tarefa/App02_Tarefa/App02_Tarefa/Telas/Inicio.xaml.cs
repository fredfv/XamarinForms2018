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
		public Inicio ()
		{
			InitializeComponent ();
		}

        public void ActionGoCadastro(object sender, EventArgs args)
        {
            //PARA ISSO CERTIFICAR SE O APP ESTA USANDO O NAVIGTION
            Navigation.PushAsync(new Cadastro());
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + "," + DateTime.Now.ToString("dd/MM");
        }

        public void LinhaStackLayout(Tarefa tarefa)
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Delete.Source = ImageSource.FromFile("Images/Delete.png");
            }

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
                ((StackLayout)(StackCentral)).Children.Add(new Label() { Text = "Finalizado em "+tarefa.DataFinizalicao.ToString("dd/MM/yyyy/ - hh:mm")+"h", TextColor = Color.Gray, FontSize = 10});
            }

            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("Images/CheckOff.png"); 
            }

            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15};

            Linha.Children.Add(Check);
            Linha.Children.Add(StackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
        }

    }
}