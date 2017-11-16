using MeusLivros.Model;
using MeusLivros.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusLivros.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MantemLivroView : ContentPage
    {
        private Livro _livro;
        private bool _novo;
        private bool _lido;

        private MantemLivroViewModel mantemLivroViewModel;

        public MantemLivroView(object livro, bool novo, bool lido)
        {
            InitializeComponent();
            mantemLivroViewModel = new MantemLivroViewModel();
            this.BindingContext = mantemLivroViewModel;

            _livro = (Livro)livro;
            _novo = novo;
            _lido = lido;

            _livro.Lido = _lido;

            if (_novo)
            {
                this.Title = "Novo Livro " + (_lido ? "(lido)" : "(a ler)");
            }
            else
            {
                this.Title = "Alterar Livro " + (_lido ? "(lido)" : "(a ler)");
            }

            PopulaCampos(_livro);

        }

        private void PopulaCampos(Livro livro)
        {
            this.ISBN.Text = livro.ISBN13;
            this.Titulo.Text = livro.Titulo;
            this.Autores.Text = livro.Autores;
            this.Descricao.Text = livro.Descricao;
            this.NumeroPaginas.Text = livro.NumeroPaginas.ToString();
        }

        public async void BuscarLivroClicked()
        {
            ConsultaLivros consulta = await mantemLivroViewModel.ConsultaISBN(ISBN.Text);

            if (consulta != null && consulta.items != null && consulta.items.Count()>0)
            {
                DadosLivro dados = consulta.items.ElementAt(0);
                this.Titulo.Text = dados.volumeInfo.title;

                string autores = "";
                foreach(string autor in dados.volumeInfo.authors) {
                    if(!autores.Equals(""))
                    {
                        autores += ", ";
                    }
                    autores += autor;
                }

                this.Autores.Text = autores;
                this.Descricao.Text = dados.volumeInfo.description;
                this.NumeroPaginas.Text = dados.volumeInfo.pageCount.ToString();
            } else
            {
                await MeusLivros.App.Current.MainPage.DisplayAlert("Mensagem", "Não foi localizado nenhum livro para o ISBN informado", "ok");
            }
        }

        public void SalvarClicked()
        {
            _livro.ISBN13 = this.ISBN.Text;
            _livro.Titulo = this.Titulo.Text;
            _livro.Autores = this.Autores.Text;
            _livro.Descricao = this.Descricao.Text;
            _livro.NumeroPaginas = int.Parse(this.NumeroPaginas.Text);

            if (_novo)
            {
                mantemLivroViewModel.Incluir(_livro);
            }
            else
            {
                mantemLivroViewModel.Alterar(_livro);
            }
        }
    }
}