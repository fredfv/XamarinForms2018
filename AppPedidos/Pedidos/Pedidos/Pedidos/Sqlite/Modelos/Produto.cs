using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Pedidos.Sqlite.Modelos
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int Ativo { get; set; }

        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public int Id_Marca { get; set; }
    }
}
