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

    class LivrosALerViewModel
    {

        public ICommand NovoCommand
        {
            get;
            set;
        }

        private readonly Service.INavegacaoService _navegacaoService;

        public LivrosALerViewModel()
        {
            this.NovoCommand = new Command(this.Novo);
            this._navegacaoService = DependencyService.Get<Service.INavegacaoService>();
        }
 
        private async void Novo()
        {
            await this._navegacaoService.NavegaParaMantemLivro(new Livro(), true, false);
        }

        public List<Livro> ListarLivrosALer()
        {
            using (var dados = new LivroRepository())
            {
                return dados.Listar(false);
            }
        }

        public async void Selecionar(Livro livro)
        {
            await this._navegacaoService.NavegaParaConsultaLivro(livro);
        }
    }
}
