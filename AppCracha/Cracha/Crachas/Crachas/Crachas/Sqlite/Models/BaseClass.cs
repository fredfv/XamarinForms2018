using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Crachas.Sqlite.Models
{
    [Table("Base")]
    public class BaseClass
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
