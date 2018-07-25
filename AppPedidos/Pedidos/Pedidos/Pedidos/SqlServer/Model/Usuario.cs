using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.SqlServer.Model
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public int IdPessoa { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Funcao { get; set; }

        public string Login { get; set; }

        public int? IdResponsavel { get; set; }

        public bool Ativo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
