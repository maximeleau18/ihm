﻿using System;
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
using Windows.UI.Xaml.Navigation;
using Pokemon.Pages;

using Pokemon.Utils;
using Pokemon.Entity;
using Pokemon.UserControls.Other;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class BattleMenu : UserControl
    {
        public RoutedEventHandler RunawayButtonClick;

        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;
        }
        
        public BattleMenu()
        {
            this.InitializeComponent();
        }
                
        private void AttackButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.AttackButton.Style = (Style)Application.Current.Resources["AttackButton"];
        }

        private void AttackButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.AttackButton.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void PokemonButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.PokemonButton.Style = (Style)Application.Current.Resources["PokemonButton"];
        }

        private void PokemonButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.PokemonButton.Style = (Style)Application.Current.Resources["PokemonButtonSelected"];
        }

        private void ObjectButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.ObjectButton.Style = (Style)Application.Current.Resources["ObjectButton"];
        }

        private void ObjectButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.ObjectButton.Style = (Style)Application.Current.Resources["ObjectButtonSelected"];
        }

        private void RunawayButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.RunawayButton.Style = (Style)Application.Current.Resources["RunawayButton"];
        }

        private void RunawayButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.RunawayButton.Style = (Style)Application.Current.Resources["RunawayButtonSelected"];
        }
        
        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            myConsole.setMessageAttackMenuText();
            foreach (AttackMenu item in Helper.FindVisualChildren<AttackMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void PokemonButton_Click(object sender, RoutedEventArgs e)
        {
            myConsole.setMessagePokemonSelectionMenuText();
            foreach (PokemonSelectionMenu item in Helper.FindVisualChildren<PokemonSelectionMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
                
        private void ObjectButton_Click(object sender, RoutedEventArgs e)
        {
            myConsole.setMessageObjectCategoryMenuText();
            foreach (CategoryObjectMenu item in Helper.FindVisualChildren<CategoryObjectMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        private void RunawayButton_Click(object sender, RoutedEventArgs e)
        {           
            if (RunawayButtonClick != null)
            {
                RunawayButtonClick(this, e);
            }
        }
    }
}
