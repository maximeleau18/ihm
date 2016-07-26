using ClassLibraryEntity;
using Pokemon.Utils;
using Pokemon.ViewModels;
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
        private PokedexViewModel pokedexViewModel;
        private GridManager gridManager;
        private Button buttonBack;
        private ObservableCollection<ClassLibraryEntity.Pokemon> pokemons = new ObservableCollection<ClassLibraryEntity.Pokemon>();

        public GridManager GridManager
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
        public ObservableCollection<ClassLibraryEntity.Pokemon> Pokemons
        {
            get
            {
                return pokemons;
            }
        }
        public Button ButtonBack
        {
            get
            {
                return buttonBack;
            }

            set
            {
                buttonBack = value;
            }
        }

        public PokedexView()
        {
            this.InitializeComponent();
            this.ButtonBack = this.btnBack;
        }
                
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.GridManager = (GridManager)e.Parameter;
            this.pokedexViewModel = new PokedexViewModel(this);
        }
                
    }
}
