using MeusLivros.Model;
using MeusLivros.Repository;
using MeusLivros.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusLivros.ViewModel
{
    class MantemLivroViewModel
    {
        private readonly INavegacaoService _navegacaoService;

        public MantemLivroViewModel()
        {
            this._navegacaoService = DependencyService.Get<INavegacaoService>();
        }

        public async Task<ConsultaLivros> ConsultaISBN(string ISBN)
        {
            HttpClient _Client = new HttpClient();
            var content = await _Client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=isbn:" + ISBN);
            ConsultaLivros consulta = JsonConvert.DeserializeObject<ConsultaLivros>(content);
            
            return consulta;
        }

        public void Incluir(Livro livro)
        {
            using (var dados = new LivroRepository())
            {
                dados.Insert(livro);
                _navegacaoService.Voltar();
            }
        }

        public void Alterar(Livro livro)
        {
            using (var dados = new LivroRepository())
            {
                dados.Update(livro);
                _navegacaoService.Voltar();
            }
        }
    }
}
