using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Sqlite.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string NomeArquivoBanco);

    }
}
