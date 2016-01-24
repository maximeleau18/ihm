using Pokemon.Entity;
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
    public sealed partial class CategoryObjectMenu : UserControl
    {
        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;
            this.Battle.setConsole(ref myConsole);
            this.Medic.setConsole(ref myConsole);
            this.Statut.setConsole(ref myConsole);
            this.Balls.setConsole(ref myConsole);
        }

        public CategoryObjectMenu()
        {
            this.InitializeComponent();            
        }
        
        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myConsole.setMessageBattleMenuText();
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.setConsole(ref myConsole);
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonPokeballs_Tapped(object sender, TappedRoutedEventArgs e)
        {            
            ObjectCategoryButton btn = (ObjectCategoryButton)sender;
            myConsole.setMessageObjectSelectionMenuText(btn.ObjectPokemonConsoleText);
            foreach (PokeballObjectSelectionMenu item in Helper.FindVisualChildren<PokeballObjectSelectionMenu>(this.Parent as Grid))
            {
                item.setConsole(ref myConsole);
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonMedicaments_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ObjectCategoryButton btn = (ObjectCategoryButton)sender;
            myConsole.setMessageObjectSelectionMenuText(btn.ObjectPokemonConsoleText);
            foreach (MedicObjectSelectionMenu item in Helper.FindVisualChildren<MedicObjectSelectionMenu>(this.Parent as Grid))
            {
                item.setConsole(ref myConsole);
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonCombats_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ObjectCategoryButton btn = (ObjectCategoryButton)sender;
            myConsole.setMessageObjectSelectionMenuText(btn.ObjectPokemonConsoleText);
            foreach (BattleObjectSelectionMenu item in Helper.FindVisualChildren<BattleObjectSelectionMenu>(this.Parent as Grid))
            {
                item.setConsole(ref myConsole);
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonStatus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ObjectCategoryButton btn = (ObjectCategoryButton)sender;
            myConsole.setMessageObjectSelectionMenuText(btn.ObjectPokemonConsoleText);
            foreach (StatusObjectSelectionMenu item in Helper.FindVisualChildren<StatusObjectSelectionMenu>(this.Parent as Grid))
            {
                item.setConsole(ref myConsole);
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
