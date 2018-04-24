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

        private void GoDatePicker(object sender, EventArgs args)
        {
            Detail = new Controles.DatePickerPage();
            IsPresented = false;
        }


        private void GoTimePicker(object sender, EventArgs args)
        {
            Detail = new Controles.TimePickerPage();
            IsPresented = false;
        }

        private void GoPicker(object sender, EventArgs args)
        {
            Detail = new Controles.PickerPage();
            IsPresented = false;
        }

        private void GoSearchBar(object sender, EventArgs args)
        {
            Detail = new Controles.SearchBarPage();
            IsPresented = false;
        }

        private void GoSliderStepper(object sender, EventArgs args)
        {
            Detail = new Controles.SliderStepperPage();
            IsPresented = false;
        }

        private void GoSwitch(object sender, EventArgs args)
        {
            Detail = new Controles.SwitchPage();
            IsPresented = false;
        }

        private void GoImage(object sender, EventArgs args)
        {
            Detail = new Controles.ImagePage();
            IsPresented = false;
        }

        private void GoListView(object sender, EventArgs args)
        {
            Detail = new Controles.ListViewPage();
            IsPresented = false;
        }

        private void GoTableView(object sender, EventArgs args)
        {
            Detail = new Controles.TableViewPage();
            IsPresented = false;
        }

        private void GoWebView(object sender, EventArgs args)
        {
            Detail = new Controles.WebViewPage();
            IsPresented = false;

        }

    }
}