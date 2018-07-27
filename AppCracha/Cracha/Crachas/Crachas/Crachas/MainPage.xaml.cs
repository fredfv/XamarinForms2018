using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Crachas.Sqlite.Models;
using Crachas.Sqlite.Service;

namespace Crachas
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            ServiceLC sc = new ServiceLC();

            BaseClass bc = new BaseClass { Cpf = "2", Nome = "Teste" };

            sc.InsertBaseClass(bc);

            BaseClass vc = sc.GetBaseClassById(1);
            lblInicio.Text = vc.Cpf;
            lblFinal.Text = vc.Nome;
		}
	}
}
