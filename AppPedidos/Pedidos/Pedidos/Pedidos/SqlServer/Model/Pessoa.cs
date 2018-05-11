using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.SqlServer.Model
{
    public class Pessoa
    {
        public int idPessoa { get; set; }

        public string nome { get; set; }
        public string cpf { get; set; }

        public string dataNascimento { get; set; }
        //public DateTime? dataNascimento { get; set; }

        public string rg { get; set; }
        public string sexo { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string numero { get; set; }
        public string telefone { get; set; }

        public bool ativo { get; set; }

        //public DateTime? dataInclusao { get; set; }
        //public int? idUsuarioInclusao { get; set; }
        //public DateTime? dataAlteracao { get; set; }
        //public int? idUsuarioAlteracao { get; set; }
    }
}
