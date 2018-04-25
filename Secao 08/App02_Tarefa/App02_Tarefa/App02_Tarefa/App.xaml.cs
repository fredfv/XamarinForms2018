using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App02_Tarefa
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //Aqui temos uma tela de inicio. 
            MainPage = new NavigationPage(new App02_Tarefa.Telas.Inicio());
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
