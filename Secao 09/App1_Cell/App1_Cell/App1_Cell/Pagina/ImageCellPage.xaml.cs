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
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Foto = "Perfil.png", Nome = "Fred", Cargo = "Estagiario" });
            Lista.Add(new Funcionario() { Foto = "Perfil.png", Nome = "Elias", Cargo = "Desenvolvedor" });
            Lista.Add(new Funcionario() { Foto = "Perfil.png", Nome = "Tito", Cargo = "Gato De Rua " });
            Lista.Add(new Funcionario() { Foto = "Perfil.png", Nome = "Mica", Cargo = "Gata do telhado " });
            Lista.Add(new Funcionario() { Foto = "Perfil.png", Nome = "Lala", Cargo = "Caseira " });

            ListaDeFuncionarios.ItemsSource = Lista;

        }
    }
}