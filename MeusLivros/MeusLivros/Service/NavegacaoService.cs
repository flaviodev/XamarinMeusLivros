using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeusLivros.Model;
using MeusLivros.View;

namespace MeusLivros.Service
{
    class NavegacaoService : INavegacaoService
    {
        public async Task Voltar()
        {
            await MeusLivros.App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavegaParaConsultaLivro(Livro livro)
        {
            await MeusLivros.App.Current.MainPage.Navigation.PushAsync(new ConsultaLivroView(livro));
        }

        public async Task NavegaParaMantemLivro(Livro livro, bool novo, bool lido)
        {
            await MeusLivros.App.Current.MainPage.Navigation.PushAsync(new MantemLivroView(livro, novo, lido));
        }
    }
}
