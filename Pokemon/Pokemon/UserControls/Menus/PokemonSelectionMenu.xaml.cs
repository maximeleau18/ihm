using Pokemon.Entity;
using Pokemon.UserControls.Buttons;
using Pokemon.UserControls.Other;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class PokemonSelectionMenu : UserControl
    {
        private ObservableCollection<Entity.Pokemon> pokemons = new ObservableCollection<Entity.Pokemon>();
        
        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;
        }
        internal ObservableCollection<Entity.Pokemon> Pokemons
        {
            get
            {
                return pokemons;
            }
        }

        public PokemonSelectionMenu()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListPokemon.ItemsSource = this.Pokemons;
        }

        private void LoadContent()
        {

            TypePokemon typePokemonEau = new TypePokemon("Eau");
            TypePokemon typePokemonFeu = new TypePokemon("Feu");
            Entity.Pokemon kaiminus = new Entity.Pokemon("Kaiminus", "Description Kaiminus", "ms-appx:///Images/Pokemons/kaiminus.png", 6, typePokemonEau);
            //Entity.Pokemon hericendre = new Entity.Pokemon("Héricendre", "Description Héricendre", "ms-appx:///Images/Pokemons/hericendre.png", 6, typePokemonFeu);

            pokemons.Add(kaiminus);
            //pokemons.Add(hericendre);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myConsole.setMessageBattleMenuText();
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
