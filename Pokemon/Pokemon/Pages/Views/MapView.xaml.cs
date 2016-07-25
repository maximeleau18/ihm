using ClassLibraryEntity;
using Microsoft.Azure.Engagement.Overlay;
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
    public sealed partial class MapView : EngagementPageOverlay
    {
        private Player player;
        private GridManager gridManager;
        
        public Player Player
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

        public MapView()
        {
            this.InitializeComponent();

            // On abonne la grid à l'évènement afin de bouger notre personnage
            base.Loaded += Page_Loaded;
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
            this.GridManager = (GridManager)e.Parameter;
            this.Player = this.GridManager.Player;
            this.Player.CurrentOrientation = Player.Orientation.Down_0;
            this.GridManager.GridPlayerMap = this.playerGridMap;
            this.GridManager.ConstructGridPlayerMap(0, this.GridManager.PlayAreaMaxRow, 0, this.GridManager.PlayAreaMaxCol);
            
            //this.GridManager = new GridManager(this.playerGridMap, 26, 46, 15, 27, 0, 0, this.Player);
            //this.GridManager = new GridManager(this.playerGridMap, 26, 46, 15, 27, 11, 19, this.Player);
            this.GridManager.MovePlayer();
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
                                       
        private void Pokedex_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(this.MenuSplitView.IsPaneOpen)
            {
                (Window.Current.Content as Frame).Navigate(typeof(PokedexView), this.GridManager);
            }     
        }   
    }
}
