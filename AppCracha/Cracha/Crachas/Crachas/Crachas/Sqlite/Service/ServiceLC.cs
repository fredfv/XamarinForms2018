using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Crachas.Sqlite.Models;

namespace Crachas.Sqlite.Service
{
    public class ServiceLC
    {
        private SQLiteConnection _conexao;

        public ServiceLC()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<BaseClass>();
        }

        //OBTER TODAS
        public List<BaseClass> GetBaseClass()
        {
            return _conexao.Table<BaseClass>().ToList();
        }
        //OBTER POR ID
        public BaseClass GetBaseClassById(int id)
        {
            return _conexao.Table<BaseClass>().Where(a => a.Id == id).FirstOrDefault();
        }
        //OBTER POR NOME
        public List<BaseClass> GetBaseClassByName(string nome)
        {
            return _conexao.Table<BaseClass>().Where(a => a.Nome.Contains(nome)).ToList();
        }
        //INSERIR
        public void InsertBaseClass(BaseClass baseClass)
        {
            _conexao.Insert(baseClass);
        }
        //ATUALIZAR
        public void UpdateBaseClass(BaseClass baseClass)
        {
            _conexao.Update(baseClass);
        }
        //DELETAR
        public void DeleteBaseClass(BaseClass baseClass)
        {
            _conexao.Delete(baseClass);
        }
    }
}
