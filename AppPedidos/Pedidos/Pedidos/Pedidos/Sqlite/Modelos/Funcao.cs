using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Pedidos.Sqlite.Modelos
{
    [Table ("Funcao")]
    public class Funcao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}
