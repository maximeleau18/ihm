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

namespace Pokemon.UserControls.Pokemons
{
    public sealed partial class PnjPokemons : BaseUserControl
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

        public PnjPokemons()
        {
            this.InitializeComponent();
            this.Pokemons = new ObservableCollection<ClassLibraryEntity.Pokemon>();
            this.listPokemon.ItemsSource = this.Pokemons;
            this.ItemsListPokemons = this.listPokemon;
        }
        
        public void LoadItems(List<ClassLibraryEntity.Pokemon> pokemons)
        {
            this.Pokemons.Clear();
            foreach (var item in pokemons)
            {
                this.Pokemons.Add(item);
            }
        }
    }
}
