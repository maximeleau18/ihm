using ClassLibraryEntity;
using Pokemon.Pages.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokemon.ViewModels
{
    public class ChoosePNJViewModel
    {
        private ChoosePNJView choosePNJView;
        public ChoosePNJView ChoosePNJView
        {
            get
            {
                return choosePNJView;
            }

            set
            {
                choosePNJView = value;
            }
        }

        public ChoosePNJViewModel(ChoosePNJView choosePNJView)
        {
            this.ChoosePNJView = choosePNJView;
            this.Init();
            this.Bind();
        }

        public async void Init()
        {
            ClassLibraryEntity.API.ApiManager manager = new ClassLibraryEntity.API.ApiManager();
            this.ChoosePNJView.LoadItems(await manager.GetListFromApi<List<PersonnageNonJoueur>>());
        }

        public void Bind()
        {
            this.ChoosePNJView.ButtonBack.Tapped += ButtonBack_Tapped;
            this.ChoosePNJView.ButtonValidate.Tapped += ButtonValidate_Tapped;
            this.ChoosePNJView.ButtonBack.PointerEntered += ButtonBack_PointerEntered;
            this.ChoosePNJView.ButtonBack.PointerExited += ButtonBack_PointerExited;
            this.ChoosePNJView.ButtonValidate.PointerEntered += ButtonValidate_PointerEntered;
            this.ChoosePNJView.ButtonValidate.PointerExited += ButtonValidate_PointerExited;
            this.ChoosePNJView.ItemsListPnjs.ItemClick += ItemsListPnjs_ItemClick;
        }

        private void ButtonValidate_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(ChooseNameView));
        }

        private void ButtonValidate_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ChoosePNJView.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonValidate_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ChoosePNJView.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ItemsListPnjs_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ChoosePNJView.Console.DisplayedMessage = "Regarde mes pokémons et clique sur VALIDER.";
        }

        private void ButtonBack_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ChoosePNJView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBack_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ChoosePNJView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBack_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPageView));
        }
    }
}
