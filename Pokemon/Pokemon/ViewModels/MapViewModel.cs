using ClassLibraryEntity;
using Pokemon.Pages.Views;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Pokemon.ViewModels
{
    public class MapViewModel
    {
        private MapView mapView;
        private Player player;
        private GridManager gridManager;

        public MapView MapView
        {
            get
            {
                return mapView;
            }

            set
            {
                mapView = value;
            }
        }

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

        public MapViewModel(MapView mapView)
        {
            this.MapView = mapView;
            this.GridManager = this.MapView.GridManager;
            this.Player = this.GridManager.Player;
            this.Player.CurrentOrientation = Player.Orientation.Down_0;
            this.GridManager.GridPlayerMap = this.MapView.PlayerGrid;
            this.GridManager.ConstructGridPlayerMap(0, this.GridManager.PlayAreaMaxRow, 0, this.GridManager.PlayAreaMaxCol);

            //this.GridManager = new GridManager(this.playerGridMap, 26, 46, 15, 27, 0, 0, this.Player);
            //this.GridManager = new GridManager(this.playerGridMap, 26, 46, 15, 27, 11, 19, this.Player);
            //this.GridManager.MovePlayer();

            this.Bind();
        }

        private void Bind()
        {
            this.MapView.MenuSP.Tapped += MenuSP_Tapped;
            this.MapView.MenuPokedexSP.Tapped += MenuPokedexSP_Tapped;
            this.MapView.MenuQuitSP.Tapped += MenuQuitSP_Tapped;
            this.MapView.MapGrid.KeyUp += MapGrid_KeyUp;
        }
        
        private void MapGrid_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
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

                if (this.Player.PosY - 1 >= 0)
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

        private void MenuQuitSP_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (this.MapView.SplitView.IsPaneOpen)
            {
                Application.Current.Exit();
            }
        }

        private void MenuPokedexSP_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (this.MapView.SplitView.IsPaneOpen)
            {
                (Window.Current.Content as Frame).Navigate(typeof(PokedexView), this.GridManager);
            }
        }

        private void MenuSP_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.MapView.SplitView.IsPaneOpen = !this.MapView.SplitView.IsPaneOpen;
        }
    }
}
