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
using Pokemon.Pages;

namespace Pokemon.Entity
{
    class GridManager
    {
        private Grid currentGrid;
        private int currentRow;
        private int currentCol;
        private int dimMapRow;
        private int dimMapCol;
        private int dimMapVisibleRow;
        private int dimMapVisibleCol;
        private Image playerImg;
        private Player player;

        public Grid CurrentGrid
        {
            get
            {
                return currentGrid;
            }

            set
            {
                currentGrid = value;
            }
        }

        public int CurrentRow
        {
            get
            {
                return currentRow;
            }

            set
            {
                currentRow = value;
            }
        }

        public int CurrentCol
        {
            get
            {
                return currentCol;
            }

            set
            {
                currentCol = value;
            }
        }

        public int DimMapRow
        {
            get
            {
                return dimMapRow;
            }

            set
            {
                dimMapRow = value;
            }
        }

        public int DimMapCol
        {
            get
            {
                return dimMapCol;
            }

            set
            {
                dimMapCol = value;
            }
        }

        public int DimMapVisibleRow
        {
            get
            {
                return dimMapVisibleRow;
            }

            set
            {
                dimMapVisibleRow = value;
            }
        }

        public int DimMapVisibleCol
        {
            get
            {
                return dimMapVisibleCol;
            }

            set
            {
                dimMapVisibleCol = value;
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

        public GridManager(Grid currentGrid, int currentRow, int currentCol, int dimMapRow, int dimMapCol, int dimMapVisibleRow, int dimMapVisibleCol, Player player)
        {
            this.CurrentGrid = currentGrid;
            this.CurrentRow = currentRow;
            this.CurrentCol = currentCol;
            this.DimMapRow = dimMapRow;
            this.DimMapCol = dimMapCol;
            this.DimMapVisibleRow = dimMapVisibleRow;
            this.DimMapVisibleCol = dimMapVisibleCol;
            this.PlayerImg = new Image();
            //this.PlayerImg.Source = new BitmapImage(new Uri(characterPathImg));
            this.Player = player;

            ContructMap();

            MovePlayer(this.Player.PosX, this.Player.PosY, "Down");
        }

        private void ContructMap()
        {
            int compteur = 1;
            for (int row = 0; row <= this.DimMapRow; row++)
            {
                for (int col = 0; col <= this.DimMapCol; col++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("ms-appx:///Images/Map/map_" + compteur.ToString("00") + ".png"));
                    this.CurrentGrid.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                    if (col < this.CurrentCol)
                    {
                        this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                    }
                    else
                    {
                        if(col <= this.CurrentCol + this.DimMapVisibleCol)
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
                        }
                        else
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                        }
                    }
                    compteur++;
                }
                if (row < this.CurrentRow)
                {
                    this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                }
                else
                {
                    if (row <= this.CurrentRow + this.DimMapVisibleRow)
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Auto);
                    }
                    else
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                    }
                }
            }
        }

        public void MoveMap()
        {
            for (int row = 0; row <= this.DimMapRow; row++)
            {
                for (int col = 0; col <= this.DimMapCol; col++)
                {
                    if (col < this.CurrentCol)
                    {
                        this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                    }
                    else
                    {
                        if (col <= this.CurrentCol + this.DimMapVisibleCol)
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
                        }
                        else
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                        }
                    }
                }
                if (row < this.CurrentRow)
                {
                    this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                }
                else
                {
                    if (row <= this.CurrentRow + this.DimMapVisibleRow)
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Auto);
                    }
                    else
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                    }
                }
            }
        }

        public void MovePlayer(int x, int y, String direction)
        {
            this.Player.PosX = x;
            this.Player.PosY = y;
            this.CurrentGrid.Children.Remove(this.PlayerImg);

            this.PlayerImg.Source = new BitmapImage(new Uri("ms-appx:///Images/Sprites/Sprite_" + direction + "_01.png"));

            this.CurrentGrid.Children.Add(this.PlayerImg);
            Grid.SetColumn(this.PlayerImg, this.Player.PosX);
            Grid.SetRow(this.PlayerImg, this.Player.PosY);

            if ((this.Player.PosX == 29) && (this.Player.PosY == 15)){
                (Window.Current.Content as Frame).Navigate(typeof(BattleView), this.Player);
            }
        }
    }
}
