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
    public sealed partial class ObjectCategoryMenu : UserControl
    {
        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;
        }

        public ObjectCategoryMenu()
        {
            this.InitializeComponent();
        }
        
        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myConsole.setMessageBattleMenuText();
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonPokeballs_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            ObjectCategoryButton btn = (ObjectCategoryButton)sender;
            myConsole.setMessageObjectSelectionMenuText(btn.ObjectPokemonConsoleText);
            foreach (ObjectSelectionMenuPokeballs item in Helper.FindVisualChildren<ObjectSelectionMenuPokeballs>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonMedicaments_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (ObjectSelectionMenuMedicaments item in Helper.FindVisualChildren<ObjectSelectionMenuMedicaments>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonCombats_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (ObjectSelectionMenuCombats item in Helper.FindVisualChildren<ObjectSelectionMenuCombats>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void ObjectCategoryButtonStatus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (ObjectSelectionMenuStatus item in Helper.FindVisualChildren<ObjectSelectionMenuStatus>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
