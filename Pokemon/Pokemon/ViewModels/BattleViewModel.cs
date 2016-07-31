using ClassLibraryEntity;
using ClassLibraryEntity.API;
using Microsoft.Azure.Engagement;
using Newtonsoft.Json;
using Pokemon.Pages.Views;
using Pokemon.UserControls.Menus;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
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
        private CombatManager combatManager;
        private ClassLibraryEntity.Pokemon selectedPokemon;

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
        public ClassLibraryEntity.Pokemon SelectedPokemon
        {
            get
            {
                return selectedPokemon;
            }

            set
            {
                selectedPokemon = value;
            }
        }
        public CombatManager CombatManager
        {
            get
            {
                return combatManager;
            }

            set
            {
                combatManager = value;
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
            this.BattleView.PokemonSelectionMenu.LoadItems(this.GridManager.Dresseur.PersonnageNonJoueur.Pokemons);
            // Get the list of TypeObjet from Objets owned by the PersonnageNonJoueur
            List<TypeObjet> typesObjets = new List<TypeObjet>();
            TypeObjet currentTypeObjet = new TypeObjet();
            currentTypeObjet.Id = 0;

            for (int i = 0; i < this.GridManager.Dresseur.PersonnageNonJoueur.Objets.Count - 1; i++)
            {
                if (this.GridManager.Dresseur.PersonnageNonJoueur.Objets[i].TypeObjet.Id != currentTypeObjet.Id)
                {
                    typesObjets.Add(this.GridManager.Dresseur.PersonnageNonJoueur.Objets[i].TypeObjet);
                }
                currentTypeObjet = this.GridManager.Dresseur.PersonnageNonJoueur.Objets[i].TypeObjet;
            }
            this.BattleView.CategoryObjectMenu.LoadItems(typesObjets);
        }
                
        private void Bind()
        {
            this.BattleView.BattleMenu.ButtonPokemon.Tapped += PokemonButton_Tapped;
            this.BattleView.BattleMenu.ButtonPokemon.PointerEntered += ButtonPokemon_PointerEntered;
            this.BattleView.BattleMenu.ButtonPokemon.PointerExited += ButtonPokemon_PointerExited;

            this.BattleView.BattleMenu.ButtonTypeObjet.Tapped += TypeObjetButton_Tapped;
            this.BattleView.BattleMenu.ButtonTypeObjet.PointerEntered += ButtonTypeObjet_PointerEntered;
            this.BattleView.BattleMenu.ButtonTypeObjet.PointerExited += ButtonTypeObjet_PointerExited;

            this.BattleView.PokemonSelectionMenu.ItemsListPokemons.ItemClick += ItemsListPokemons_ItemClick;
            this.BattleView.PokemonSelectionMenu.ButtonValidate.Tapped += ButtonValidatePokemonSelectionMenu_Tapped;
            this.BattleView.PokemonSelectionMenu.ButtonValidate.PointerEntered += ButtonValidatePokemonSelectionMenu_PointerEntered;
            this.BattleView.PokemonSelectionMenu.ButtonValidate.PointerExited += ButtonValidatePokemonSelectionMenu_PointerExited;
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

            this.BattleView.BattleMenu.ButtonRunaway.Tapped += RunawayButton_Tapped;
            this.BattleView.BattleMenu.ButtonRunaway.PointerEntered += ButtonRunaway_PointerEntered;
            this.BattleView.BattleMenu.ButtonRunaway.PointerExited += ButtonRunaway_PointerExited;

            this.BattleView.AttackMenu.ButtonBack.Tapped += ButtonBackAttackMenu_Tapped;
            this.BattleView.AttackMenu.ButtonBack.PointerEntered += ButtonBackAttackMenu_PointerEntered;
            this.BattleView.AttackMenu.ButtonBack.PointerExited += ButtonBackAttackMenu_PointerExited;

            this.BattleView.AttackMenu.AttackButton1.Tapped += AttackButton1_Tapped;
            this.BattleView.AttackMenu.AttackButton1.PointerEntered += AttackButton1_PointerEntered;
            this.BattleView.AttackMenu.AttackButton1.PointerExited += AttackButton1_PointerExited;
            this.BattleView.AttackMenu.AttackButton1.IsEnabledChanged += AttackButton1_IsEnabledChanged;
            this.BattleView.AttackMenu.AttackButton2.Tapped += AttackButton2_Tapped;
            this.BattleView.AttackMenu.AttackButton2.PointerEntered += AttackButton2_PointerEntered;
            this.BattleView.AttackMenu.AttackButton2.PointerExited += AttackButton2_PointerExited;
            this.BattleView.AttackMenu.AttackButton2.IsEnabledChanged += AttackButton2_IsEnabledChanged;
            this.BattleView.AttackMenu.AttackButton3.Tapped += AttackButton3_Tapped;
            this.BattleView.AttackMenu.AttackButton3.PointerEntered += AttackButton3_PointerEntered;
            this.BattleView.AttackMenu.AttackButton3.PointerExited += AttackButton3_PointerExited;
            this.BattleView.AttackMenu.AttackButton3.IsEnabledChanged += AttackButton3_IsEnabledChanged;
            this.BattleView.AttackMenu.AttackButton4.Tapped += AttackButton4_Tapped;
            this.BattleView.AttackMenu.AttackButton4.PointerEntered += AttackButton4_PointerEntered;
            this.BattleView.AttackMenu.AttackButton4.PointerExited += AttackButton4_PointerExited;
            this.BattleView.AttackMenu.AttackButton4.IsEnabledChanged += AttackButton4_IsEnabledChanged;
        }

        private void AttackButton4_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.BattleView.AttackMenu.AttackButton4.IsEnabled)
            {
                this.BattleView.AttackMenu.AttackButton4.Style = (Style)Application.Current.Resources["AttackButton"];
            }
            else
            {
                this.BattleView.AttackMenu.AttackButton4.Style = (Style)Application.Current.Resources["AttackButtonDisable"];
            }
        }

        private void AttackButton3_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.BattleView.AttackMenu.AttackButton3.IsEnabled)
            {
                this.BattleView.AttackMenu.AttackButton3.Style = (Style)Application.Current.Resources["AttackButton"];
            }
            else
            {
                this.BattleView.AttackMenu.AttackButton3.Style = (Style)Application.Current.Resources["AttackButtonDisable"];
            }
        }

        private void AttackButton2_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.BattleView.AttackMenu.AttackButton2.IsEnabled)
            {
                this.BattleView.AttackMenu.AttackButton2.Style = (Style)Application.Current.Resources["AttackButton"];
            }
            else
            {
                this.BattleView.AttackMenu.AttackButton2.Style = (Style)Application.Current.Resources["AttackButtonDisable"];
            }
        }

        private void AttackButton1_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.BattleView.AttackMenu.AttackButton1.IsEnabled)
            {
                this.BattleView.AttackMenu.AttackButton1.Style = (Style)Application.Current.Resources["AttackButton"];
            }
            else
            {
                this.BattleView.AttackMenu.AttackButton1.Style = (Style)Application.Current.Resources["AttackButtonDisable"];
            }
        }

        private async void ButtonValidatePokemonSelectionMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Display the ing loader
            this.BattleView.RingLoader.Visibility = Visibility.Visible;
            this.BattleView.RingLoader.ProgressRingText.Text = "Recherche un adversaire";
            this.BattleView.GridBattleView.Visibility = Visibility.Collapsed;
            // Create a fight
            this.CombatManager = new CombatManager();

            this.CombatManager.Combat = await this.CombatManager.StartNewFight(this.GridManager.Dresseur, this.SelectedPokemon);
            //this.CombatManager.Combat = await this.CombatManager.WaitingForDressseur2(this.CombatManager.Combat);
            
            if (this.CombatManager.Combat.Dresseur2 == null)
            {
                MessageDialog dialog = new MessageDialog("Aucun adversaire n'a été trouvé...");
                dialog.Title = "Oups";
                await dialog.ShowAsync();

                // Delete the fight and the campaign
                await this.CombatManager.DeleteFight(this.CombatManager.Combat);
                
                this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                this.BattleView.GridBattleView.Visibility = Visibility.Visible;
            }
            else
            {
                this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                this.BattleView.RingLoader.ProgressRingText.Text = "Recherche un adversaire";
                this.BattleView.GridBattleView.Visibility = Visibility.Visible;

                // Display pokmeons's attacks
                foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
                {
                    item.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                this.BattleView.AttackMenu.Attaque01 = this.CombatManager.Combat.Pokemon1.Attaque1;
                this.BattleView.AttackMenu.Attaque02 = this.CombatManager.Combat.Pokemon1.Attaque2;
                this.BattleView.AttackMenu.Attaque03 = this.CombatManager.Combat.Pokemon1.Attaque3;
                this.BattleView.AttackMenu.Attaque04 = this.CombatManager.Combat.Pokemon1.Attaque4;
                // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon1;
                this.BattleView.PlayerView.MaximumPv = this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv;
                this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                // Binding opponent Pokemon to usercontrol PokemonBattleDisplayOpponent when datapush received

            }
        }

        private void ButtonValidatePokemonSelectionMenu_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.PokemonSelectionMenu.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonValidatePokemonSelectionMenu_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.PokemonSelectionMenu.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
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
            this.CombatManager.Pokemon = this.CombatManager.Combat.Pokemon2;
            this.CombatManager.ActualPvPokemon = this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv;
            this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque01;
            this.BattleView.Console.DisplayedMessage = this.CombatManager.Combat.Pokemon1.TypeDePokemon.Nom + " attaque " +
                                                            this.CombatManager.Attaque.Nom;
            // Disable attack buttons
            this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;

            this.CombatManager.LaunchAttackAgainstOpponent(this.CombatManager);
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
            this.CombatManager.Pokemon = this.CombatManager.Combat.Pokemon2;
            this.CombatManager.ActualPvPokemon = this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv;
            this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque02;
            this.BattleView.Console.DisplayedMessage = this.CombatManager.Combat.Pokemon1.TypeDePokemon.Nom + " attaque " +
                                                            this.CombatManager.Attaque.Nom;
            // Disable attack buttons
            this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;

            this.CombatManager.LaunchAttackAgainstOpponent(this.CombatManager);
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
            this.CombatManager.Pokemon = this.CombatManager.Combat.Pokemon2;
            this.CombatManager.ActualPvPokemon = this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv;
            this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque03;
            this.BattleView.Console.DisplayedMessage = this.CombatManager.Combat.Pokemon1.TypeDePokemon.Nom + " attaque " +
                                                            this.CombatManager.Attaque.Nom;
            // Disable attack buttons
            this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;

            this.CombatManager.LaunchAttackAgainstOpponent(this.CombatManager);
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
            this.CombatManager.Pokemon = this.CombatManager.Combat.Pokemon2;
            this.CombatManager.ActualPvPokemon = this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv;
            this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque04;
            this.BattleView.Console.DisplayedMessage = this.CombatManager.Combat.Pokemon1.TypeDePokemon.Nom + " attaque " +
                                                            this.CombatManager.Attaque.Nom;
            // Disable attack buttons
            this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
            this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;

            this.CombatManager.LaunchAttackAgainstOpponent(this.CombatManager);
        }

        private void ButtonBackAttackMenu_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBackAttackMenu_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.BattleView.AttackMenu.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private async void ButtonBackAttackMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
            //{
            //    item.Visibility = Visibility.Collapsed;
            //}
            MessageDialog dialog = new MessageDialog("Voulez-vous vraiment abandonner le combat ? Vous serez considéré comme perdant.");
            dialog.Title = "Confirmation";
            dialog.Commands.Add(new UICommand { Label = "Oui", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Non", Id = 1 });
            dialog.Commands.Add(new UICommand { Label = "Annuler", Id = 2 });

            var res = await dialog.ShowAsync();

            switch ((Int32)res.Id)
            {
                case 0:
                    // Update the combat and finish the campaign
                    if (this.CombatManager.Combat.Dresseur1.Id == this.GridManager.Dresseur.Id)
                    {
                        this.CombatManager.Combat.Dresseur2Vainqueur = true;
                        this.CombatManager.Combat.Pokemon2Vainqueur = true;
                    }
                    else
                    {
                        this.CombatManager.Combat.Dresseur1Vainqueur = true;
                        this.CombatManager.Combat.Pokemon1Vainqueur = true;
                    }

                    // Update the fight
                    await this.CombatManager.FinishFight(this.CombatManager.Combat);

                    this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                    this.BattleView.GridBattleView.Visibility = Visibility.Visible;

                    (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
                    break;
                case 1:
                    // Still in the fight view
                    break;
                case 2:
                    // Do nothing
                    break;
                default:
                    break;
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
            this.BattleView.ObjectMenu.LoadItems(this.GridManager.Dresseur.PersonnageNonJoueur.Objets.Where((x) => x.TypeObjet.Id == selectedTypeObjet.Id).ToList());
        }

        private void ItemsListPokemons_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.SelectedPokemon = e.ClickedItem as ClassLibraryEntity.Pokemon;
        }
        
        private void RunawayButton_Tapped(object sender, RoutedEventArgs e)
        {                       
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

        public void ReceiveDataPush(CombatManager combatManager)
        {
            this.CombatManager = combatManager;

            // Waiting for dataPush alert that it is my turn
            while (this.CombatManager.PokemonActualTurnId != this.CombatManager.Combat.Pokemon1.Id) { }

            // Update the opponent view

            // Enable attack buttons
            this.BattleView.AttackMenu.AttackButton1.IsEnabled = true;
            this.BattleView.AttackMenu.AttackButton2.IsEnabled = true;
            this.BattleView.AttackMenu.AttackButton3.IsEnabled = true;
            this.BattleView.AttackMenu.AttackButton4.IsEnabled = true;
            // We only update the pokemon pv of the combat manager
            // because the pv are not set in database
            // in order to always have good value of pv when start new fight synchronously
            this.BattleView.OpponentView.MaximumPv = this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv;
            this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
            this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon2;
            this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
            this.BattleView.Console.DisplayedMessage = "A toi de jouer " + this.CombatManager.Combat.Dresseur1.Prenom + " " +
                            this.CombatManager.Combat.Dresseur1.Nom + "." + Environment.NewLine + "Choisi une attaque !";
        }
    }
}
