using Pokemon.UserControls.Other;
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
    public sealed partial class AttackButton : UserControl
    {
        private Console myConsole;

        public static readonly DependencyProperty AttackNameProperty = DependencyProperty.Register
           (
                "AttackName",
                typeof(String),
                typeof(AttackButton),
                new PropertyMetadata(null)
           );

        public static readonly DependencyProperty TypeAttackProperty = DependencyProperty.Register
            (
                "TypeAttackName",
                typeof(String),
                typeof(AttackButton),
                new PropertyMetadata(null)
            );
        public void setConsole(ref Console console)
        {
            myConsole = console;
        }

        public String AttackName
        {
            get { return (String)GetValue(AttackNameProperty); }
            set { SetValue(AttackNameProperty, value); }
        }

        public String TypeAttackName
        {
            get { return (String)GetValue(TypeAttackProperty); }
            set { SetValue(TypeAttackProperty, value); }
        }

        public AttackButton()
        {
            this.InitializeComponent();
            this.ucAttackButton.DataContext = this;
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["AttackButton"];
        }

        private void Attack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myConsole.setMessageAttack(AttackName);
        }
    }
}
