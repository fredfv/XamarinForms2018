using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using App1_Vagas.Modelos;
using Xamarin.Forms;


namespace App1_Vagas.Banco
{
    class DataBase
    {
        private SQLiteConnection _conexao;

        public DataBase()
        {

            //O CAMINHO PARA O USO DO SQLITE É DIFERENTE EM CADA PLATAFORMA
            //VAMOS USAR O DEPENDECY SERVIRCE 
            //criando uma interface

            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("DataBase.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();

        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }

        public List<Vaga> Pesquisa(string palavra)
        {
            //return _conexao.Table<Vaga>().Where(a => a.NomeVaga.ToLower().Contains(palavra.ToLower())).ToList();
            return _conexao.Table<Vaga>().Where(a => a.NomeVaga.Contains(palavra)).ToList();
        }

        public Vaga ObterVagaPorId(int id)
        {
            return _conexao.Table<Vaga>().Where(a => a.Id == id).FirstOrDefault(); 
        }

        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

        public void Atualizar(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }


    }
}
