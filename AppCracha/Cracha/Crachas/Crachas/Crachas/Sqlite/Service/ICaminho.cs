using System;
using System.Collections.Generic;
using System.Text;

namespace Crachas.Sqlite.Service
{
    public interface ICaminho
    {
        string ObterCaminho(string NomeArquivoBanco);
    }
}
