using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Pedidos.Sqlite.Modelos
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdPessoa { get; set; }

        public string Nome { get; set; }
        public string Senha  { get; set; }
        public string Funcao { get; set; }
        public string Login { get; set; }
        public int? IdResponsavel { get; set; }
        public int Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
