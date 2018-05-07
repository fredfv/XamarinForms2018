using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Pedidos.Sqlite.Modelos
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string RG { get; set; }
        public string Sexo { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }
        public int Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }
        public int? IdUsuarioInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }



    }
}
