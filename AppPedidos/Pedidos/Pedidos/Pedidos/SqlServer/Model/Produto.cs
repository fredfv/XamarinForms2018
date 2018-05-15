using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.SqlServer.Model
{
    public class Produto
    {
        public int id { get; set; }

        public string nome { get; set; }

        public int? codigo { get; set; }

        public int idMarca { get; set; }

        public string nomeMarca { get; set; }

        public DateTime dataInclusao { get; set; }

        public DateTime dataAlteracao { get; set; }

        public int idUsuarioInclusao { get; set; }

        public bool ativo { get; set; }
    }
}
