using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras = 
        {
            //F
            new string[]{"Olho", "Lingua", "Chinelo", "Milho", "Penalti", "Bola", "Ping-Pong"},
            //M
            new string[]{"Carpinteiro", "Amarelo", "Limão", "Abelha"},
            //D
            new string[]{"Cisterna", "Lanterna", "Batman vs Superman", "NoteBook" },

        };
    }
}
