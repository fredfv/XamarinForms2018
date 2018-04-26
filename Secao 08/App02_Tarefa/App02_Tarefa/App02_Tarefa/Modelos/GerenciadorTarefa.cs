using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App02_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }

        public void Salvar(Tarefa tarefa)
        {
            Lista = Listar();
            Lista.Add(tarefa);
            //ESSA ESTRUTURA PODE RECEBER UM DICIONARIO E UMA CHAVE
            //VAI RECEBER UMA CHAVE E UM OIBJETO ONDE O OBJETO É A LISTA
            //POSSO ARMAZENAR AS INFORMACOES COMO SE FOSSE UM BANCO, GUARDA CHAVE E VALOR
            SalvarNoProperties(Lista);
        }

        public void Deletar(int index)
        {
            Lista = Listar();
            Lista.RemoveAt(index);
            SalvarNoProperties(Lista);
        }

        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listar();
            Lista.RemoveAt(index);

            tarefa.DataFinizalicao = DateTime.Now;
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }

        public List<Tarefa> Listar()
        {
            return ListarNoProperties();
        }

        private void SalvarNoProperties(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            string JsonVal = JsonConvert.SerializeObject(Lista);

            App.Current.Properties.Add("Tarefas", JsonVal);
        }

        private List<Tarefa> ListarNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                //AQUI VAMOS USAR O JSON PARA DESERIALIZAR E RETORNAR A LISTA
                //fazemos um casting para a propriedade App.Currente Ser uma String
                String JsonVal = (String)App.Current.Properties["Tarefas"];
                //Utilizar o json convert 
                //passando o tipo de informacao que tem dentro de tarefas, que é uma lista de tarefa, e passando
                List<Tarefa> Lista = JsonConvert.DeserializeObject<List<Tarefa>>(JsonVal);
                return Lista;
                //nos parenteses o json val, feito isso vamos receber uma lista de tarefas.
                //E colocamos na variavel lista

                //COMO É DO TIPO TAREFAS, UMA LISTA VAMOS FAZER UM CASTING
                //return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }

            return new List<Tarefa>();
        }
    }
}
