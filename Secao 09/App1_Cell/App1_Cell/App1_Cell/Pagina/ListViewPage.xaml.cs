using App1_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();


            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Nome = "Fred", Cargo = "Estagiario" });
            Lista.Add(new Funcionario() { Nome = "Elias", Cargo = "Desenvolvedor" });
            Lista.Add(new Funcionario() { Nome = "Tito", Cargo = "Gato De Rua " });
            Lista.Add(new Funcionario() { Nome = "Mica", Cargo = "Gata do telhado " });
            Lista.Add(new Funcionario() { Nome = "Lala", Cargo = "Caseira " });

            //FAZENDO ISSO O PROPRIO LISTA VIEW VAI ITERAR, VAI FAZER O FOR EACH, E CRIAR UM TEXT CEL PARA DA REGISTRO
            ListaDeFuncionarios.ItemsSource = Lista;


        }

        private void ItemSelecionadoAction(object sender, SelectedItemChangedEventArgs args)
        {
            //FAZENDO O CASTING PARA PEGAR O FUNCIONARIO POIS O ARGS.SELECTED ITEM É DO TIPO FUNCIONARIO
            Funcionario func = (Funcionario)args.SelectedItem;

            Navigation.PushAsync(new Detalhe.DetailPage(func));
        }


        private void FeriasAction(object sender, EventArgs args)
        {
            //para pegar o funcionario, pegamos o sender que é o item que foi clicado
            //o menu item, que foi clicado, e nele temos o commandparameter, assim posso pegar o funcionario
            //que foi enviado, assim trabalhamos dentro do mesmo objeto

            //aqui faço um casting para o sender pois sei que ele que foi clicado é um MenuItem
            //assim eu reconheco ele
            MenuItem botao = (MenuItem)sender;
            //aqui faço um casting para o botao.parammeter que é um funcionario, o que foi passado.
            Funcionario func = (Funcionario)botao.CommandParameter;

            DisplayAlert("Titulo " + func.Nome, "Mensagem " + func.Nome + " - " + func.Cargo, "Okey");


        }


        private void AbonoAction(object sender, EventArgs args)
        {


        }
    }
}