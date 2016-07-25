using ClassLibraryEntity;
using ClassLibraryEntity.API;
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
using Windows.UI.Xaml.Input;

namespace Pokemon.ViewModels
{
    public class BattleViewModel
    {
        private BattleView battleView;
        private PersonnageNonJoueur opponentPersonnageNonJoueur;
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
        public PersonnageNonJoueur OpponentPersonnageNonJoueur
        {
            get
            {
                return opponentPersonnageNonJoueur;
            }

            set
            {
                opponentPersonnageNonJoueur = value;
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

        private void Init()
        {
            // Generate utils objects
            Profession profession = new Profession(1, "Champion");
            TypeAttaque typeAttaqueEau = new TypeAttaque(1, "Eau");
            TypeAttaque typeAttaqueFeu = new TypeAttaque(2, "Feu");
            TypeAttaque typeAttaqueTerre = new TypeAttaque(3, "Terre");
            TypeAttaque typeAttaqueAir = new TypeAttaque(4, "Air");
            // Generate Opponent
            TypeDePokemon typeDePokemonBulbi = new TypeDePokemon(1, "Bulbizarre", 25, 18, 100, 1, "");
            Attaque attaqueBulbi1 = new Attaque(1, "Attaque1Eau", 1, 25, typeAttaqueEau);
            Attaque attaqueBulbi2 = new Attaque(2, "Attaque2Feu", 1, 18, typeAttaqueFeu);
            Attaque attaqueBulbi3 = new Attaque(3, "Attaque3Terre", 1, 15, typeAttaqueTerre);
            Attaque attaqueBulbi4 = new Attaque(4, "Attaque4Air", 1, 16, typeAttaqueAir);
            this.OpponentPersonnageNonJoueur = new PersonnageNonJoueur(1, "MechantMonsieur", "Méchant Descrip", profession);
            ClassLibraryEntity.Pokemon pokemonOpponent = new ClassLibraryEntity.Pokemon(1, "Bulbi", 5, DateTime.Now, typeDePokemonBulbi, this.OpponentPersonnageNonJoueur, attaqueBulbi1, attaqueBulbi2, attaqueBulbi3, attaqueBulbi4);

            this.BattleView.OpponentView.Pokemon = pokemonOpponent;
            this.BattleView.OpponentView.MaximumPv = pokemonOpponent.TypeDePokemon.Pv;
            this.BattleView.OpponentView.ActualPv = (pokemonOpponent.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;

            this.BattleView.PokemonSelectionMenu.LoadItems(this.GridManager.PersonnageNonJoueur.Pokemons);
            // Get the list of TypeObjet from Objets owned by the PersonnageNonJoueur
            List<TypeObjet> typesObjets = new List<TypeObjet>();
            TypeObjet currentTypeObjet = new TypeObjet();
            currentTypeObjet.Id = 0;

            for (int i = 0; i < this.GridManager.PersonnageNonJoueur.Objets.Count - 1; i++)
            {
                if (this.GridManager.PersonnageNonJoueur.Objets[i].TypeObjet.Id != currentTypeObjet.Id)
                {
                    typesObjets.Add(this.GridManager.PersonnageNonJoueur.Objets[i].TypeObjet);
                }
                currentTypeObjet = this.GridManager.PersonnageNonJoueur.Objets[i].TypeObjet;
            }
            this.BattleView.CategoryObjectMenu.LoadItems(typesObjets);
        }
                
        private void Bind()
        {
            this.BattleView.BattleMenu.ButtonPokemon.Tapped += this.PokemonButton_Tapped;
            this.BattleView.BattleMenu.ButtonPokemon.PointerEntered += ButtonPokemon_PointerEntered;
            this.BattleView.BattleMenu.ButtonPokemon.PointerExited += ButtonPokemon_PointerExited;

            this.BattleView.BattleMenu.ButtonTypeObjet.Tapped += TypeObjetButton_Tapped;
            this.BattleView.BattleMenu.ButtonTypeObjet.PointerEntered += ButtonTypeObjet_PointerEntered;
            this.BattleView.BattleMenu.ButtonTypeObjet.PointerExited += ButtonTypeObjet_PointerExited;

            this.BattleView.PokemonSelectionMenu.ItemsListPokemons.ItemClick += ItemsListPokemons_ItemClick;
            this.BattleView.PokemonSelectionMenu.ButtonBack.Tapped += ButtonBackPokemonSelectionMenu_Tapped;
            this.BattleView.PokemonSelectionMenu.ButtonBack.PointerEntered += ButtonBackPokemonSelectionMenu_PointerEntered;
            this.BattleView.PokemonSelectionMenu.ButtonBack.PointerExited += ButtonBackPokemonSelectionMenu_PointerExited;

            this.BattleView.CategoryObjectMenu.ItemsListTypesObjets.ItemClick += ItemsListTypesObjets_ItemClick;
            this.BattleView.CategoryObjectMenu.ButtonBack.Tapped += ButtonBackCategoryObjectMenu_Tapped;
            this.BattleView.CategoryObjectMenu.ButtonBack.PointerEntered += ButtonBackCategoryObjectMenu_PointerEntered;
            this.BattleView.CategoryObjectMenu.ButtonBack.PointerExited += ButtonBackCategoryObjectMenu_PointerExited;

            this.BattleView.ObjectMenu.ButtonBack.Tapped += ButtonBackObjectMenu_Tapped;
            this.BattleView.ObjectMenu.ButtonBack.PointerEntered += ButtonBackObjectMenu_PointerEntered;
            this.BattleView.ObjectMenu.ButtonBack.PointerExited += ButtonBackObjectMenu_PointerExited;

            this.BattleView.BattleMenu.ButtonRunaway.Tapped += this.RunawayButton_Tapped;
            this.BattleView.BattleMenu.ButtonRunaway.PointerEntered += ButtonRunaway_PointerEntered;
            this.BattleView.BattleMenu.ButtonRunaway.PointerExited += ButtonRunaway_PointerExited;

            this.BattleView.AttackMenu.ButtonBack.Tapped += ButtonBackAttackMenu_Tapped;
            this.BattleView.AttackMenu.ButtonBack.PointerEntered += ButtonBackAttackMenu_PointerEntered;
            this.BattleView.AttackMenu.ButtonBack.PointerExited += ButtonBackAttackMenu_PointerExited;

            this.BattleView.AttackMenu.AttackButton1.Tapped += AttackButton1_Tapped;
            this.BattleView.AttackMenu.AttackButton1.PointerEntered += AttackButton1_PointerEntered;
            this.BattleView.AttackMenu.AttackButton1.PointerExited += AttackButton1_PointerExited;
            this.BattleView.AttackMenu.AttackButton2.Tapped += AttackButton2_Tapped;
            this.BattleView.AttackMenu.AttackButton2.PointerEntered += AttackButton2_PointerEntered;
            this.BattleView.AttackMenu.AttackButton2.PointerExited += AttackButton2_PointerExited;
            this.BattleView.AttackMenu.AttackButton3.Tapped += AttackButton3_Tapped;
            this.BattleView.AttackMenu.AttackButton3.PointerEntered += AttackButton3_PointerEntered;
            this.BattleView.AttackMenu.AttackButton3.PointerExited += AttackButton3_PointerExited;
            this.BattleView.AttackMenu.AttackButton4.Tapped += AttackButton4_Tapped;
            this.BattleView.AttackMenu.AttackButton4.PointerEntered += AttackButton4_PointerEntered;
            this.BattleView.AttackMenu.AttackButton4.PointerExited += AttackButton4_PointerExited;
        }

        private void AttackButton1_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton1.Style = (Style)Application.Current.Resources["AttackButton"];
        }

        private void AttackButton1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton1.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void AttackButton1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Launch Attack01 against the opponent
            // Get actual PV 
            double actualPv = (this.BattleView.OpponentView.ActualPv * 100) / this.BattleView.OpponentView.MaximumPv;
            actualPv = actualPv - this.BattleView.AttackMenu.Attaque01.Puissance * this.BattleView.AttackMenu.Attaque01.Degats;
            ClassLibraryEntity.Pokemon pokemonOpponent = this.BattleView.OpponentView.Pokemon;
            pokemonOpponent.TypeDePokemon.Pv = (int)actualPv;
            this.BattleView.OpponentView.Pokemon = pokemonOpponent;
            this.BattleView.OpponentView.ActualPv = (actualPv / this.BattleView.OpponentView.MaximumPv) * 100;
        }

        private void AttackButton2_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton2.Style = (Style)Application.Current.Resources["AttackButton"];
        }

