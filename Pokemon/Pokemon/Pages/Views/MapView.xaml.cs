using Pokemon.Entity;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokemon.Pages.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MapView : Page
    {
        private Player player;
        private GridManager gridManager;

        internal Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

        internal GridManager GridManager
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

        public MapView()
        {
            this.InitializeComponent();

            // On abonne la grid à l'évènement afin de bouger notre personnage
            this.Loaded += Page_Loaded;
            this.Unloaded += Page_Unloaded;
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).KeyUp += GridMap_KeyUp;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).KeyUp -= GridMap_KeyUp;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.Player = (Player)e.Parameter;

            if (this.Player.Sexe.Equals("M"))
            {
                this.CharacterButton.Source = new BitmapImage(new Uri("ms-appx:///Images/Menu/ManIco.png"));
            }

            if (this.Player.Sexe.Equals("F"))
            {
                this.CharacterButton.Source = new BitmapImage(new Uri("ms-appx:///Images/Menu/WomanIco.png"));
            }

            this.TxtCharacter.Content = this.Player.Name;
            
            this.GridManager = new GridManager(this.GridMap, 5, 17, 26, 45, 17, 28, this.Player);
        }

        private void GridMap_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Down || e.Key == Windows.System.VirtualKey.S)
            {
                // On passe de la ligne x à la ligne x + 1 on décale vers le bas d'une case
                // Si la ligne actuelle + 1 est inférieur à 25
                if (this.GridManager.CurrentRow + 1 <= this.GridManager.DimMapRow)
                {
                    // Si la case suivante existe
                    if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow + 1 + this.GridManager.DimMapVisibleRow] != null)
                    {
                        // Si la case suivante est visible
                        if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow + 1 + this.GridManager.DimMapVisibleRow].ActualHeight > 0)
                        {
                            // Si la prochaine case du perso est dans la grid
                            if (this.Player.PosY + 1 <= this.GridManager.DimMapRow)
                            {
                                // On bouge le personnage sur la map
                                this.Player.PosY++;
                                this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Down");
                                return;
                            }
                        }
                        else
                        {
                            // On bouge la carte et le personnage
                            this.GridManager.CurrentRow++;
                            this.GridManager.MoveMap();
                            this.Player.PosY++;
                            this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Down");

                        }
                    }
                    else
                    {
                        // Si la prochaine case du perso est l'avant dernière case dans la grid
                        // Afin d'afficher le perso même si la barre des tâches est affichée
                        if (this.Player.PosY + 1 < this.GridManager.DimMapRow)
                        {
                            // On bouge le personnage sur la map
                            this.Player.PosY++;
                            this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Down");
                            return;
                        }
                    }
                }           
            }
            if (e.Key == Windows.System.VirtualKey.Right || e.Key == Windows.System.VirtualKey.D)
            {
                // On passe de la colonne y à la colonne y + 1 on décale vers le droite d'une case
                // Si la colonne actuelle + 1 est inférieur à 45
                if (this.GridManager.CurrentCol + 1 <= this.GridManager.DimMapCol)
                {
                    // Si la case suivante existe
                    if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol + 1 + this.GridManager.DimMapVisibleCol] != null)
                    {
                        // Si la case suivante est visible
                        if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol + 1 + this.GridManager.DimMapVisibleCol].ActualWidth > 0)
                        {
                            // Si la prochaine case du perso est dans la grid
                            if (this.Player.PosX + 1 <= this.GridManager.DimMapCol)
                            {
                                // On bouge le personnage sur la map
                                this.Player.PosX++;
                                this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Right");
                                return;
                            }
                        }
                        else
                        {
                            // On bouge la carte et le personnage
                            this.GridManager.CurrentCol++;
                            this.GridManager.MoveMap();
                            this.Player.PosX++;
                            this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Right");

                        }
                    }
                    else
                    {
                        // Si la prochaine case du perso est dans la grid
                        if (this.Player.PosX + 1 <= this.GridManager.DimMapCol)
                        {
                            // On bouge le personnage sur la map
                            this.Player.PosX++;
                            this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Right");
                            return;
                        }
                    }
                }
            }
            if (e.Key == Windows.System.VirtualKey.Left || e.Key == Windows.System.VirtualKey.Q)
            {
                // On passe de la colonne y à la colonne y - 1 on décale vers la gauche d'une case
                // Si la colonne actuelle - 1 est supérieur ou égal à 0
                if (this.GridManager.CurrentCol - 1 >= 0)
                {
                    // Si la case suivante existe
                    if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol - 1] != null)
                    {
                        // Si la case précédente est visible
                        if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol - 1].ActualWidth > 0)
                        {
                            // Si la précédente case du perso est dans la grid
                            if (this.Player.PosX - 1 >= 0)
                            {
                                this.Player.PosX--;
                                this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Left");
                                return;
                            }
                        }
                        else
                        {
                            // On bouge la carte et le personnage
                            this.GridManager.CurrentCol--;
                            this.GridManager.MoveMap();
                            this.Player.PosX--;
                            this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Left");
                        }
                    }
                }
                else
                {
                    // Si la précédente case du perso est dans la grid
                    if (this.Player.PosX - 1 >= 0)
                    {
                        this.Player.PosX--;
                        this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Left");
                        return;
                    }
                } 
            }
            if (e.Key == Windows.System.VirtualKey.Up || e.Key == Windows.System.VirtualKey.Z)
            {
                // On passe de la ligne x à la ligne x - 1 on décale vers le haut d'une case
                // Si la ligne actuelle + 1 est supérieur à 0
                if (this.GridManager.CurrentRow - 1 >= 0)
                {
                    // Si la case suivante existe
                    if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow - 1] != null)
                    {
                        // Si la case précédente est visible
                        if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow - 1].ActualHeight > 0)
                        {
                            // Si la précédente case du perso est dans la grid
                            if (this.Player.PosY - 1 >= 0)
                            {
                                this.Player.PosY--;
                                this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Up");
                                return;
                            }
                        }
                        else
                        {
                            // On bouge la carte et le personnage
                            this.GridManager.CurrentRow--;
                            this.GridManager.MoveMap();
                            this.Player.PosY--;
                            this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Up");
                        }
                    }
                }
                else
                {
                    // Si la précédente case du perso est dans la grid
                    if (this.Player.PosY - 1 >= 0)
                    {
                        this.Player.PosY--;
                        this.GridManager.MovePlayer(this.Player.PosX, this.Player.PosY, "Up");
                        return;
                    }
                }
            }
        }

        private void MenuButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }

        private void PokedexButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }

        private void PokemonButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }

        private void CharacterButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }

        private void ReturnButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }

        private void BagButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }

        private void TxtReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPageView));
        }

        private void TxtPokedex_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(PokedexView));
        }

        private void TxtBag_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void TxtCharacter_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(TrainerCardView), this.Player);
        }

        private void TxtPokemon_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
