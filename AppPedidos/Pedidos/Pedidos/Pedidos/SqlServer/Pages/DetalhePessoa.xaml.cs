﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.SqlServer.Models;

namespace Pedidos.SqlServer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePessoa : ContentPage
	{
		public DetalhePessoa (Pessoa pessoa)
		{
			InitializeComponent ();

            BindingContext = pessoa;
		}
	}
}