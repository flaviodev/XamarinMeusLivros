using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace MeusLivros.Model
{
    class Livro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ISBN13 { get; set; }
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public string Descricao { get; set; }
        public int NumeroPaginas { get; set; }
        public bool Lido { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", new string[] { Titulo, Autores});
        }
    }

}

