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
    public sealed partial class ObjectSelectionMenuCombats : UserControl
    {
        private ObservableCollection<PokemonObject> categoryObjectList = new ObservableCollection<PokemonObject>();
        
        internal ObservableCollection<PokemonObject> CategoryObjectList
        {
            get
            {
                return categoryObjectList;
            }
        }
        
        public ObjectSelectionMenuCombats()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            BattleObject fightObject01 = new BattleObject("Objet de combats 01", "ms-appx:///Images/ObjectsCategory/Fist.png");
            BattleObject fightObject02 = new BattleObject("Objet de combats 02", "ms-appx:///Images/ObjectsCategory/Fist.png");
            BattleObject fightObject03 = new BattleObject("Objet de combats 03", "ms-appx:///Images/ObjectsCategory/Fist.png");
            BattleObject fightObject04 = new BattleObject("Objet de combats 04", "ms-appx:///Images/ObjectsCategory/Fist.png");

            this.CategoryObjectList.Add(fightObject01);
            this.CategoryObjectList.Add(fightObject02);
            this.CategoryObjectList.Add(fightObject03);
            this.CategoryObjectList.Add(fightObject04);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (ObjectCategoryMenu item in Helper.FindVisualChildren<ObjectCategoryMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

    }
}
