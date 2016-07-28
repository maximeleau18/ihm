using ClassLibraryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Pokemon.Pages.Views;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;

namespace Pokemon.Utils
{
    public class GridManager
    {
        private Grid gridPlayerMap;
        private BitmapImage[,] tabImagesSource;
        private int maxRow;
        private int maxCol;
        private int playAreaMaxCol;
        private int playAreaMaxRow;
        private int currentRow;
        private int currentCol;
        private Image playerImg;
        private Player player;
        private Dresseur dresseur;              

        public int CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }

        public int CurrentCol
        {
            get { return currentCol; }
            set { currentCol = value; }
        }

        public int PlayAreaMaxRow
        {
            get { return playAreaMaxRow; }
            set { playAreaMaxRow = value; }
        }
        
        public int PlayAreaMaxCol
        {
            get { return playAreaMaxCol; }
            set { playAreaMaxCol = value; }
        }
        
        public int MaxRow
        {
            get { return maxRow; }
            set { maxRow = value; }
        }

        public int MaxCol
        {
            get { return maxCol; }
            set { maxCol = value; }
        }

        public Grid GridPlayerMap
        {
            get { return gridPlayerMap; }
            set {
                gridPlayerMap = value;
            }
        }

        public Image PlayerImg
        {
            get
            {
                return playerImg;
            }

            set
            {
                playerImg = value;
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

        public Dresseur Dresseur
        {
            get
            {
                return dresseur;
            }

            set
            {
                dresseur = value;
            }
        }

        public GridManager()
        {

        }

        public GridManager(int maxRow, int maxCol, int playAreaMaxRow, int playAreaMaxCol, int currentRow, int currentCol, Player player, Dresseur dresseur)
        {
            this.CurrentRow = currentRow;
            this.CurrentCol = currentCol;
            this.MaxRow = maxRow;
            this.MaxCol = maxCol;
            this.PlayAreaMaxRow = playAreaMaxRow;
            this.PlayAreaMaxCol = playAreaMaxCol;
            this.PlayerImg = new Image();
            this.Player = player;
            this.Dresseur = dresseur;

            ConstructTabImagesSource();
        }

        public GridManager(Grid gridPlayerMap, int maxRow, int maxCol, int playAreaMaxRow, int playAreaMaxCol, int currentRow, int currentCol, Player player, Dresseur dresseur)
        {
            this.GridPlayerMap = gridPlayerMap;
            this.CurrentRow = currentRow;
            this.CurrentCol = currentCol;
            this.MaxRow = maxRow;
            this.MaxCol = maxCol;
            this.PlayAreaMaxRow = playAreaMaxRow;
            this.PlayAreaMaxCol = playAreaMaxCol;
            this.PlayerImg = new Image();
            this.Player = player;
            this.Dresseur = dresseur;
            
            ConstructGridPlayerMap(0, this.PlayAreaMaxRow, 0, this.PlayAreaMaxCol);
        }

        private void ConstructTabImagesSource()
        {
            this.tabImagesSource = new BitmapImage[this.MaxRow, this.MaxCol];
            int count = 1;
            for (int row = 0; row < this.MaxRow; row++)
            {
                for (int col = 0; col < this.MaxCol; col++)
                {
                    this.tabImagesSource[row, col] = new BitmapImage(new Uri("ms-appx:///Images/Map/map_" + count.ToString("00") + ".png"));

                    count++;
                }
            }
        }

        public void ConstructGridPlayerMap(int startRow, int endRow, int startCol, int endCol)
        {
            ConstructTabImagesSource();

            // On définit les dimensions de la grid
            this.GridPlayerMap.MaxWidth = 1728;
            this.GridPlayerMap.MinWidth = 832;
            this.GridPlayerMap.MaxHeight = 960;
            this.GridPlayerMap.MinHeight = 448;
            int i = this.CurrentRow;
            int j = this.CurrentCol;
            // On construit la grid avec les dimensions de l'affichage du plateau de jeu
            for (int row = startRow; row < endRow; row++)
            {
                this.GridPlayerMap.RowDefinitions.Add(new RowDefinition());
            }

            for (int col = startCol; col < endCol; col++)
            {
                this.GridPlayerMap.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = startRow; row < endRow; row++)
            {
                j = this.CurrentCol;
                for (int col = startCol; col < endCol; col++)
                {
                    Image img = new Image();
                    img.Source = this.tabImagesSource[i, j];
                    this.GridPlayerMap.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);

                    if (j == 29 && i == 14)
                    {
                        Image imgPnj = new Image();
                        imgPnj.Source = new BitmapImage(new Uri("ms-appx:///Images/Sprites/Sprite_Down_01.png"));
                        this.GridPlayerMap.Children.Add(imgPnj);
                        Grid.SetRow(imgPnj, row);
                        Grid.SetColumn(imgPnj, col);
                    }
                    j++;
                }
                i++;
            }

            MovePlayer();
        }

        public void MoveMap()
        {
            int i = this.CurrentRow;
            int j = this.CurrentCol;

            this.GridPlayerMap.Children.Clear();
            for (int row = 0; row < this.GridPlayerMap.RowDefinitions.Count; row++)
            {
                j = this.CurrentCol;
                for (int col = 0; col < this.GridPlayerMap.ColumnDefinitions.Count; col++)
                {
                    Image img = new Image();
                    img.Source = this.tabImagesSource[i, j];
                    this.GridPlayerMap.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);

                    if (j == 29 && i == 14)
                    {
                        Image imgPnj = new Image();
                        imgPnj.Source = new BitmapImage(new Uri("ms-appx:///Images/Sprites/Sprite_Down_01.png"));
                        this.GridPlayerMap.Children.Add(imgPnj);
                        Grid.SetRow(imgPnj, row);
                        Grid.SetColumn(imgPnj, col);
                    }
                    j++;
                }
                i++;
            }
        }

        public void MovePlayer()
        {

            this.GridPlayerMap.Children.Remove(this.PlayerImg);
            String playerPictureImagePath = this.Player.GetOrientationImagePath();

            this.PlayerImg = new Image();
            this.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));

            this.GridPlayerMap.Children.Add(this.PlayerImg);
            Grid.SetColumn(this.PlayerImg, this.Player.PosX - this.CurrentCol);
            Grid.SetRow(this.PlayerImg, this.Player.PosY - this.CurrentRow);

            //if ((this.Player.PosX == 29) && (this.Player.PosY == 15))
            //{
            //    (Window.Current.Content as Frame).Navigate(typeof(BattleView), this);
            //}
        }
    }
}
