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
	public partial class ImagePage : ContentPage
	{
		public ImagePage ()
		{
			InitializeComponent ();
            //    ImageOne.IsLoading

            //OS FILHOS SAO UMA LISTA
            //LISTA DE FILHOS OMG


            //usando o xamarin forms
            Image imgUSB = new Image();
            //NO XAML COLOCA O ENDERECO DIRETO, E PODE POR O NOME SEM A URL E ELE PEGA DENTRO DO APP
            //NO C# USAMOS A CLASSE IMAGESORUCE PARA INDICAR DE ONDE VEM A IMAGEM
            if (Device.RuntimePlatform == Device.UWP)
            {
                imgUSB.Source = ImageSource.FromFile("Img/usb.jpg");
            }
            else
            {
                imgUSB.Source = ImageSource.FromFile("usb.jpg");
            }
            Container.Children.Add(imgUSB);
        }
    }
}