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
            // On contruit les lignes et les colonnes 
            for (int row = 0; row <= this.DimMapRow; row++)
            {
                this.CurrentGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int col = 0; col <= this.DimMapCol; col++)
            {
                this.CurrentGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int compteur = 1;
            //for (int row = 0; row <= this.DimMapRow; row++)
            //{
            //    for (int col = 0; col <= this.DimMapCol; col++)
            //    {
            //        Image img = new Image();
            //        img.Source = new BitmapImage(new Uri("ms-appx:///Images/Map/map_" + compteur.ToString("00") + ".png"));
            //        this.CurrentGrid.Children.Add(img);
            //        Grid.SetRow(img, row);
            //        Grid.SetColumn(img, col);
            //        if (col < this.CurrentCol)
            //        {
            //            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
            //        }
            //        else
            //        {
            //            if(col <= this.CurrentCol + this.DimMapVisibleCol)
            //            {
            //                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
            //            }
            //            else
            //            {
            //                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
            //            }
            //        }
            //        compteur++;
            //    }
            //    if (row < this.CurrentRow)
            //    {
            //        if (row < this.CurrentRow - this.DimMapVisibleRow)
            //        {
            //            this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
            //        }
            //    }
            //    else
            //    {
            //        if (row <= this.CurrentRow + this.DimMapVisibleRow)
            //        {
            //            this.CurrentGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Auto);
            //        }
            //        else
            //        {
            //            this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
            //        }
            //    }
            //}
            int colModulo = this.DimMapVisibleCol % 2;
            int rowModulo = this.DimMapVisibleRow % 2;

            for (int row = 0; row <= this.DimMapRow; row++)
            {
                for (int col = 0; col <= this.DimMapCol; col++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("ms-appx:///Images/Map/map_" + compteur.ToString("00") + ".png"));
                    this.CurrentGrid.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                    if (this.CurrentCol - ((int)this.DimMapVisibleCol / 2) - colModulo < 0)
                    {
                        if (col <= (this.CurrentCol - ((int)this.DimMapVisibleCol / 2) - ((int)this.DimMapVisibleCol / 2)) - colModulo * - 1)
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
                        }
                        else
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                        }
                    }
                    else
                    {
                        if (this.CurrentCol + ((int)this.DimMapVisibleCol / 2) + colModulo > this.DimMapCol)
                        {
                            if (col <= (this.CurrentCol - ((int)this.DimMapVisibleCol / 2) - ((int)this.DimMapVisibleCol / 2)) - colModulo)
                            {
                                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                            }
                            else
                            {
                                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
                            }
                        }
                        else
                        {
                            if (col < this.CurrentCol - ((int)this.DimMapVisibleCol / 2) - colModulo)
                            {
                                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                            }
                            else
                            {
                                if (col <= this.CurrentCol + ((int)this.DimMapVisibleCol / 2) + colModulo)
                                {
                                    this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
                                }
                                else
                                {
                                    this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                                }
                            }
                        }                        
                    }                    
                    compteur++;
                }
                if (this.CurrentRow - ((int)this.DimMapVisibleRow / 2) -  rowModulo < 0)
                {
                    if (row <= (this.CurrentRow - ((int)this.DimMapVisibleRow / 2) - ((int)this.DimMapVisibleRow / 2) - rowModulo * - 1))
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Auto);
                    }
                    else
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                    }
                }
                else
                {
                    if (this.CurrentRow + ((int)this.DimMapVisibleRow / 2) + rowModulo > this.DimMapRow)
                    {
                        if (row <= (this.CurrentRow - ((int)this.DimMapVisibleRow / 2) - ((int)this.DimMapVisibleRow / 2)) - rowModulo)
                        {
                            this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                        }
                        else
                        {
                            this.CurrentGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Auto);
                        }
                    }
                    else
                    {
                        if (row < this.CurrentRow - ((int)this.DimMapVisibleRow / 2) - rowModulo)
                        {
                            this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                        }
                        else
                        {
                            if (row <= this.CurrentRow + ((int)this.DimMapVisibleRow / 2) + rowModulo)
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
            }
        }

        public async void SizeChanged(Size newSize)
        {
            //MessageDialog dialog = new MessageDialog(newSize.Height + " x " + newSize.Width);

            //await dialog.ShowAsync();
            
            //ColumnDefinitionCollection colDefsColTemp1 = this.CurrentGrid.ColumnDefinitions;
            //RowDefinitionCollection rowDefColTemp1 = this.CurrentGrid.RowDefinitions;

            //foreach (var itemColDefs in colDefsColTemp1)
            //{
            //    if (!itemColDefs.Width.Equals(new GridLength(0))) { itemColDefs.Width = new GridLength(1, GridUnitType.Auto);  }  
            //}
            //foreach (var itemRowDefs in rowDefColTemp1)
            //{
            //    if (!itemRowDefs.Height.Equals(new GridLength(0))) { itemRowDefs.Height = new GridLength(1, GridUnitType.Auto); }
            //}
        }

        public void MoveMap(int modulo = 0, bool moveRow = false, bool moveCol = false)
        {
            for (int row = 0; row <= this.DimMapRow; row++)
            {
                for (int col = 0; col <= this.DimMapCol; col++)
                {
                    if (moveCol)
                    {
                        if (col < this.CurrentCol - ((int)this.DimMapVisibleCol / 2) - modulo)
                        {
                            this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                        }
                        else
                        {
                            if (col <= this.CurrentCol + ((int)this.DimMapVisibleCol / 2) - modulo)
                            {
                                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(1, GridUnitType.Auto);
                            }
                            else
                            {
                                this.CurrentGrid.ColumnDefinitions[col].Width = new GridLength(0);
                            }
                        }
                    }
                }
                if (moveRow)
                {
                    if (row < this.CurrentRow - ((int)this.DimMapVisibleRow / 2) - modulo)
                    {
                        this.CurrentGrid.RowDefinitions[row].Height = new GridLength(0);
                    }
                    else
                    {
                        if (row <= this.CurrentRow + ((int)this.DimMapVisibleRow / 2) - modulo)
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
