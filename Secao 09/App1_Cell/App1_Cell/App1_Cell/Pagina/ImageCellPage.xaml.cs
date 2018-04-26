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
            Lista.Add(new Funcionario() { Foto = "https://scontent.fcgh14-1.fna.fbcdn.net/v/t1.0-1/c23.0.160.160/p160x160/10264678_10201152650378311_9170188103740986818_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeHJFcC2SCtQzgH1jkSDG2edg4bFmk8samn5cb0HPr_n6maAjwYGXQhM49aPWRPC6BsgwkbX1IXexdT9IAwCY3d7lUyldfi10FU7V_QfxR1yvw&oh=75654319922fd7ef519c22c55f461b01&oe=5B58D9D8", Nome = "Fred", Cargo = "Estagiario" });
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRquulN4gCXtav1F75PFztckRVZ1X21rOP5V3YJbKOgxukorCb", Nome = "Elias", Cargo = "Desenvolvedor" });
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZhbcUCFicI7FSZiQf17q3IXHf1EwDtDvKhSh-67cQk6V6u71n ", Nome = "Tito", Cargo = "Gato De Rua " });
            Lista.Add(new Funcionario() { Foto = "https://images01.olx-st.com/ui/55/78/69/39/t_1524196356_6fc561307c255fec7cc4ede4479dedd9.jpg", Nome = "Mica", Cargo = "Gata do telhado " });
            Lista.Add(new Funcionario() { Foto = "https://images01.olx-st.com/ui/50/43/61/96/t_1520719309_75b4ab1cb43dd838d44281afe9008c37.jpg", Nome = "Lala", Cargo = "Caseira " });

            ListaDeFuncionarios.ItemsSource = Lista;

        }
    }
}