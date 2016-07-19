using ClassLibraryEntity;
using Pokemon.Pages.Views;
using Pokemon.UserControls.Menus;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokemon.ViewModels
{
    public class BattleViewModel
    {
        private BattleView battleView;
        private PersonnageNonJoueur personnageNonJoueur;
        private GridManager gridManager;

        public BattleView BattleView
        {
            get
            {
                return battleView;
            }

            set
            {
                battleView = value;
            }
        }
        public PersonnageNonJoueur PersonnageNonJoueur
        {
            get
            {
                return personnageNonJoueur;
            }

            set
            {
                personnageNonJoueur = value;
            }
        }
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

        public BattleViewModel(BattleView battleView)
        {
            this.BattleView = battleView;
            this.GridManager = this.BattleView.GridManager;
            this.Init();
            this.Bind();
        }

        public void Init()
        {
            // Get pokemons of pnj from API
            //this.BattleView.PokemonSelectionMenu.LoadItems(myPokemons);
            // Get types objets of pnj from API
            //this.BattleView.CategoryObjectMenu.LoadItems(myTypesObjets);

        }

        public void Bind()
        {
            this.BattleView.PokemonSelectionMenu.ItemsListPokemons.SelectionChanged += this.ItemListPokemons_SelectionChanged;
            this.BattleView.CategoryObjectMenu.ItemsListTypesObjets.SelectionChanged += this.ItemListTypesObjets_SelectionChanged;
            this.BattleView.BattleMenu.RunawayButtonTapped += this.RunawayButton_Tapped;
        }

        private void ItemListPokemons_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.BattleView.Parent as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
                item.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            ClassLibraryEntity.Pokemon selectedPokemon = e.AddedItems[0] as ClassLibraryEntity.Pokemon;
            this.BattleView.AttackMenu.AttackButton1.Attaque = selectedPokemon.Attaque1;
            this.BattleView.AttackMenu.AttackButton2.Attaque = selectedPokemon.Attaque2;
            this.BattleView.AttackMenu.AttackButton3.Attaque = selectedPokemon.Attaque3;
            this.BattleView.AttackMenu.AttackButton4.Attaque = selectedPokemon.Attaque4;
        }

        private void ItemListTypesObjets_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.BattleView.Parent as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
                item.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            ClassLibraryEntity.TypeObjet selectedTypeObjet = e.AddedItems[0] as ClassLibraryEntity.TypeObjet;
            // Get objets of type objet of pnj from API
            //this.BattleView.ObjectMenu.LoadItems(myObjets);
        }

        private void RunawayButton_Tapped(object sender, RoutedEventArgs e)
        {
            this.GridManager.Player.PosY++;
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
        }
    }
}
