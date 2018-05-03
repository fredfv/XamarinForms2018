using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1_Vagas.Modelos
{
    //PREPARANDO A CLASSE PARA CRIAR UMA TABELA
    //usamos o sqlite, 
    //vamos definir pelo DataAnotatios 
    //Anotation TABLE e dou o nome
    [Table("Vaga")]
    public class Vaga
    {
        //anotation de uma primary key e autoincrement
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string NomeVaga { get; set; }
        public short Quantidade { get; set; }
        public string Empresa { get; set; }
        public string Cidade { get; set; }
        public double Salario { get; set; }
        public string Descricao { get; set; }
        public string TipoContratacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
