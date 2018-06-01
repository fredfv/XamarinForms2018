using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3_JWTAsync.Service;

namespace App3_JWTAsync
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}


        public async void Get(object sender, EventArgs args)
        {
            string resultado = await JWTService.GetToken(nome.Text, password.Text);
            LblToken.Text = resultado;
        }

        public async void Verificar(object sender, EventArgs args)
        {
            string resultado = await JWTService.Verificar();
            LblResultado.Text = resultado;
        }

    }
}
