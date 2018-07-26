using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.SqlServer.Model
{
    public class Marca
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int codigo { get; set; }
        public bool ativo { get; set; }
        public DateTime dataInclusao { get; set; }
    }
}
