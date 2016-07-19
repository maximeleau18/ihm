using ClassLibraryEntity;
using Pokemon.UserControls;
using Pokemon.UserControls.Menus;
using Pokemon.UserControls.Other;
using Pokemon.UserControls.Views;
using Pokemon.Utils;
using Pokemon.ViewModels;
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
        private GridManager gridManager;
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
        private BattleViewModel battleViewModel;
        public BattleMenu BattleMenu { get; set; }
        public AttackMenu AttackMenu { get; set; }
        public PokemonSelectionMenu PokemonSelectionMenu { get; set; }
        public CategoryObjectMenu CategoryObjectMenu { get; set; }
        public ObjectMenu ObjectMenu { get; set; }
        public PokemonBattleDisplayOpponent OpponentView { get; set; }        
        public PokemonBattleDisplayPlayer PlayerView { get; set; }

        public BattleView()
        {
            this.InitializeComponent();

            this.BattleMenu = this.battleMenu;
            this.AttackMenu = this.attackMenu;
            this.PokemonSelectionMenu = this.pokemonSelectionMenu;
            this.CategoryObjectMenu = this.categoryObjectMenu;
            this.ObjectMenu = this.objectMenu;
            this.OpponentView = this.opponentView;
            this.PlayerView = this.playerView;

            this.battleViewModel = new BattleViewModel(this); 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.GridManager = (GridManager)e.Parameter;
        }
    }
}
