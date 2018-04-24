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
    public partial class LabelPage : ContentPage
    {
        public LabelPage()
        {
            InitializeComponent();
        }



        //public void TrocarFonte(object sender, EventArgs args)
        //{
       
        
            //<Label x:Name="LabelTwo" Text=""/>

            //<Button x:Name="d" Text="Padrão" Clicked="TrocarFonte"/>
            //<Button x:Name="g" Text="Grande" Clicked="TrocarFonte"/>
            //<Button x:Name="m" Text="Médio" Clicked="TrocarFonte"/>
            //<Button x:Name="p" Text="Pequena" Clicked="TrocarFonte"/>
            //<Button x:Name="mm" Text="Micro" Clicked="TrocarFonte"/>

        //}
    }
}