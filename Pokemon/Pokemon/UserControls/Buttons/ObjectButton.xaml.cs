﻿using Pokemon.UserControls.Other;
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

namespace Pokemon.UserControls.Buttons
{
    public sealed partial class ObjectButton : UserControl
    {
        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;
        }
        public static readonly DependencyProperty ObjectPokemonNameProperty = DependencyProperty.Register
           (
                "ObjectPokemonName",
                typeof(String),
                typeof(ObjectButton),
                new PropertyMetadata(null)
           );

        public static readonly DependencyProperty ObjectPokemonPictureProperty = DependencyProperty.Register
            (
                "ObjectPokemonPicture",
                typeof(String),
                typeof(ObjectButton),
                new PropertyMetadata(null)
            );

        public String ObjectPokemonName
        {
            get { return (String)GetValue(ObjectPokemonNameProperty); }
            set { SetValue(ObjectPokemonNameProperty, value); }
        }

        public String ObjectPokemonPicture
        {
            get { return (String)GetValue(ObjectPokemonPictureProperty); }
            set { SetValue(ObjectPokemonPictureProperty, value); }
        }

        public ObjectButton()
        {
            this.InitializeComponent();
            this.ucObjectButton.DataContext = this;
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["ObjectButtonSelected"];
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["ObjectButton"];
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Give console to this object
            //myConsole.setMessageObject(ObjectPokemonName);
        }
    }
}