        private void AttackButton2_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton2.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void AttackButton2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Launch Attack02 against the opponent
            // Get actual PV 
            double actualPv = (this.BattleView.OpponentView.ActualPv * 100) / this.BattleView.OpponentView.MaximumPv;
            actualPv = actualPv - this.BattleView.AttackMenu.Attaque02.Puissance * this.BattleView.AttackMenu.Attaque02.Degats;
            ClassLibraryEntity.Pokemon pokemonOpponent = this.BattleView.OpponentView.Pokemon;
            pokemonOpponent.TypeDePokemon.Pv = (int)actualPv;
            this.BattleView.OpponentView.Pokemon = pokemonOpponent;
            this.BattleView.OpponentView.ActualPv = (actualPv / this.BattleView.OpponentView.MaximumPv) * 100;
        }

        private void AttackButton3_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton3.Style = (Style)Application.Current.Resources["AttackButton"];
        }

        private void AttackButton3_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton3.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void AttackButton3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Launch Attack03 against the opponent
            // Get actual PV 
            double actualPv = (this.BattleView.OpponentView.ActualPv * 100) / this.BattleView.OpponentView.MaximumPv;
            actualPv = actualPv - this.BattleView.AttackMenu.Attaque03.Puissance * this.BattleView.AttackMenu.Attaque03.Degats;
            ClassLibraryEntity.Pokemon pokemonOpponent = this.BattleView.OpponentView.Pokemon;
            pokemonOpponent.TypeDePokemon.Pv = (int)actualPv;
            this.BattleView.OpponentView.Pokemon = pokemonOpponent;
            this.BattleView.OpponentView.ActualPv = (actualPv / this.BattleView.OpponentView.MaximumPv) * 100;
        }

        private void AttackButton4_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton4.Style = (Style)Application.Current.Resources["AttackButton"];
        }

        private void AttackButton4_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.AttackButton4.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void AttackButton4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Launch Attack04 against the opponent
            // Get actual PV 
            double actualPv = (this.BattleView.OpponentView.ActualPv * 100) / this.BattleView.OpponentView.MaximumPv;
            actualPv = actualPv - this.BattleView.AttackMenu.Attaque04.Puissance * this.BattleView.AttackMenu.Attaque04.Degats;
            ClassLibraryEntity.Pokemon pokemonOpponent = this.BattleView.OpponentView.Pokemon;
            pokemonOpponent.TypeDePokemon.Pv = (int)actualPv;
            this.BattleView.OpponentView.Pokemon = pokemonOpponent;
            this.BattleView.OpponentView.ActualPv = (actualPv / this.BattleView.OpponentView.MaximumPv) * 100;
        }

        private void ButtonBackAttackMenu_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBackAttackMenu_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBackAttackMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonBackObjectMenu_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.ObjectMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBackObjectMenu_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.ObjectMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBackObjectMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (ObjectMenu item in Helper.FindVisualChildren<ObjectMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonBackPokemonSelectionMenu_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.PokemonSelectionMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBackPokemonSelectionMenu_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.PokemonSelectionMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }
        
        private void ButtonBackPokemonSelectionMenu_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            foreach (PokemonSelectionMenu item in Helper.FindVisualChildren<PokemonSelectionMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonBackCategoryObjectMenu_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.CategoryObjectMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBackCategoryObjectMenu_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.CategoryObjectMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBackCategoryObjectMenu_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            foreach (CategoryObjectMenu item in Helper.FindVisualChildren<CategoryObjectMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonRunaway_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.BattleMenu.ButtonRunaway.Style = (Style)Application.Current.Resources["RunawayButton"];
        }

        private void ButtonRunaway_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.BattleMenu.ButtonRunaway.Style = (Style)Application.Current.Resources["RunawayButtonSelected"];
        }

        private void ButtonTypeObjet_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.BattleMenu.ButtonTypeObjet.Style = (Style)Application.Current.Resources["ObjectButton"];
        }

        private void ButtonTypeObjet_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.BattleMenu.ButtonTypeObjet.Style = (Style)Application.Current.Resources["ObjectButtonSelected"];
        }

        private void ButtonPokemon_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.BattleMenu.ButtonPokemon.Style = (Style)Application.Current.Resources["PokemonButton"];
        }

        private void ButtonPokemon_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.BattleView.BattleMenu.ButtonPokemon.Style = (Style)Application.Current.Resources["PokemonButtonSelected"];
        }

        private void ItemsListTypesObjets_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (ObjectMenu item in Helper.FindVisualChildren<ObjectMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            ClassLibraryEntity.TypeObjet selectedTypeObjet = e.ClickedItem as ClassLibraryEntity.TypeObjet;
            this.BattleView.ObjectMenu.LoadItems(this.GridManager.PersonnageNonJoueur.Objets.Where((x) => x.TypeObjet.Id == selectedTypeObjet.Id).ToList());
        }

        private void ItemsListPokemons_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            ClassLibraryEntity.Pokemon selectedPokemon = e.ClickedItem as ClassLibraryEntity.Pokemon;
            this.BattleView.AttackMenu.Attaque01 = selectedPokemon.Attaque1;
            this.BattleView.AttackMenu.Attaque02 = selectedPokemon.Attaque2;
            this.BattleView.AttackMenu.Attaque03 = selectedPokemon.Attaque3;
            this.BattleView.AttackMenu.Attaque04 = selectedPokemon.Attaque4;
            // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
            this.BattleView.PlayerView.Pokemon = selectedPokemon;
            this.BattleView.PlayerView.MaximumPv = selectedPokemon.TypeDePokemon.Pv;
            this.BattleView.PlayerView.ActualPv = (selectedPokemon.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
        }
                        
        private void RunawayButton_Tapped(object sender, RoutedEventArgs e)
        {
            this.GridManager.Player.PosY++;
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
        }

        private void PokemonButton_Tapped(object sender, RoutedEventArgs e)
        {
            foreach (PokemonSelectionMenu item in Helper.FindVisualChildren<PokemonSelectionMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void TypeObjetButton_Tapped(object sender, RoutedEventArgs e)
        {
            foreach (CategoryObjectMenu item in Helper.FindVisualChildren<CategoryObjectMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }
    }
}
