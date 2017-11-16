using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Model
{
    class DadosVolume
    {
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
    }
}
