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
    public sealed partial class PokemonButton : UserControl
    {

        public static readonly DependencyProperty PokemonNameProperty = DependencyProperty.Register
           (
                "PokemonName",
                typeof(String),
                typeof(PokemonButton),
                new PropertyMetadata(null)
           );

        public static readonly DependencyProperty PokemonUrlPictureProperty = DependencyProperty.Register
            (
                "PokemonUrlPicture",
                typeof(String),
                typeof(PokemonButton),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty PokemonLevelProperty = DependencyProperty.Register
            (
                "PokemonLevel",
                typeof(String),
                typeof(PokemonButton),
                new PropertyMetadata(null)
            );

        public String PokemonName
        {
            get { return (String)GetValue(PokemonNameProperty); }
            set { SetValue(PokemonNameProperty, value); }
        }

        public String PokemonUrlPicture
        {
            get { return (String)GetValue(PokemonUrlPictureProperty); }
            set { SetValue(PokemonUrlPictureProperty, value); }
        }

        public String PokemonLevel
        {
            get { return (String)GetValue(PokemonLevelProperty); }
            set { SetValue(PokemonLevelProperty, "N. " + value); }
        }

        public PokemonButton()
        {
            this.InitializeComponent();
            this.ucPokemonButton.DataContext = this;
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["PokemonButtonSelected"];
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.Button.Style = (Style)Application.Current.Resources["PokemonButton"];
        }
    }
}
