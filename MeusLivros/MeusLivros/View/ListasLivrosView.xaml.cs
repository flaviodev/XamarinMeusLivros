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
    public partial class ListasLivrosView : TabbedPage
    {
        private ListasLivrosViewModel listaLivrosViewModel;

        public ListasLivrosView()
        {
            InitializeComponent();
            listaLivrosViewModel = new ListasLivrosViewModel();
            this.BindingContext = listaLivrosViewModel;
        }

        public async void SobreClicked()
        {
            await MeusLivros.App.Current.MainPage.DisplayAlert("Sobre", "Trabalho Xamarin v3.0.0\n Flávio de Souza \n fdsdev@gmail.com", "ok");
        }
    }
}