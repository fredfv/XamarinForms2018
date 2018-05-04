using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Mimica.Model
{
    public class Jogo
    {
        public Grupo Grupo1 { get; set; }
        public Grupo Grupo2 { get; set; }

        public string MyProperty { get; set; }
        public short TempoPalavra { get; set; }
        public short Rodadas { get; set; }
    }
}
