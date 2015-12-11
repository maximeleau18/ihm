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
    public sealed partial class StartMenuPage : Page
    {
        public StartMenuPage()
        {
            this.InitializeComponent();
        }

        private void btnNouvellePartie_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnNouvellePartie.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnNouvellePartie_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnNouvellePartie.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void btnContinuer_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnContinuer.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnContinuer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnContinuer.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

    }
}
