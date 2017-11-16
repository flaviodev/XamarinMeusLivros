using MeusLivros.Model;
using MeusLivros.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeusLivros.ViewModel
{
    class LivrosLidosViewModel
    {
        public ICommand NovoCommand
        {
            get;
            set;
        }

        private readonly Service.INavegacaoService _navegacaoService;

        public LivrosLidosViewModel()
        {
            this.NovoCommand = new Command(this.Novo);
            this._navegacaoService = DependencyService.Get<Service.INavegacaoService>();
        }

        private async void Novo()
        {
            await this._navegacaoService.NavegaParaMantemLivro(new Livro(), true, true);
        }

        public List<Livro> ListarLivrosALer()
        {
            using (var dados = new LivroRepository())
            {
                return dados.Listar(true);
            }
        }

        public async void Selecionar(Livro livro)
        {
            await this._navegacaoService.NavegaParaConsultaLivro(livro);
        }
    }
}
