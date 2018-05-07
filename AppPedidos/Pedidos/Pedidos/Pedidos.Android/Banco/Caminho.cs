using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Pedidos.Sqlite.Banco;
using Pedidos.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]  
namespace Pedidos.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = Path.Combine(caminhoDaPasta, NomeArquivoBanco);

            return caminhoBanco;

        }
    }
}