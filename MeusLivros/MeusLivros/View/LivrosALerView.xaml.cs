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
    public partial class LivrosALerView : ContentPage
    {
        private LivrosALerViewModel livrosALerViewModel;

        public LivrosALerView()
        {
            InitializeComponent();
            livrosALerViewModel = new LivrosALerViewModel();
            this.BindingContext = livrosALerViewModel;
        }

        private void AtualizarLista()
        {
            this.ListaLivrosALer.ItemsSource = livrosALerViewModel.ListarLivrosALer();
        }

        protected override void OnAppearing()
        {
            this.AtualizarLista();
        }

        private void Selecionar(object sender, SelectedItemChangedEventArgs e)
        {
            livrosALerViewModel.Selecionar((Livro)ListaLivrosALer.SelectedItem);
        }

    }
}