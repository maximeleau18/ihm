using Pokemon.Entity;
using Pokemon.UserControls.Other;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class ObjectSelectionMenuPokeballs : UserControl
    {
        private ObservableCollection<PokemonObject> categoryObjectList = new ObservableCollection<PokemonObject>();

        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;
        }
        internal ObservableCollection<PokemonObject> CategoryObjectList
        {
            get
            {
                return categoryObjectList;
            }
        }
        
        public ObjectSelectionMenuPokeballs()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            BallObject smallBallObject = new BallObject("Petites Pokéballs", "ms-appx:///Images/ObjectsCategory/Pokeball.png");
            BallObject mediumBallObject = new BallObject("Moyennes Pokéballs", "ms-appx:///Images/ObjectsCategory/Pokeball.png");
            BallObject hightBallObject = new BallObject("Grandes Pokéballs", "ms-appx:///Images/ObjectsCategory/Pokeball.png");
            BallObject giantBallObject = new BallObject("Gigantesques Pokéballs", "ms-appx:///Images/ObjectsCategory/Pokeball.png");

            this.CategoryObjectList.Add(smallBallObject);
            this.CategoryObjectList.Add(mediumBallObject);
            this.CategoryObjectList.Add(hightBallObject);
            this.CategoryObjectList.Add(giantBallObject);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myConsole.setMessageObjectCategoryMenuText();
            foreach (ObjectCategoryMenu item in Helper.FindVisualChildren<ObjectCategoryMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

    }
}
