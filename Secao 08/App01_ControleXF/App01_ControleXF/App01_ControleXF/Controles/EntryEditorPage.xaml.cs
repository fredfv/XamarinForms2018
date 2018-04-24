using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryEditorPage : ContentPage
	{
		public EntryEditorPage ()
		{
			InitializeComponent ();

            TxtIdade.TextChanged += delegate (object sender, TextChangedEventArgs args)
            {
                Lbl_Duplicada.Text = args.NewTextValue;
            };


            TxtComentario.Completed += delegate (object sender, EventArgs args)
            {
                Lbl_Qtd.Text = TxtComentario.Text.Length.ToString();

            };

        }




        public void MostrarPassword(object sender, EventArgs args)
        {
            TxtIdade.IsPassword = !TxtIdade.IsPassword;
        }
	}
}