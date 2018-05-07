using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Pedidos.Sqlite.Banco;
using Pedidos.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace Pedidos.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBiblioteca = Path.Combine(caminhoDaPasta, "..", "Library");

            string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}