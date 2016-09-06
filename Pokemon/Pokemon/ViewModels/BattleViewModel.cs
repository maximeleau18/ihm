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

        private async void Init()
        {
            ApiManager manager = new ApiManager();
            PersonnageNonJoueur myPNJ = await manager.GetFromApi<PersonnageNonJoueur>(this.GridManager.Dresseur.PersonnageNonJoueur.Id);
            this.BattleView.PokemonSelectionMenu.LoadItems(myPNJ.Pokemons);
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
            if (this.SelectedPokemon == null)
            {
                MessageDialog dialog = new MessageDialog("Choisi un pokemon en cliquant dessus avant de lancer le combat !");
                dialog.Title = "Oups";
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Voulez-vous démarrer un nouveau combat ou en rechercher un ?");
                dialog.Title = "Confirmation";
                dialog.Commands.Add(new UICommand { Label = "Démarrer", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Rejoindre", Id = 1 });
                dialog.Commands.Add(new UICommand { Label = "Annuler", Id = 2 });

                var res = await dialog.ShowAsync();

                switch ((Int32)res.Id)
                {
                    case 0:
                        // Start new fight
                        // Display the ring loader
                        this.BattleView.RingLoader.Visibility = Visibility.Visible;
                        this.BattleView.RingLoader.ProgressRingText.Text = "Recherche un adversaire";
                        this.BattleView.GridBattleView.Visibility = Visibility.Collapsed;
                        // Create a fight
                        this.CombatManager = new CombatManager();

                        this.CombatManager.Combat = await this.CombatManager.StartNewFight(this.GridManager.Dresseur, this.SelectedPokemon);
                        break;
                    case 1:
                        // Search fight without dresseur2
                        // Display the ring loader
                        this.BattleView.RingLoader.Visibility = Visibility.Visible;
                        this.BattleView.RingLoader.ProgressRingText.Text = "Recherche d'un combat en cours";
                        this.BattleView.GridBattleView.Visibility = Visibility.Collapsed;
                        // Create a fight
                        this.CombatManager = new CombatManager();

                        String responseApi = await this.CombatManager.SearchEmptyFight(this.GridManager.Dresseur, this.SelectedPokemon);

                        if (responseApi.Contains("error"))
                        {
                            // Show errors to user
                            MessageDialog dialogError = new MessageDialog("Aucun adversaire n'a été trouvé...");
                            dialogError.Title = "Oups";

                            await dialogError.ShowAsync();

                            this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                            this.BattleView.GridBattleView.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            this.combatManager.Combat = JsonConvert.DeserializeObject<Combat>(responseApi);

                            this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                            this.BattleView.GridBattleView.Visibility = Visibility.Visible;
                        }
                        break;
                    case 2:
                        // Do nothing
                        break;
                    default:
                        break;
                }
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
            if (this.CombatManager.Combat.Dresseur1.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack01 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur2;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque01;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }
            else if (this.CombatManager.Combat.Dresseur2.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack01 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur1;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque01;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }            

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
            if (this.CombatManager.Combat.Dresseur1.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack02 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur2;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque02;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }
            else if (this.CombatManager.Combat.Dresseur2.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack02 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur1;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque02;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }            

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
            if (this.CombatManager.Combat.Dresseur1.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack03 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur2;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque03;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }
            else if (this.CombatManager.Combat.Dresseur2.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack03 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur1;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque03;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }
               

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
            if (this.CombatManager.Combat.Dresseur1.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack04 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur2;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque04;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }
            else if (this.CombatManager.Combat.Dresseur2.Id == this.GridManager.Dresseur.Id)
            {
                // Launch Attack04 against the opponent
                // Get actual PV 
                this.CombatManager.Dresseur = this.CombatManager.Combat.Dresseur1;
                this.CombatManager.ActualPvPokemon = this.BattleView.OpponentView.GetActualPvTxtBox;
                this.CombatManager.Attaque = this.BattleView.AttackMenu.Attaque04;
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
            }                

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
            MessageDialog dialog = new MessageDialog("Es-tu certain de vouloir quitter le combat ? Tu seras considéré comme perdant.");
            dialog.Title = "Confirmation";
            dialog.Commands.Add(new UICommand { Label = "Oui", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Non", Id = 1 });
            dialog.Commands.Add(new UICommand { Label = "Annuler", Id = 2 });

            var res = await dialog.ShowAsync();

            switch ((Int32)res.Id)
            {
                case 0:
                    this.BattleView.RingLoader.Visibility = Visibility.Visible;
                    this.battleView.RingLoader.ProgressRingText.Text = "Enregistrement du résultat";
                    this.BattleView.GridBattleView.Visibility = Visibility.Collapsed;

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
                    await this.CombatManager.FinishFight(this.CombatManager);

                    this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                    this.BattleView.GridBattleView.Visibility = Visibility.Visible;

                    (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
                    break;
                case 1:
                    // Stay in the fight view
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

        public async void ReceiveDataPush(CombatManager combatManager)
        {
            this.CombatManager = combatManager;

            if (this.CombatManager.Combat.Dresseur1Vainqueur == true || this.CombatManager.Combat.Dresseur2Vainqueur == true)
            {
                // Disable attack buttons
                this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;

                // Update message in console
                this.BattleView.Console.DisplayedMessage = this.CombatManager.Console;
                this.BattleView.Console.ConsoleScrollViewer.UpdateLayout();
                this.BattleView.Console.ConsoleScrollViewer.ChangeView(null, (this.BattleView.Console.ConsoleScrollViewer.ExtentHeight - this.BattleView.Console.ConsoleScrollViewer.ViewportHeight), null);

                if (this.GridManager.Dresseur.Id == this.CombatManager.Combat.Dresseur1.Id)
                {

                    if (this.CombatManager.Dresseur != null && this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur1.Id)
                    {
                        // Other turn update my HP
                        // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                        this.BattleView.PlayerView.MaximumPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                        this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                        this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon1;
                        this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                    }
                    else if (this.CombatManager.Dresseur != null && this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur2.Id)
                    {
                        // Bind Opponent view
                        this.BattleView.OpponentView.MaximumPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                        this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                        this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon2;
                        this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
                    }
                }
                else if (this.GridManager.Dresseur.Id == this.CombatManager.Combat.Dresseur2.Id)
                {
                    if (this.CombatManager.Dresseur != null && this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur2.Id)
                    {
                        // Other turn update my HP
                        // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                        this.BattleView.PlayerView.MaximumPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                        this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                        this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon2;
                        this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                    }
                    else if (this.CombatManager.Dresseur != null && this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur1.Id)
                    {
                        // Bind Opponent view
                        this.BattleView.OpponentView.MaximumPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                        this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                        this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon1;
                        this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
                    }
                }                    

                // Update the fight
                await this.CombatManager.FinishFight(this.CombatManager);

                // Finish the campaign and display result
                if (this.CombatManager.Combat.Dresseur1.Id == this.gridManager.Dresseur.Id)
                {
                    if (this.CombatManager.Combat.Dresseur1Vainqueur)
                    {
                        // You win
                        MessageDialog dialog = new MessageDialog("Tu as gagné !");
                        dialog.Title = "Bravo";
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        // You loose
                        MessageDialog dialog = new MessageDialog("Tu as perdu !");
                        dialog.Title = "Dommage";
                        await dialog.ShowAsync();
                    }
                }
                else if(this.CombatManager.Combat.Dresseur2Vainqueur)
                {
                    // You win
                    MessageDialog dialog = new MessageDialog("Tu as gagné !");
                    dialog.Title = "Bravo";
                    await dialog.ShowAsync();
                }
                else
                {
                    // You loose
                    MessageDialog dialog = new MessageDialog("Tu as perdu !");
                    dialog.Title = "Dommage";
                    await dialog.ShowAsync();
                }
                // Come back to MapView
                (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
            }
            else
            {
                // Update message in console
                this.BattleView.Console.DisplayedMessage = this.CombatManager.Console;
                this.BattleView.Console.ConsoleScrollViewer.UpdateLayout();
                this.BattleView.Console.ConsoleScrollViewer.ChangeView(null, (this.BattleView.Console.ConsoleScrollViewer.ExtentHeight - this.BattleView.Console.ConsoleScrollViewer.ViewportHeight), null);

                // If dresseur connected is dresseur1 in fight
                if (this.GridManager.Dresseur.Id == this.CombatManager.Combat.Dresseur1.Id)
                {
                    if (this.CombatManager.Combat.Dresseur2 != null)
                    {
                        // Find opponent
                        // Bind pokemon attacks buttons
                        this.BattleView.AttackMenu.Attaque01 = this.CombatManager.Combat.Pokemon1.Attaque1;
                        this.BattleView.AttackMenu.Attaque02 = this.CombatManager.Combat.Pokemon1.Attaque2;
                        this.BattleView.AttackMenu.Attaque03 = this.CombatManager.Combat.Pokemon1.Attaque3;
                        this.BattleView.AttackMenu.Attaque04 = this.CombatManager.Combat.Pokemon1.Attaque4;
                        // Display my attacks
                        foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
                        {
                            item.Visibility = Visibility.Visible;
                        }

                        // Hide loader
                        this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                        this.BattleView.GridBattleView.Visibility = Visibility.Visible;
                        if (this.CombatManager.Dresseur == null)
                        {
                            // Turn 1
                            // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                            this.BattleView.PlayerView.MaximumPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                            this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                            this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon1;
                            this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                            // Bind Opponent view
                            this.BattleView.OpponentView.MaximumPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                            this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                            this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon2;
                            this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
                        }
                        else
                        {
                            if (this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur1.Id)
                            {
                                // Other turn update my HP
                                // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                                this.BattleView.PlayerView.MaximumPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                                this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                                this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon1;
                                this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                            }
                            else if (this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur2.Id)
                            {
                                // Bind Opponent view
                                this.BattleView.OpponentView.MaximumPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                                this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                                this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon2;
                                this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
                            }
                        }
                        
                        // Waiting for dataPush alert that it is my turn
                        if (this.CombatManager.DresseurActualTurnId != this.CombatManager.Combat.Dresseur1.Id)
                        {
                            // Disable attack buttons
                            this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                            this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                            this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                            this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;
                        }
                        else
                        {
                            // Enable attack buttons
                            this.BattleView.AttackMenu.AttackButton1.IsEnabled = true;
                            this.BattleView.AttackMenu.AttackButton2.IsEnabled = true;
                            this.BattleView.AttackMenu.AttackButton3.IsEnabled = true;
                            this.BattleView.AttackMenu.AttackButton4.IsEnabled = true;
                        }
                    }
                    else
                    {
                        this.CombatManager.Combat = await this.CombatManager.WaitingForDressseur2(this.CombatManager.Combat);

                        if (this.CombatManager.Combat.Dresseur2 == null)
                        {
                            MessageDialog dialog = new MessageDialog("Aucun adversaire n'a été trouvé...");
                            dialog.Title = "Oups";
                            await dialog.ShowAsync();

                            // Update message ring loader
                            this.BattleView.RingLoader.ProgressRingText.Text = "Annulation du combat";

                            // Delete the fight and the campaign
                            await this.CombatManager.DeleteFight(this.CombatManager.Combat);

                            this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                            this.BattleView.GridBattleView.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            // Waiting datapush to start fight
                            // The function will be call again
                        }
                    }
                }
                else if (this.GridManager.Dresseur.Id == this.CombatManager.Combat.Dresseur2.Id)
                {
                    // If dresseur connected is dresseur2 in fight
                    // Find opponent
                    // Bind pokemon attacks buttons
                    this.BattleView.AttackMenu.Attaque01 = this.CombatManager.Combat.Pokemon2.Attaque1;
                    this.BattleView.AttackMenu.Attaque02 = this.CombatManager.Combat.Pokemon2.Attaque2;
                    this.BattleView.AttackMenu.Attaque03 = this.CombatManager.Combat.Pokemon2.Attaque3;
                    this.BattleView.AttackMenu.Attaque04 = this.CombatManager.Combat.Pokemon2.Attaque4;

                    // Disable attack buttons
                    this.BattleView.AttackMenu.AttackButton1.IsEnabled = false;
                    this.BattleView.AttackMenu.AttackButton2.IsEnabled = false;
                    this.BattleView.AttackMenu.AttackButton3.IsEnabled = false;
                    this.BattleView.AttackMenu.AttackButton4.IsEnabled = false;

                    // Display my attacks
                    foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.BattleView.GridBattleView as Grid))
                    {
                        item.Visibility = Visibility.Visible;
                    }

                    // Hide loader
                    this.BattleView.RingLoader.Visibility = Visibility.Collapsed;
                    this.BattleView.GridBattleView.Visibility = Visibility.Visible;
                    if (this.CombatManager.Dresseur == null)
                    {
                        // Turn 1
                        // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                        this.BattleView.PlayerView.MaximumPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                        this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                        this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon2;
                        this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                        // Bind Opponent view
                        this.BattleView.OpponentView.MaximumPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                        this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                        this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon1;
                        this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
                    }
                    else
                    {
                        if (this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur2.Id)
                        {
                            // Other turn update my HP
                            // Bind Selected Pokemon to usercontrol PokemonBattleDisplayPlayer
                            this.BattleView.PlayerView.MaximumPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon2.Niveau);
                            this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                            this.BattleView.PlayerView.Pokemon = this.CombatManager.Combat.Pokemon2;
                            this.BattleView.PlayerView.ActualPv = (this.CombatManager.Combat.Pokemon2.TypeDePokemon.Pv / this.BattleView.PlayerView.MaximumPv) * 100;
                        }
                        else if (this.CombatManager.Dresseur.Id == this.CombatManager.Combat.Dresseur1.Id)
                        {
                            // Bind Opponent view
                            this.BattleView.OpponentView.MaximumPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv * this.CombatManager.Combat.Pokemon1.Niveau);
                            this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv = this.CombatManager.ActualPvPokemon;
                            this.BattleView.OpponentView.Pokemon = this.CombatManager.Combat.Pokemon1;
                            this.BattleView.OpponentView.ActualPv = (this.CombatManager.Combat.Pokemon1.TypeDePokemon.Pv / this.BattleView.OpponentView.MaximumPv) * 100;
                        }
                    }


                    // Waiting for dataPush alert that it is my turn
                    if (this.CombatManager.DresseurActualTurnId == this.CombatManager.Combat.Dresseur2.Id)
                    {
                        // Enable attack buttons
                        this.BattleView.AttackMenu.AttackButton1.IsEnabled = true;
                        this.BattleView.AttackMenu.AttackButton2.IsEnabled = true;
                        this.BattleView.AttackMenu.AttackButton3.IsEnabled = true;
                        this.BattleView.AttackMenu.AttackButton4.IsEnabled = true;
                    }
                }              
            }
        }
    }
}
