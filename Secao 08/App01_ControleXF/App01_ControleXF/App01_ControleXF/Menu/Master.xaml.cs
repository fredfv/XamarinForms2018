using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoActivityIndicator(object sender, EventArgs args)
        {
            Detail = new Controles.ActivityIndicatorPage();
            IsPresented = false;
        }

        private void GoProgressBar(object sender, EventArgs args)
        {
            Detail = new Controles.ProgressBarPage();
            IsPresented = false;
        }

        private void GoBoxView(object sender, EventArgs args)
        {
            Detail = new Controles.BoxViewPage();
            IsPresented = false;
        }

        private void GoLabel(object sender, EventArgs args)
        {
            Detail = new Controles.LabelPage();
            IsPresented = false;
        }

        private void GoButton(object sender, EventArgs args)
        {
            Detail = new Controles.ButtonPage();
            IsPresented = false;
        }

        private void GoEntryEditor(object sender, EventArgs args)
        {
            Detail = new Controles.EntryEditorPage();
            IsPresented = false;
        }

        private void DatePicker(object sender, EventArgs args)
        {
            Detail = new Controles.DatePickerPage();
            IsPresented = false;
        }


        private void TimePicker(object sender, EventArgs args)
        {
            Detail = new Controles.TimePickerPage();
            IsPresented = false;
        }

        private void Picker(object sender, EventArgs args)
        {
            Detail = new Controles.PickerPage();
            IsPresented = false;
        }

        private void SearchBar(object sender, EventArgs args)
        {
            Detail = new Controles.SearchBarPage();
            IsPresented = false;
        }

        private void SliderStepper(object sender, EventArgs args)
        {
            Detail = new Controles.SliderStepperPage();
            IsPresented = false;
        }

        private void Switch(object sender, EventArgs args)
        {
            Detail = new Controles.SwitchPage();
            IsPresented = false;
        }

        private void Image(object sender, EventArgs args)
        {
            Detail = new Controles.ImagePage();
            IsPresented = false;
        }


    }
}