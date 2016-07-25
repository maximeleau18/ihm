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
using Pokemon.UserControls.Other;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class BattleMenu : UserControl
    {
        private Button buttonPokemon;
        private Button buttonTypeObjet;
        private Button buttonRunaway;

        public Button ButtonPokemon
        {
            get
            {
                return buttonPokemon;
            }

            set
            {
                buttonPokemon = value;
            }
        }

        public Button ButtonTypeObjet
        {
            get
            {
                return buttonTypeObjet;
            }

            set
            {
                buttonTypeObjet = value;
            }
        }

        public Button ButtonRunaway
        {
            get
            {
                return buttonRunaway;
            }

            set
            {
                buttonRunaway = value;
            }
        }

        public BattleMenu()
        {
            this.InitializeComponent();
            this.ButtonPokemon = this.pokemonButton;
            this.ButtonTypeObjet = this.objectTypeButton;
            this.ButtonRunaway = this.runawayButton;
            this.DataContext = this;
        }
        
    }
}
