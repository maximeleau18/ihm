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
            this.ChoosePNJView.PnjPokemons.ItemsListPokemons.ItemClick += ItemsListPokemons_ItemClick;
        }

        private void ItemsListPokemons_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClassLibraryEntity.Pokemon selectedPokemon = e.ClickedItem as ClassLibraryEntity.Pokemon;
            this.ChoosePNJView.Console.DisplayedMessage = "Regarde les attaques de \"" + selectedPokemon.TypeDePokemon.Nom + "\" puis lorsque tu as choisi " +
                "clique sur VALIDER.";
            this.ChoosePNJView.PnjPokemonsAttacks.Visibility = Visibility.Visible;
            this.ChoosePNJView.PnjPokemonsAttacks.Attaque01 = selectedPokemon.Attaque1;
            this.ChoosePNJView.PnjPokemonsAttacks.Attaque02 = selectedPokemon.Attaque2;
            this.ChoosePNJView.PnjPokemonsAttacks.Attaque03 = selectedPokemon.Attaque3;
            this.ChoosePNJView.PnjPokemonsAttacks.Attaque04 = selectedPokemon.Attaque4;
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

        private async void ItemsListPnjs_ItemClick(object sender, ItemClickEventArgs e)
        {
            PersonnageNonJoueur pnjSelected = e.ClickedItem as PersonnageNonJoueur;
            ClassLibraryEntity.API.ApiManager manager = new ClassLibraryEntity.API.ApiManager();
            this.Pnj = await manager.GetFromApi<PersonnageNonJoueur>(pnjSelected.Id);
            this.ChoosePNJView.Console.DisplayedMessage = "Regarde les pokémons de \"" + pnjSelected.Nom + "\" dans la liste de droite puis clique sur VALIDER.";
            this.ChoosePNJView.SelectedPnj = Visibility.Visible;
            this.ChoosePNJView.PnjPokemons.LoadItems(this.Pnj.Pokemons);
            this.ChoosePNJView.PnjPokemonsAttacks.Visibility = Visibility.Collapsed;
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
