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

namespace Pokemon.Utils
{
    public class GridManager
    {
        private Grid currentGrid;
        private Grid gridPlayerMap;
        private String[,] tabImagesSource;
        private int maxRow;
        private int maxCol;
        private int playAreaMaxCol;
        private int playAreaMaxRow;
        private int currentRow;
        private int currentCol;
        private Image playerImg;
        private Player player;              

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
            set { gridPlayerMap = value; }
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

        public GridManager()
        {

        }

        public GridManager(Grid gridPlayerMap, int maxRow, int maxCol, int playAreaMaxRow, int playAreaMaxCol, int currentRow, int currentCol, Player player)
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

            ConstructTabImagesSource();
            ConstructGridPlayerMap(this.CurrentRow, this.PlayAreaMaxRow, this.CurrentCol, this.PlayAreaMaxCol);
            MovePlayer();
        }

        private void ConstructTabImagesSource()
        {
            this.tabImagesSource = new String[26, 46];
            int count = 1;
            for (int row = 0; row < 26; row++)
            {
                for (int col = 0; col < 46; col++)
                {
                    this.tabImagesSource[row, col] = "ms-appx:///Images/Map/map_" + count.ToString("00") + ".png";

                    count++;
                }
            }
        }

        private void ConstructGridPlayerMap(int startRow, int endRow, int startCol, int endCol)
        {
            // On définit les dimensions de la grid
            this.GridPlayerMap.Width = 1728;
            this.GridPlayerMap.Height = 960;
            // On contruit la grid avec les dimensions de l'affichage du plateau de jeu (par défaut large)
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
                for (int col = startCol; col < endCol; col++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(this.tabImagesSource[row, col]));
                    this.GridPlayerMap.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                }
            }
        }
        
        public void MoveMap()
        {
            int i = this.CurrentRow;
            int j = this.CurrentCol;
            
            for (int row = 0; row < this.PlayAreaMaxRow; row++)
            {
                j = this.CurrentCol;
                for (int col = 0; col < this.PlayAreaMaxCol; col++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(this.tabImagesSource[i, j]));
                    this.GridPlayerMap.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                    j++;
                }
                i++;
            }
        }

        public void MovePlayer()
        {
            this.GridPlayerMap.Children.Remove(this.PlayerImg);
            String playerPictureImagePath = this.Player.GetOrientationImagePath();

            this.PlayerImg.Source = new BitmapImage(new Uri(playerPictureImagePath));
            this.GridPlayerMap.Children.Add(this.PlayerImg);
            Grid.SetColumn(this.PlayerImg, this.Player.PosX - this.CurrentCol);
            Grid.SetRow(this.PlayerImg, this.Player.PosY - this.CurrentRow);

            if ((this.Player.PosX == 29) && (this.Player.PosY == 15)){
                (Window.Current.Content as Frame).Navigate(typeof(BattleView), this.Player);
            }
        }
    }
}
