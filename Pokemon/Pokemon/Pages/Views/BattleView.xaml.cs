using ClassLibraryEntity;
using Pokemon.UserControls;
using Pokemon.UserControls.Other;
using System;
using System.Collections.Generic;
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
    public sealed partial class BattleView : Page
    {
        private Player player;

        public BattleView()
        {
            this.InitializeComponent();
            this.BattleMenu.RunawayButtonClick += new RoutedEventHandler(RunawayButton_Click);

            this.BattleMenu.setConsole(ref this.Console);
            this.AttackMenu.setConsole(ref this.Console);
            this.PokemonMenu.setConsole(ref this.Console);
            this.ObjectCategoryMenu.setConsole(ref this.Console);

            this.SelectedListViewPokeballs.setConsole(ref this.Console);
            this.SelectedListViewMedicaments.setConsole(ref this.Console);
            this.SelectedListViewCombats.setConsole(ref this.Console);
            this.SelectedListViewStatus.setConsole(ref this.Console);            
        }
        

        internal Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.Player = (Player)e.Parameter;
        }

        public void CreateNeededObjectsTemporary()
        {
            TypePokemon typePokemon = new TypePokemon("Eau");
            ClassLibraryEntity.Pokemon kaiminus = new ClassLibraryEntity.Pokemon("Kaiminus", "C'est un pokemon eau", "ms-appx:///Images/Pokemons/kaiminus.png", 6, typePokemon);

            this.Player.Team.Add(kaiminus);
        }
        
        private void RunawayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Player.PosY++;
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.Player);
        }

    }
}
