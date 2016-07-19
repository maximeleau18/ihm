using ClassLibraryEntity;
using Pokemon.UserControls;
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
    public sealed partial class AttackButton : BaseUserControl
    {
        private Attaque attaque;

        public Attaque Attaque
        {
            get { return attaque; }
            set
            {
                attaque = value;
                base.OnPropertyChanged("Attaque");
            }
        }

        public AttackButton()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["AttackButtonSelected"];
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["AttackButton"];
        }        
    }
}
