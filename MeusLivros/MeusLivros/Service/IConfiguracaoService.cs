using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Service
{
    public interface IConfiguracaoService
    {
        string DiretorioDB { get; }

        ISQLitePlatform Plataforma { get; }
    }
}
