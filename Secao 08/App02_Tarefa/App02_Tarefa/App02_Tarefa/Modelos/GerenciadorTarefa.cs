using System;
using System.Collections.Generic;
using System.Text;

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

        public void Deletar(Tarefa tarefa)
        {
            Lista.Remove(tarefa);
            SalvarNoProperties(Lista);
        }

        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista.RemoveAt(index);
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
            App.Current.Properties.Add("Tarefas", Lista);
        }

        private List<Tarefa> ListarNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                //COMO É DO TIPO TAREFAS, UMA LISTA VAMOS FAZER UM CASTING
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }

            return new List<Tarefa>();
        }
    }
}
