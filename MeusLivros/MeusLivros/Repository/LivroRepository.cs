using MeusLivros.Model;
using MeusLivros.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusLivros.Repository
{
    class LivroRepository : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexao;

        public LivroRepository()
        {
            var config = DependencyService.Get<IConfiguracaoService>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancoLivros.db3"));
            _conexao.CreateTable<Livro>();
        }

        public async void Insert(Livro Livro)
        {
            _conexao.Insert(Livro);
        }

        public async void Update(Livro Livro)
        {
            _conexao.Update(Livro);
        }

        public async void Delete(Livro Livro)
        {
            _conexao.Delete(Livro);
        }

        public List<Livro> Listar()
        {
            return _conexao.Table<Livro>().OrderBy(c => c.Titulo).ToList();
        }

        public List<Livro> Listar(bool lido)
        {
            return _conexao.Table<Livro>().Where(c => c.Lido == lido).OrderBy(c => c.Titulo).ToList();
        }


        public Livro ObterPeloId(int id)
        {
            return _conexao.Table<Livro>().FirstOrDefault(c => c.Id == id);

        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }

}
