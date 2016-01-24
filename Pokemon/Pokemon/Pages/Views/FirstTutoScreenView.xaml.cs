using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class FirstTutoScreenView : Page
    {
        public String displayedText = "";
        private int lineWidth = 300;

        public String DisplayedText
        {
            get { return (String)GetValue(Tuto1TextProperty); }
            set { SetValue(Tuto1TextProperty, value); }
        }

        public static readonly DependencyProperty Tuto1TextProperty = DependencyProperty.Register
            (
                "DisplayedText",
                typeof(String),
                typeof(FirstTutoScreenView),
                new PropertyMetadata(null)
            );

        public FirstTutoScreenView()
        {         
            this.InitializeComponent();
            this.TutoMsg1.DataContext = this;

            TutoMsg1.MaxWidth = lineWidth;

            DisplayedText = "Je vais tout d'abord t'apprendre les choses importantes concernant ce jeu.";
            DisplayedText += " Touche le sujet que tu veux voir en détail sur la partie droite de l'écran.";

        }
        
        private void btnCommand_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(SecondTutoScreenView));
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(ChooseCharacterView));
        }

        private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void btnCommand_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnCommand.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnCommand_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnCommand.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void FirstTuto_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }
    }
}
