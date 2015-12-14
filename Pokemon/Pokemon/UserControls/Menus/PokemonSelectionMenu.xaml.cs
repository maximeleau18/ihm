﻿using Pokemon.Utils;
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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class PokemonSelectionMenu : UserControl
    {
        public PokemonSelectionMenu()
        {
            this.InitializeComponent();
        }
        

        //private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        //{
        //    this.btnBack.Style = (Style)Application.Current.Resources["PokemonButton"];
        //}

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

        //private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        //{
        //    this.btnBack.Style = (Style)Application.Current.Resources["PokemonButtonSelected"];
        //}

    }
}
