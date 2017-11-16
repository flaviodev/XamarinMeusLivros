using MeusLivros.Model;
using MeusLivros.Repository;
using MeusLivros.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeusLivros.ViewModel
{
    class ConsultaLivroViewModel
    {
        private readonly INavegacaoService _navegacaoService;

        public ConsultaLivroViewModel()
        {
            this._navegacaoService = DependencyService.Get<INavegacaoService>();
        }

        public async void Alterar(Livro livro)
        {
            await this._navegacaoService.NavegaParaMantemLivro(livro, false, livro.Lido);
        }

        public async void AlterarEstado(Livro livro)
        {
            using (var dados = new LivroRepository())
            {
                livro.Lido = !livro.Lido;
                dados.Update(livro);
                await _navegacaoService.Voltar();
            }
        }

        public async void Excluir(Livro livro)
        {
            using (var dados = new LivroRepository())
            {
                dados.Delete(livro);
                await _navegacaoService.Voltar();
            }
        }

        public Livro ObterLivro(int id)
        {
            using (var dados = new LivroRepository())
            {
                return dados.ObterPeloId(id);
            }
        }

    }
}
