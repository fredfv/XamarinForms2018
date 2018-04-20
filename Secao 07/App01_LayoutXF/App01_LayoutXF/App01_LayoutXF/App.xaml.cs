using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App01_LayoutXF
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //INSTANCIANDO UMA NAVIGATION PAGE PARA QUE POSSA OCORRER UMA NAVEGACAOP ENTRE AS PAGINAS, GUARDANDO O HISTORY[
            //E PODENDEO USAR O PUSH AND POP , LEMBRANDO QUE SE EU PRECISAR CHAMAR SEMPRE TENHO QUE USAR O NAV
			MainPage = new NavigationPage(new App01_LayoutXF.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
