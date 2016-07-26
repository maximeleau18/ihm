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
        private PersonnageNonJoueur pnj;
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
        public PersonnageNonJoueur Pnj
        {
            get
            {
                return pnj;
            }

            set
            {
                pnj = value;
            }
        }

        public ChoosePNJViewModel(ChoosePNJView choosePNJView)
        {
            this.ChoosePNJView = choosePNJView;
            this.ChoosePNJView.Console.DisplayedMessage = "Choisi un personnage dans la liste de droite.";
            this.ChoosePNJView.SelectedPnj = Visibility.Collapsed;
            this.Init();
            this.Bind();
        }
        
        private async void Init()
        {
            ClassLibraryEntity.API.ApiManager manager = new ClassLibraryEntity.API.ApiManager();
            this.ChoosePNJView.MainGrid.Visibility = Visibility.Collapsed;
            this.ChoosePNJView.RingLoader.ProgressRingText.Text = "Chargement...";
            this.ChoosePNJView.RingLoader.Visibility = Visibility.Visible;
            this.ChoosePNJView.LoadItems(await manager.GetListFromApi<List<PersonnageNonJoueur>>());
            this.ChoosePNJView.RingLoader.Visibility = Visibility.Collapsed;
            this.ChoosePNJView.MainGrid.Visibility = Visibility.Visible;
        }

        private void Bind()
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
            (Window.Current.Content as Frame).Navigate(typeof(CompleteDresseurView), this.Pnj);
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
            PersonnageNonJoueur pnjSelected = e.ClickedItem as PersonnageNonJoueur;
            this.Pnj = pnjSelected;
            this.ChoosePNJView.Console.DisplayedMessage = "Regarde les pokémons de \"" + pnjSelected.Nom + "\" dans la liste de droite puis clique sur VALIDER.";
            this.ChoosePNJView.SelectedPnj = Visibility.Visible;
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
