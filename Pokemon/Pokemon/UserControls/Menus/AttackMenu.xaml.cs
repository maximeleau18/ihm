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
    public sealed partial class AttackMenu : UserControl
    {        
        public AttackButton AttackButton1 { get; set; }
        public AttackButton AttackButton2 { get; set; }
        public AttackButton AttackButton3 { get; set; }
        public AttackButton AttackButton4 { get; set; }

        public AttackMenu()
        {
            this.InitializeComponent();
            this.AttackButton1 = this.ucAttack01;
            this.AttackButton2 = this.ucAttack02;
            this.AttackButton3 = this.ucAttack03;
            this.AttackButton4 = this.ucAttack04;
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
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
