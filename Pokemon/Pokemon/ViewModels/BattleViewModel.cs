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

namespace Pokemon.ViewModels
{
    public class BattleViewModel
    {
        private BattleView battleView;
        private PersonnageNonJoueur personnageNonJoueur;
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
            this.InitApiData();
            this.Bind();
        }

        public void Init()
        {
            // Generate utils objects
            Profession profession = new Profession(1, "Champion");
            TypeAttaque typeAttaqueEau = new TypeAttaque(1, "Eau");
            TypeAttaque typeAttaqueFeu = new TypeAttaque(2, "Feu");
            TypeAttaque typeAttaqueTerre = new TypeAttaque(3, "Terre");
            TypeAttaque typeAttaqueAir = new TypeAttaque(4, "Air");
            // Generate Opponent
            TypeDePokemon typeDePokemonPikachu = new TypeDePokemon(1, "Pikachu", 25, 18, 100, 1, "");
            Attaque attaquePikachu1 = new Attaque(1, "Attaque1Eau", 1, 25, typeAttaqueEau);
            Attaque attaquePikachu2 = new Attaque(2, "Attaque2Feu", 1, 18, typeAttaqueFeu);
            Attaque attaquePikachu3 = new Attaque(3, "Attaque3Terre", 1, 15, typeAttaqueTerre);
            Attaque attaquePikachu4 = new Attaque(4, "Attaque4Air", 1, 16, typeAttaqueAir);
            this.OpponentPersonnageNonJoueur = new PersonnageNonJoueur(1, "MechantMonsieur", "Méchant Descrip", profession);
            ClassLibraryEntity.Pokemon pokemonOpponent = new ClassLibraryEntity.Pokemon(1, "Pikapika", 5, DateTime.Now, typeDePokemonPikachu, this.OpponentPersonnageNonJoueur, attaquePikachu1, attaquePikachu2, attaquePikachu3, attaquePikachu4);

            this.BattleView.OpponentView.Pokemon = pokemonOpponent;
            this.BattleView.OpponentView.ActualPv = pokemonOpponent.TypeDePokemon.Pv;
            //Generate Player
            //TypeDePokemon typeDePokemonBulbi = new TypeDePokemon(1, "Bulbizarre", 25, 18, 100, 1, "");
            //typeDePokemonBulbi.UrlImage = typeDePokemonBulbi.UrlImage.Split(';')[0];
            //Attaque attaqueBulbi1 = new Attaque(5, "Attaque5Terre", 1, 25, typeAttaqueTerre);
            //Attaque attaqueBulbi2 = new Attaque(6, "Attaque6Feu", 1, 18, typeAttaqueFeu);
            //Attaque attaqueBulbi3 = new Attaque(7, "Attaque7Eau", 1, 15, typeAttaqueEau);
            //Attaque attaqueBulbi4 = new Attaque(8, "Attaque8Air", 1, 16, typeAttaqueAir);
            //this.PersonnageNonJoueur = new PersonnageNonJoueur(2, "GentilMonsieur", "Gentil Descrip", profession);
            //ClassLibraryEntity.Pokemon pokemonPlayer = new ClassLibraryEntity.Pokemon(2, "Bulibi", 7, DateTime.Now, typeDePokemonBulbi, this.PersonnageNonJoueur, attaqueBulbi1, attaqueBulbi2, attaqueBulbi3, attaqueBulbi4);
            //List<ClassLibraryEntity.Pokemon> listPokemonPlayer = new List<ClassLibraryEntity.Pokemon>();
            //listPokemonPlayer.Add(pokemonPlayer);
            //TypeObjet typeObjetBalls = new TypeObjet(1, "Balls");
            //TypeObjet typeObjetStandards = new TypeObjet(2, "Standards");
            //List<TypeObjet> listTypeObjetPlayer = new List<TypeObjet>();
            //listTypeObjetPlayer.Add(typeObjetBalls);
            //listTypeObjetPlayer.Add(typeObjetStandards);

            //this.BattleView.PokemonSelectionMenu.LoadItems(listPokemonPlayer);
            //this.BattleView.CategoryObjectMenu.LoadItems(listTypeObjetPlayer);

            // Get pokemons of pnj from API

           //this.BattleView.PokemonSelectionMenu.LoadItems(myPokemons);
           // Get types objets of pnj from API
           // this.BattleView.CategoryObjectMenu.LoadItems(myTypesObjets);

        }
        
        public async void InitApiData()
        {
            ClassLibraryEntity.API.ApiManager apiManager = new ClassLibraryEntity.API.ApiManager();
            PersonnageNonJoueur pnj = await apiManager.GetFromApi<PersonnageNonJoueur>(1);
            this.BattleView.PokemonSelectionMenu.LoadItems(pnj.Pokemons);
        }


        public void Bind()
        {
            this.BattleView.BattleMenu.ButtonPokemon.Tapped += this.PokemonButton_Tapped;
            this.BattleView.BattleMenu.ButtonTypeObjet.Tapped += TypeObjetButton_Tapped;
            this.BattleView.PokemonSelectionMenu.ItemsListPokemons.ItemClick += ItemsListPokemons_ItemClick;
            this.BattleView.CategoryObjectMenu.ItemsListTypesObjets.ItemClick += ItemsListTypesObjets_ItemClick;
            this.BattleView.BattleMenu.ButtonRunaway.Tapped += this.RunawayButton_Tapped;
        }

        private void ItemsListTypesObjets_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (ObjectMenu item in Helper.FindVisualChildren<ObjectMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
                //item.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            ClassLibraryEntity.TypeObjet selectedTypeObjet = e.ClickedItem as ClassLibraryEntity.TypeObjet;
            Objet objetStandards1 = new Objet(1, "Fossile Nautile", 10, selectedTypeObjet, this.PersonnageNonJoueur);
            Objet objetStandards2 = new Objet(2, "Fossile Dôme", 10, selectedTypeObjet, this.PersonnageNonJoueur);

            List<Objet> listObjetStandards = new List<Objet>();

            listObjetStandards.Add(objetStandards1);
            listObjetStandards.Add(objetStandards2);
            this.BattleView.ObjectMenu.LoadItems(listObjetStandards);

            // Get objets of type objet of pnj from API
            //this.BattleView.ObjectMenu.LoadItems(myObjets);
        }

        private void ItemsListPokemons_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
            {
                item.Visibility = Windows.UI.Xaml.Visibility.Visible;
                //item.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            ClassLibraryEntity.Pokemon selectedPokemon = e.ClickedItem as ClassLibraryEntity.Pokemon;
            this.BattleView.AttackMenu.AttackButton1.Attaque = selectedPokemon.Attaque1;
            this.BattleView.AttackMenu.AttackButton2.Attaque = selectedPokemon.Attaque2;
            this.BattleView.AttackMenu.AttackButton3.Attaque = selectedPokemon.Attaque3;
            this.BattleView.AttackMenu.AttackButton4.Attaque = selectedPokemon.Attaque4;
            // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
            this.BattleView.PlayerView.Pokemon = selectedPokemon;
            this.BattleView.PlayerView.ActualPv = selectedPokemon.TypeDePokemon.Pv;
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
