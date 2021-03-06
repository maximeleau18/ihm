﻿using Pokemon.Entity;
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
    public sealed partial class AttackMenu : UserControl
    {
        private Entity.Pokemon pokemon;
        private Console myConsole;

        internal Entity.Pokemon Pokemon
        {
            get
            {
                return pokemon;
            }
            set
            {
                pokemon = value;
            }
        }

        public void setConsole(ref Console console)
        {
            myConsole = console;

            ucAttack01.setConsole(ref myConsole);
            ucAttack02.setConsole(ref myConsole);
            ucAttack03.setConsole(ref myConsole);
            ucAttack04.setConsole(ref myConsole);
        }
        
        public AttackMenu()
        {
            this.InitializeComponent();
            TypePokemon typePokemon = new TypePokemon("Eau");
            LoadContent(new Entity.Pokemon("Kaiminus", "Description Kaiminus", "ms-appx:///Images/Pokemons/kaiminus.png", 6, typePokemon));
        }

        private void LoadContent(Entity.Pokemon pokemon)
        {
            Attack attack01 = new Attack("Charge", pokemon.Type);
            Attack attack02 = new Attack("Gros yeux", pokemon.Type);
            Attack attack03 = new Attack("Griffe", pokemon.Type);
            Attack attack04 = new Attack("Pistolet à eau", pokemon.Type);

            this.ucAttack01.AttackName = attack01.Name;
            this.ucAttack01.TypeAttackName = attack01.Type.Name;

            this.ucAttack02.AttackName = attack02.Name;
            this.ucAttack02.TypeAttackName = attack02.Type.Name;

            this.ucAttack03.AttackName = attack03.Name;
            this.ucAttack03.TypeAttackName = attack03.Type.Name;

            this.ucAttack04.AttackName = attack04.Name;
            this.ucAttack04.TypeAttackName = attack04.Type.Name;
        }

        private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        {            
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParams"];
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
    }
}
