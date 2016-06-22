using ClassLibraryEntity;
using Pokemon.Utils;
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

        const int MAX_COLUMN        = 45;
        const int MAX_ROW           = 25;

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
            //Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
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
            this.Player.CurrentOrientation = Player.Orientation.Down_0;

            if (this.Player.Sexe.Equals("M"))
            {
                this.CharacterButton.Source = new BitmapImage(new Uri("ms-appx:///Images/Menu/ManIco.png"));
            }

            if (this.Player.Sexe.Equals("F"))
            {
                this.CharacterButton.Source = new BitmapImage(new Uri("ms-appx:///Images/Menu/WomanIco.png"));
            }

            this.TxtCharacter.Text = this.Player.Name;

            //this.GridManager = new GridManager(this.GridMap, this.Player.PosY, this.Player.PosX, MAX_ROW, MAX_COLUMN, 16, 29, this.Player);
            this.GridManager = new GridManager(this.playerGridMap, 26, 46, 15, 27, 0, 0, this.Player);
        }

        private void GridMap_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Down || e.Key == Windows.System.VirtualKey.S)
            {
                this.GridManager.Player.CurrentOrientation = Player.Orientation.Down_0;
                this.GridManager.GridPlayerMap.Children.Remove(this.GridManager.PlayerImg);
                String playerPictureImagePath = this.Player.GetOrientationImagePath();

                this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));
                
                // Si la ligne que je souhaite atteindre avec mon perso est <= au bord inférieur de mon tableau
                if (this.Player.PosY + 1 < this.GridManager.MaxRow)
                {
                    if (this.Player.PosY + 1 <= (this.GridManager.CurrentRow + (this.GridManager.PlayAreaMaxRow / 2)))
                    {
                        // La ligne désirée est <= au bord du plateau de jeu divisé par 2
                        // On bouge uniquement le perso
                        this.Player.PosY++;
                        this.GridManager.MovePlayer();
                    }
                    else
                    {
                        if (this.GridManager.CurrentRow + this.GridManager.PlayAreaMaxRow + 1 <= this.GridManager.MaxRow)
                        {
                            this.Player.PosY++;
                            this.GridManager.CurrentRow++;
                            this.GridManager.MoveMap();
                            this.GridManager.MovePlayer();
                        }
                        else
                        {
                            // On bouge le personnage sur la grid
                            this.Player.PosY++;
                            this.GridManager.MovePlayer();
                        }
                    }
                }
                else
                {
                    // On affiche juste le personnage au même endroit
                    this.GridManager.MovePlayer();
                }
            }
            if (e.Key == Windows.System.VirtualKey.Right || e.Key == Windows.System.VirtualKey.D)
            {
                this.GridManager.Player.CurrentOrientation = Player.Orientation.Left_0;
                this.GridManager.GridPlayerMap.Children.Remove(this.GridManager.PlayerImg);
                String playerPictureImagePath = this.Player.GetOrientationImagePath();

                this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

                // Si la ligne que je souhaite atteindre avec mon perso est <= au bord inférieur de mon tableau
                if (this.Player.PosX + 1 < this.GridManager.MaxCol)
                {
                    if (this.Player.PosX + 1 <= (this.GridManager.CurrentCol + (this.GridManager.PlayAreaMaxCol / 2)))
                    {
                        // La ligne désirée est <= au bord du plateau de jeu divisé par 2
                        // On bouge uniquement le perso
                        this.Player.PosX++;
                        this.GridManager.MovePlayer();
                    }
                    else
                    {
                        if (this.GridManager.CurrentCol + this.GridManager.PlayAreaMaxCol + 1 <= this.GridManager.MaxCol)
                        {
                            this.Player.PosX++;
                            this.GridManager.CurrentCol++;
                            this.GridManager.MoveMap();
                            this.GridManager.MovePlayer();
                        }
                        else
                        {
                            // On bouge le personnage sur la grid
                            this.Player.PosX++;
                            this.GridManager.MovePlayer();
                        }
                    }
                }
                else
                {
                    // On affiche juste le personnage au même endroit
                    this.GridManager.MovePlayer();
                }                
            }
            if (e.Key == Windows.System.VirtualKey.Left || e.Key == Windows.System.VirtualKey.Q)
            {
                this.GridManager.Player.CurrentOrientation = Player.Orientation.Right_0;
                this.GridManager.GridPlayerMap.Children.Remove(this.GridManager.PlayerImg);
                String playerPictureImagePath = this.Player.GetOrientationImagePath();

                this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

                if (this.Player.PosX - 1 >= 0)
                {
                    if (this.Player.PosX - this.GridManager.CurrentCol - 1 >= (this.GridManager.PlayAreaMaxCol / 2))
                    {
                        this.Player.PosX--;
                        this.GridManager.MovePlayer();
                    }
                    else
                    {
                        if (this.GridManager.CurrentCol - 1 >= 0)
                        {
                            this.Player.PosX--;
                            this.GridManager.CurrentCol--;
                            this.GridManager.MoveMap();
                            this.GridManager.MovePlayer();
                        }
                        else
                        {
                            // On bouge le personnage sur la grid
                            this.Player.PosX--;
                            this.GridManager.MovePlayer();
                        }
                    }
                }
                else
                {
                    // On affiche juste le personnage au même endroit
                    this.GridManager.MovePlayer();
                }
                
            }
            if (e.Key == Windows.System.VirtualKey.Up || e.Key == Windows.System.VirtualKey.Z)
            {
                this.GridManager.Player.CurrentOrientation = Player.Orientation.Up_0;
                this.GridManager.GridPlayerMap.Children.Remove(this.GridManager.PlayerImg);
                String playerPictureImagePath = this.Player.GetOrientationImagePath();

                this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));
                
                if (this.Player.PosY - 1 >= 0 )
                {
                    if (this.Player.PosY - this.GridManager.CurrentRow - 1 >= (this.GridManager.PlayAreaMaxRow / 2))
                    {
                        this.Player.PosY--;
                        this.GridManager.MovePlayer();
                    }
                    else
                    {
                        if (this.GridManager.CurrentRow - 1 >= 0)
                        {
                            this.Player.PosY--;
                            this.GridManager.CurrentRow--;
                            this.GridManager.MoveMap();
                            this.GridManager.MovePlayer();
                        }
                        else
                        {
                            // On bouge le personnage sur la grid
                            this.Player.PosY--;
                            this.GridManager.MovePlayer();
                        }
                    }
                }
                else
                {
                    // On affiche juste le personnage au même endroit
                    this.GridManager.MovePlayer();
                }                
            }
        }

        //private void GridMap_KeyUp(object sender, KeyRoutedEventArgs e)
        //{
        //    if (e.Key == Windows.System.VirtualKey.Down || e.Key == Windows.System.VirtualKey.S)
        //    {
        //        this.GridManager.Player.CurrentOrientation = Player.Orientation.Down_0;
        //        this.GridManager.CurrentGrid.Children.Remove(this.GridManager.PlayerImg);
        //        String playerPictureImagePath = this.Player.GetOrientationImagePath();

        //        this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

        //        // On passe de la ligne x à la ligne x + 1 on décale vers le bas d'une case
        //        // Si la ligne actuelle + 1 est inférieur à 25
        //        if (this.GridManager.CurrentRow + 1 <= this.GridManager.DimMapRow)
        //        {
        //            // Si la case suivante existe
        //            if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow + 1 + ((int)this.GridManager.DimMapVisibleRow / 2)] != null)
        //            {
        //                // Si la case suivante est visible
        //                if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow + 1 + ((int)this.GridManager.DimMapVisibleRow / 2)].ActualHeight > 0)
        //                {
        //                    // Si la prochaine case du perso est dans la grid
        //                    if (this.Player.PosY + 1 <= this.GridManager.DimMapRow)
        //                    {
        //                        // On bouge le personnage sur la map
        //                        this.GridManager.CurrentRow++;
        //                        this.Player.PosY++;
        //                        this.GridManager.MovePlayer();
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    // On bouge la carte si la prochaine case n'est pas visible
        //                    if (this.GridManager.CurrentRow + 1 > ((int)this.GridManager.DimMapVisibleRow / 2))
        //                    {
        //                        this.GridManager.MoveMap(0, true, false);
        //                    }
        //                    // On bouge le joueur
        //                    this.GridManager.CurrentRow++;
        //                    this.Player.PosY++;
        //                    this.GridManager.MovePlayer();
        //                }
        //            }
        //            else
        //            {
        //                // Si la prochaine case du perso est l'avant dernière case dans la grid
        //                // Afin d'afficher le perso même si la barre des tâches est affichée
        //                if (this.Player.PosY + 1 <= this.GridManager.DimMapRow)
        //                {
        //                    // On bouge le personnage sur la map
        //                    this.GridManager.CurrentRow++;
        //                    //this.GridManager.MoveMap();
        //                    this.Player.PosY++;
        //                    this.GridManager.MovePlayer();
        //                    return;
        //                }
        //            }
        //        }           
        //    }
        //    if (e.Key == Windows.System.VirtualKey.Right || e.Key == Windows.System.VirtualKey.D)
        //    {
        //        this.GridManager.Player.CurrentOrientation = Player.Orientation.Left_0;
        //        this.GridManager.CurrentGrid.Children.Remove(this.GridManager.PlayerImg);
        //        String playerPictureImagePath = this.Player.GetOrientationImagePath();

        //        this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

        //        // On passe de la colonne y à la colonne y + 1 on décale vers le droite d'une case
        //        // Si la colonne actuelle + 1 est inférieur à 45
        //        if (this.GridManager.CurrentCol + 1 <= this.GridManager.DimMapCol)
        //        {
        //            // Si la case suivante existe
        //            if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol + 1 + ((int)this.GridManager.DimMapVisibleCol / 2)] != null)
        //            {
        //                // Si la case suivante est visible
        //                int result = this.GridManager.CurrentCol + 1 + ((int)this.GridManager.DimMapVisibleCol / 2);
        //                if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol + 1 + ((int)this.GridManager.DimMapVisibleCol / 2)].ActualWidth > 0)
        //                {
        //                    // Si la prochaine case du perso est dans la grid
        //                    if (this.Player.PosX + 1 <= this.GridManager.DimMapCol)
        //                    {
        //                        // On bouge le personnage sur la map
        //                        this.GridManager.CurrentCol++;
        //                        this.Player.PosX++;
        //                        this.GridManager.MovePlayer();
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    // On bouge la carte si la prochaine case n'est pas visible
        //                    if (this.GridManager.CurrentCol + 1 > ((int)this.GridManager.DimMapVisibleCol / 2))
        //                    {
        //                        this.GridManager.MoveMap(0, false, true);
        //                    }
        //                    // On bouge le joueur
        //                    this.GridManager.CurrentCol++;
        //                    this.Player.PosX++;
        //                    this.GridManager.MovePlayer();
        //                }
        //            }
        //            else
        //            {
        //                // Si la prochaine case du perso est dans la grid
        //                if (this.Player.PosX + 1 <= this.GridManager.DimMapCol)
        //                {
        //                    // On bouge le personnage sur la map
        //                    this.GridManager.CurrentCol++;
        //                    //this.GridManager.MoveMap();
        //                    this.Player.PosX++;
        //                    this.GridManager.MovePlayer();
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //    if (e.Key == Windows.System.VirtualKey.Left || e.Key == Windows.System.VirtualKey.Q)
        //    {
        //        this.GridManager.Player.CurrentOrientation = Player.Orientation.Right_0;
        //        this.GridManager.CurrentGrid.Children.Remove(this.GridManager.PlayerImg);
        //        String playerPictureImagePath = this.Player.GetOrientationImagePath();

        //        this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

        //        // On passe de la colonne y à la colonne y - 1 on décale vers la gauche d'une case
        //        // Si la colonne actuelle - 1 est supérieur ou égal à 0
        //        if (this.GridManager.CurrentCol - 1 >= 0)
        //        {
        //            // Si la case suivante existe
        //            if ((this.GridManager.CurrentCol - 1 - ((int)this.GridManager.DimMapVisibleCol / 2)) >= 0)
        //            {
        //                if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol - 1 - ((int)this.GridManager.DimMapVisibleCol / 2)] != null)
        //                {
        //                    // Si la case précédente est visible
        //                    if (this.GridManager.CurrentGrid.ColumnDefinitions[this.GridManager.CurrentCol - 1 - ((int)this.GridManager.DimMapVisibleCol / 2)].ActualWidth > 0)
        //                    {
        //                        // Si la précédente case du perso est dans la grid
        //                        if (this.Player.PosX - 1 >= 0)
        //                        {
        //                            this.GridManager.CurrentCol--;
        //                            this.Player.PosX--;
        //                            this.GridManager.MovePlayer();
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // On bouge la carte si la prochaine case n'est pas visible
        //                        if (this.GridManager.CurrentCol - 1 <= (this.GridManager.DimMapCol - ((int)this.GridManager.DimMapVisibleCol / 2)))
        //                        {
        //                            int modulo = this.GridManager.DimMapVisibleCol % 2;
        //                            this.GridManager.MoveMap(modulo, false, true);
        //                        }
        //                        this.GridManager.CurrentCol--;
        //                        // On bouge le joueur
        //                        this.Player.PosX--;
        //                        this.GridManager.MovePlayer();
        //                    }
        //                }
        //                else
        //                {
        //                    // Si la précédente case du perso est dans la grid
        //                    if (this.Player.PosX - 1 >= 0)
        //                    {
        //                        this.GridManager.CurrentCol--;
        //                        //this.GridManager.MoveMap();
        //                        this.Player.PosX--;
        //                        this.GridManager.MovePlayer();
        //                        return;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                // Si la précédente case du perso est dans la grid
        //                if (this.Player.PosX - 1 >= 0)
        //                {
        //                    this.GridManager.CurrentCol--;
        //                    this.Player.PosX--;
        //                    this.GridManager.MovePlayer();
        //                    return;
        //                }
        //            }
        //        }            
        //    }
        //    if (e.Key == Windows.System.VirtualKey.Up || e.Key == Windows.System.VirtualKey.Z)
        //    {
        //        this.GridManager.Player.CurrentOrientation = Player.Orientation.Up_0;
        //        this.GridManager.CurrentGrid.Children.Remove(this.GridManager.PlayerImg);
        //        String playerPictureImagePath = this.Player.GetOrientationImagePath();

        //        this.GridManager.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

        //        // On passe de la ligne x à la ligne x - 1 on décale vers le haut d'une case
        //        // Si la ligne actuelle - 1 est supérieur à 0
        //        if (this.GridManager.CurrentRow - 1 >= 0)
        //        {
        //            // Si la case suivante existe
        //            if ((this.GridManager.CurrentRow - ((int)this.GridManager.DimMapVisibleRow / 2)) >= 0)
        //            {
        //                if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow - ((int)this.GridManager.DimMapVisibleRow / 2)] != null)
        //                {
        //                    // Si la case précédente est visible
        //                    if (this.GridManager.CurrentGrid.RowDefinitions[this.GridManager.CurrentRow - ((int)this.GridManager.DimMapVisibleRow / 2)].ActualHeight > 0)
        //                    {
        //                        // Si la précédente case du perso est dans la grid
        //                        if (this.Player.PosY - 1 >= 0)
        //                        {
        //                            this.GridManager.CurrentRow--;
        //                            this.Player.PosY--;
        //                            this.GridManager.MovePlayer();
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // On bouge la carte et le personnage
        //                        if (this.GridManager.CurrentRow - 1 <= (this.GridManager.DimMapRow - ((int)this.GridManager.DimMapVisibleRow / 2)))
        //                        {
        //                            int modulo = this.GridManager.DimMapVisibleRow % 2;
        //                            this.GridManager.MoveMap(modulo, true, false);
        //                        }
        //                        this.GridManager.CurrentRow--;
        //                        this.Player.PosY--;
        //                        this.GridManager.MovePlayer();
        //                    }
        //                }
        //                else
        //                {
        //                    // Si la précédente case du perso est dans la grid
        //                    if (this.Player.PosY - 1 >= 0)
        //                    {
        //                        this.GridManager.CurrentRow--;
        //                        //this.GridManager.MoveMap();
        //                        this.Player.PosY--;
        //                        this.GridManager.MovePlayer();
        //                        return;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                // Si la précédente case du perso est dans la grid
        //                if (this.Player.PosY - 1 >= 0)
        //                {
        //                    this.GridManager.CurrentRow--;
        //                    //this.GridManager.MoveMap();
        //                    this.Player.PosY--;
        //                    this.GridManager.MovePlayer();
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //}

        private void QuitButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.MenuSplitView.IsPaneOpen)
            {
                Application.Current.Exit();
            }
        }

        private void MenuButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.MenuSplitView.IsPaneOpen = !this.MenuSplitView.IsPaneOpen;
        }
        
        private void Pokemon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Open pokemon view
        }

        private void Character_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(this.MenuSplitView.IsPaneOpen)
            {
                (Window.Current.Content as Frame).Navigate(typeof(TrainerCardView), this.Player);
            }
        }
                
        private void Bag_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Open Bag view
        }
        
        private void Pokedex_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(this.MenuSplitView.IsPaneOpen)
            {
                (Window.Current.Content as Frame).Navigate(typeof(PokedexView), this.Player);
            }     
        }   
    }
}
