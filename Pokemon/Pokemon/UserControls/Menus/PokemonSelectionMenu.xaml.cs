﻿using ClassLibraryEntity;
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
        private ObservableCollection<ClassLibraryEntity.Pokemon> pokemons;
        
        public ObservableCollection<ClassLibraryEntity.Pokemon> Pokemons
        {
            get
            {
                return pokemons;
            }
            set
            {
                pokemons = value;
            }
        }

        private ListView itemsListPokemons;

        public ListView ItemsListPokemons
        {
            get
            {
                return itemsListPokemons;
            }

            set
            {
                itemsListPokemons = value;
            }
        }

        public PokemonSelectionMenu()
        {
            this.InitializeComponent();
            this.pokemons = new ObservableCollection<ClassLibraryEntity.Pokemon>();
            this.listPokemon.ItemsSource = this.pokemons;
            this.ItemsListPokemons = this.listPokemon;
        }

        public void LoadItems(List<ClassLibraryEntity.Pokemon> pokemons)
        {
            this.pokemons.Clear();
            foreach (var item in pokemons)
            {
                this.pokemons.Add(item);
            }
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
