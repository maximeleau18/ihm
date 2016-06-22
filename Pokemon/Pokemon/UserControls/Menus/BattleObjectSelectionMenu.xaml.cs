using ClassLibraryEntity;
using Pokemon.UserControls.Buttons;
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
    public sealed partial class BattleObjectSelectionMenu : UserControl
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
        
        public BattleObjectSelectionMenu()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            BattleObject fightObject01 = new BattleObject("Attaque +", "ms-appx:///Images/ObjectsCategory/Fist.png");
            BattleObject fightObject02 = new BattleObject("Défense +", "ms-appx:///Images/ObjectsCategory/Fist.png");
            BattleObject fightObject03 = new BattleObject("Vitesse +", "ms-appx:///Images/ObjectsCategory/Fist.png");
            BattleObject fightObject04 = new BattleObject("Précision +", "ms-appx:///Images/ObjectsCategory/Fist.png");

            this.CategoryObjectList.Add(fightObject01);
            this.CategoryObjectList.Add(fightObject02);
            this.CategoryObjectList.Add(fightObject03);
            this.CategoryObjectList.Add(fightObject04);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (CategoryObjectMenu item in Helper.FindVisualChildren<CategoryObjectMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

    }
}
