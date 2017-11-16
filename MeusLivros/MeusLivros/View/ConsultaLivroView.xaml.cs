using MeusLivros.Model;
using MeusLivros.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusLivros.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaLivroView : ContentPage
    {
        private ConsultaLivroViewModel consultaLivroViewModel;
        private Livro _livro;

        public ConsultaLivroView(object livro)
        {
            InitializeComponent();
            consultaLivroViewModel = new ConsultaLivroViewModel();
            this.BindingContext = consultaLivroViewModel;
            _livro = (Livro) livro;
            PopulaCampos(_livro);
            Estado.Text = _livro.Lido ? "Marcar livro como não lido" : "Marcar livro como lido";
        }

        private void PopulaCampos(Livro livro)
        {
            this.ISBN.Text = livro.ISBN13;
            this.Titulo.Text = livro.Titulo;
            this.Autores.Text = livro.Autores;
            this.Descricao.Text = livro.Descricao;
            this.NumeroPaginas.Text = livro.NumeroPaginas.ToString();
        }

        private void EditarClicked(object sender, EventArgs e)
        {
            consultaLivroViewModel.Alterar(_livro);
        }

        private void ExcluirClicked(object sender, EventArgs e)
        {
            consultaLivroViewModel.Excluir(_livro);
        }

        private void AlterarEstadoClicked(object sender, EventArgs e)
        {
            consultaLivroViewModel.AlterarEstado(_livro);
        }

        protected override void OnAppearing()
        {
            _livro = consultaLivroViewModel.ObterLivro(_livro.Id);
            PopulaCampos(_livro);
        }
    }
}