using ClassLibraryEntity;
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
        private ClassLibraryEntity.Pokemon pokemon;
        private Console myConsole;

        public ClassLibraryEntity.Pokemon Pokemon
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
            LoadContent();
        }

        private void LoadContent()
        {
            // Load 4 Pokemon's Attacks from API
            Attaque attack1 = this.Pokemon.Attaque1;
            Attaque attack2 = this.Pokemon.Attaque2;
            Attaque attack3 = this.Pokemon.Attaque3;
            Attaque attack4 = this.Pokemon.Attaque4;

            this.ucAttack01.AttackName = attack1.Nom;
            this.ucAttack01.TypeAttackName = attack1.TypeAttaque.Nom;

            this.ucAttack02.AttackName = attack2.Nom;
            this.ucAttack02.TypeAttackName = attack2.TypeAttaque.Nom;
            
            this.ucAttack03.AttackName = attack3.Nom;
            this.ucAttack03.TypeAttackName = attack3.TypeAttaque.Nom;

            this.ucAttack04.AttackName = attack4.Nom;
            this.ucAttack04.TypeAttackName = attack4.TypeAttaque.Nom;
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
