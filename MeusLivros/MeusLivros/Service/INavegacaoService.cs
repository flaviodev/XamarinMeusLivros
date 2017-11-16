using MeusLivros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Service
{
    interface INavegacaoService
    {
        Task Voltar();
        Task NavegaParaConsultaLivro(Livro livro);
        Task NavegaParaMantemLivro(Livro livro, bool novo, bool lido);
    }
}
