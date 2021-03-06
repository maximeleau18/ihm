﻿using Pokemon.Entity;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokemon.Pages.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ChooseCharacterView : Page
    {
        public ChooseCharacterView()
        {
            this.InitializeComponent();
        }

        private void ManSelected_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.ManSelected.Style = (Style)Application.Current.Resources["ImageChooseCharacterSelected"];
        }

        private void ManSelected_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.ManSelected.Style = (Style)Application.Current.Resources["ImageChooseCharacter"];
        }

        private void WomanSelected_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.WomanSelected.Style = (Style)Application.Current.Resources["ImageChooseCharacterSelected"];
        }

        private void WomanSelected_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.WomanSelected.Style = (Style)Application.Current.Resources["ImageChooseCharacter"];
        }
                
        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPageView));
        }

        private void ManSelected_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Player player = new Player();
            player.Sexe = "M";

            (Window.Current.Content as Frame).Navigate(typeof(ChooseNameView), player);
        }

        private void WomanSelected_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Player player = new Player();
            player.Sexe = "F";

            (Window.Current.Content as Frame).Navigate(typeof(ChooseNameView), player);
        }

        private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }
    }
}
