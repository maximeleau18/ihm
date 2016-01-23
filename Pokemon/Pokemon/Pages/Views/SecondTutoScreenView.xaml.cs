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
    public sealed partial class SecondTutoScreenView : Page
    {
        public String displayedText = "";
        private int lineWidth = 300;

        public String DisplayedText
        {
            get { return (String)GetValue(Tuto2TextProperty); }
            set { SetValue(Tuto2TextProperty, value); }
        }

        public static readonly DependencyProperty Tuto2TextProperty = DependencyProperty.Register
            (
                "DisplayedText",
                typeof(String),
                typeof(SecondTutoScreenView),
                new PropertyMetadata(null)
            );

        public SecondTutoScreenView()
        {
            this.InitializeComponent();
            this.TutoMsg2.DataContext = this;

            TutoMsg2.MaxWidth = lineWidth;

            DisplayedText = "Pour te déplacer sur la carte, tu peux utiliser les flèches directionnelles du clavier ou les touches [Z], [Q], [S] et [D].";
            DisplayedText += "Touche le bouton RETOUR pour revenir à l'écran précédent.";
        }

        private void btnNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(ChooseCharacterView));
        }
        private void btnNext_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnNext.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnNext_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnNext.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(FirstTutoScreenView));
        }

        private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }       

        private void SecondTuto_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
