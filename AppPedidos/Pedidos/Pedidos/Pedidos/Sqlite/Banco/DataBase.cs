using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using SQLite;
using Pedidos.Sqlite.Modelos;
using Xamarin.Forms;

namespace Pedidos.Sqlite.Banco
{
    class DataBase
    {

         
        private SQLiteConnection _conexao;

        //ABERTURA DA CONEXAO COM SQLITE
        public DataBase()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("pedidosdb.sqlite");

            _conexao = new SQLiteConnection(caminho);


            _conexao.CreateTable<Funcao>();
            _conexao.CreateTable<Pessoa>();
            _conexao.CreateTable<Usuario>();

            _conexao.CreateTable<Marca>();
            _conexao.CreateTable<Pedido>();
            _conexao.CreateTable<Produto>();


        }
        //


        //CRUD FUNCAO

        public List<Funcao> FuncaoConsultar()
        {
            return _conexao.Table<Funcao>().ToList();
        }

        public List<Funcao> FuncaoPesquisar(string descricao)
        {
            return _conexao.Table<Funcao>().Where(a => a.Descricao.Contains(descricao)).ToList();
        }

        public Funcao FuncaoObterPorId(int id)
        {
            return _conexao.Table<Funcao>().Where(a => a.Id == id).FirstOrDefault();
        }
        
        public void FuncaoCadastrar(Funcao funcao)
        {
            _conexao.Insert(funcao);
        }

        public void FuncaoAtualizar(Funcao funcao)
        {
            _conexao.Update(funcao);
        }

        public void FuncaoExcluir(Funcao funcao)
        {
            _conexao.Delete(funcao);
        }

        //CRUD FUNCAO

        //-------------------------------------------------------------------------------

        //CRUD MARCA

        public List<Marca> MarcaConsultar()
        {
            return _conexao.Table<Marca>().ToList();
        }

        public List<Marca> MarcaPesquisar(string nome)
        {
            return _conexao.Table<Marca>().Where(a => a.Nome.Contains(nome)).ToList();
        }

        public Marca MarcaObterPorId(int id)
        {
            return _conexao.Table<Marca>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void MarcaCadastrar(Marca funcao)
        {
            _conexao.Insert(funcao);
        }

        public void MarcaAtualizar(Marca funcao)
        {
            _conexao.Update(funcao);
        }

        public void MarcaExcluir(Marca funcao)
        {
            _conexao.Delete(funcao);
        }

        //CRUD MARCA






    }
}
