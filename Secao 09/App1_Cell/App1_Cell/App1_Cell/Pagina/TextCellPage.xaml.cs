using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Cell.Modelo;

namespace App1_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextCellPage : ContentPage
	{
		public TextCellPage ()
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


    }
}