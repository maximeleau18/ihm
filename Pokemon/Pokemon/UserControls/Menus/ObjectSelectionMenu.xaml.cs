using Pokemon.Entity;
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
    public sealed partial class ObjectSelectionMenu : UserControl
    {
        private ObservableCollection<PokemonObject> categoryObjectList = new ObservableCollection<PokemonObject>();
        
        internal ObservableCollection<PokemonObject> CategoryObjectList
        {
            get
            {
                return categoryObjectList;
            }
        }

        public ObjectSelectionMenu()
        {
            this.InitializeComponent();
            LoadContent();
            //this.ListObjectCategory.DataContext = this.CategoryObjectList;
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            StatusPokemon statusPokemon = new StatusPokemon("Freeze");
            StatusObject statusObject = new StatusObject("Status", "ms-appx:///Images/ObjectsCategory/status.png", statusPokemon);

            BallObject ballObject = new BallObject("Pokéballs", "ms-appx:///Images/ObjectsCategory/Pokeball.png");
            BattleObject battleObject = new BattleObject("Outils de bataille", "ms-appx:///Images/ObjectsCategory/Fist.png");
            MedicObject medicObject = new MedicObject("Médicaments", "ms-appx:///Images/ObjectsCategory/Medic.png", statusObject);
            

            this.CategoryObjectList.Add(ballObject);
            this.CategoryObjectList.Add(battleObject);
            this.CategoryObjectList.Add(medicObject);
            this.CategoryObjectList.Add(statusObject);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

    }
}
