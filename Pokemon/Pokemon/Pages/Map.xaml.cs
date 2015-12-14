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

namespace Pokemon.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        public Map()
        {
            this.InitializeComponent();
            int compteur = 1;
            for (int row = 0; row <= 12; row++)
            {
                for (int col = 0; col <= 12; col++)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("ms-appx:///Images/Map/map_"+ compteur.ToString("00") +".gif"));
                    this.GridMap.Children.Add(img);
                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                    compteur++;
                }
            }
        }
    }
}
