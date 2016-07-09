using ClassLibraryEntity;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokemon.Pages.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PokedexView : Page
    {
        private GridManager gridManager;
        private ObservableCollection<ClassLibraryEntity.Pokemon> pokemons = new ObservableCollection<ClassLibraryEntity.Pokemon>();        

        public PokedexView()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListPokemon.ItemsSource = this.Pokemons;
        }

        private void LoadContent()
        {

            TypePokemon typePokemonEau = new TypePokemon("Eau");
            TypePokemon typePokemonFeu = new TypePokemon("Feu");
            ClassLibraryEntity.Pokemon kaiminus = new ClassLibraryEntity.Pokemon("Kaiminus", "KAIMINUS : &#xD;&#xA;&#xD;&#xA; Même s'il est tout petit, la mâchoire de Kaiminus est très " +
                "puissante. En pleine croissance, il a un fort besoin de mordiller tout ce qu'il trouve : cailloux, morceaux de bois, et même la main de son " +
                "dresseur si celui-ci est imprudent. Ce Pokémon ne se rend pas compte de la force de ses morsures, il faut donc s'en méfier. ", 
                "ms-appx:///Images/Pokemons/kaiminus.png", 6, typePokemonEau);
            ClassLibraryEntity.Pokemon hericendre = new ClassLibraryEntity.Pokemon("Héricendre", "Description Héricendre", "ms-appx:///Images/Pokemons/hericendre.png", 6, typePokemonFeu);

            pokemons.Add(kaiminus);
            pokemons.Add(hericendre);
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.GridManager = (GridManager)e.Parameter;
        }

        private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
        }
        
        internal GridManager GridManager
        {
            get
            {
                return gridManager;
            }

            set
            {
                gridManager = value;
            }
        }

        internal ObservableCollection<ClassLibraryEntity.Pokemon> Pokemons
        {
            get
            {
                return pokemons;
            }
        }
    }
}
