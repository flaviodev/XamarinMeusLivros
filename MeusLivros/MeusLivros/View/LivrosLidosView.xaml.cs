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
    public partial class LivrosLidosView : ContentPage
    {
        private LivrosLidosViewModel livrosLidosViewModel;

        public LivrosLidosView()
        {
            InitializeComponent();

            livrosLidosViewModel = new LivrosLidosViewModel();
            this.BindingContext = livrosLidosViewModel;
        }

        private void AtualizarLista()
        {
            this.ListaLivrosLidos.ItemsSource = livrosLidosViewModel.ListarLivrosALer();
        }

        protected override void OnAppearing()
        {
            this.AtualizarLista();
        }

        private void Selecionar(object sender, SelectedItemChangedEventArgs e)
        {
            livrosLidosViewModel.Selecionar((Livro)ListaLivrosLidos.SelectedItem);
        }

    }
}