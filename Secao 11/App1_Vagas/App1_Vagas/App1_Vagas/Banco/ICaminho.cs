using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Vagas.Banco
{
    public interface ICaminho
    {
        //PRECISA SER CHAMADO UM METODO E ELE RETORNO O CAMINHO ONDE ESTA SALVO O BANCO
        //
        string ObterCaminho(string NomeArquivoBanco);

    }
}
