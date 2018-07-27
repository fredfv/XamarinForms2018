using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Crachas.Sqlite.Service;
using Xamarin.Forms;
using System.IO;
using Crachas.iOS.Banco;

[assembly: Dependency(typeof(Caminho))]
namespace Crachas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoDaBiblioteca = Path.Combine(caminhoDaPasta, "..", "Library");
            string caminhoBanco = Path.Combine(caminhoDaBiblioteca, NomeArquivoBanco);
            return caminhoBanco;
        }
    }
}