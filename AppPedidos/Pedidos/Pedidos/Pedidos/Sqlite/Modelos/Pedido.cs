using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Pedidos.Sqlite.Modelos
{
    [Table("Pedido")]
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Id_Produto { get; set; }

        public int Perda { get; set; }
        public int Troca { get; set; }
        public int Quantidade { get; set; }
        public string Obs { get; set; }

        public DateTime DataInclusao { get; set; }
        public int Id_UsuarioInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
        public int? Id_UsuarioAlteracao { get; set; }


    }
}
