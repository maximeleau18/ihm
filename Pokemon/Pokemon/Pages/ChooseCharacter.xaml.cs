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

namespace Pokemon.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ChooseCharacter : Page
    {
        public ChooseCharacter()
        {
            this.InitializeComponent();
        }

        private void ManSelected_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.ManSelected.Style = (Style)Application.Current.Resources["BorderImageSelectionSelected"];
        }

        private void ManSelected_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.ManSelected.Style = (Style)Application.Current.Resources["BorderImageSelection"];
        }

        private void WomanSelected_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.WomanSelected.Style = (Style)Application.Current.Resources["BorderImageSelectionSelected"];
        }

        private void WomanSelected_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.WomanSelected.Style = (Style)Application.Current.Resources["BorderImageSelection"];
        }

        private void btnBack_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["BorderCornerButtonParamsSelected"];
        }

        private void btnBack_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnBack.Style = (Style)Application.Current.Resources["BorderCornerButtonParams"];
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPage));
        }
    }
}
