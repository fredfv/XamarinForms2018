using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01_ControleXF.Modelo;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            //List<Pessoa> lista = Banco.GetPessoas();
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa { Nome = "Fred", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Elias", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Tito", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Mica", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Lala", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Mi", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Nemi", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Tig", Idade = "29" });

            ListaPessoas.ItemsSource = lista;

        }
	}
}