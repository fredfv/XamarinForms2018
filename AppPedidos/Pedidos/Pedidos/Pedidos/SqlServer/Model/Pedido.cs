using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.SqlServer.Model
{
    public class Pedido
    {

        public int id { get; set; }

        public int idProduto { get; set; }

        public int perda { get; set; }

        public int troca { get; set; }

        public int quantidade { get; set; }

        public string obs { get; set; }

        public string nomeProduto { get; set; }

        public DateTime dataInclusao { get; set; }
        public int idUsuarioInclusao { get; set; }

        public DateTime? dataAlteracao { get; set; }
        public int? idUsuarioAlteracao { get; set; }

    }
}
