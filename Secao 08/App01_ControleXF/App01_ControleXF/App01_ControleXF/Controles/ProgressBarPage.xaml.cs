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
	public partial class ProgressBarPage : ContentPage
	{
		public ProgressBarPage ()
		{
			InitializeComponent ();
		}

        public void Modificar(object sender, EventArgs args)
        {
            bar1.Progress = 1;

            bar2.ProgressTo(1, 5000, Easing.BounceIn);

            bar3.ProgressTo(1, 5000, Easing.CubicIn);

            bar4.ProgressTo(1, 5000, Easing.CubicInOut);

            bar5.ProgressTo(1, 5000, Easing.Linear);

            bar6.ProgressTo(1, 5000, Easing.SinIn);

            bar7.ProgressTo(1, 5000, Easing.SinInOut);

            bar8.ProgressTo(1, 5000, Easing.SpringIn);

            bar9.ProgressTo(1, 10000, Easing.Linear);


        }

        public void ZerarBarras(object sender, EventArgs args)
        {
            bar1.Progress = 0;

            bar2.ProgressTo(0, 2000, Easing.BounceOut);

            bar3.ProgressTo(0, 2000, Easing.CubicOut);

            bar4.ProgressTo(0, 2000, Easing.CubicInOut);

            bar5.ProgressTo(0, 2000, Easing.Linear);

            bar6.ProgressTo(0, 2000, Easing.SinOut);

            bar7.ProgressTo(0, 2000, Easing.SinInOut);

            bar8.ProgressTo(0, 2000, Easing.SpringOut);

            bar9.ProgressTo(0, 10000, Easing.Linear);

        }

	}
}