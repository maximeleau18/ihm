using Pokemon.Pages.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokemon.ViewModels
{
    public class StartMenuPageViewModel
    {
        private StartMenuPageView startMenuPage;

        public StartMenuPageView StartMenuPage
        {
            get
            {
                return startMenuPage;
            }

            set
            {
                startMenuPage = value;
            }
        }

        public StartMenuPageViewModel(StartMenuPageView startMenuPageView)
        {
            this.StartMenuPage = startMenuPageView;
            this.Bind();
        }

        private void Bind()
        {
            this.StartMenuPage.ButtonStartGameOnline.Tapped += ButtonStartGameOnline_Tapped;
            this.StartMenuPage.ButtonStartGameOnline.PointerEntered += ButtonStartGameOnline_PointerEntered;
            this.StartMenuPage.ButtonStartGameOnline.PointerExited += ButtonStartGameOnline_PointerExited;
            this.StartMenuPage.ButtonContinueGameOnline.Tapped += ButtonContinueGameOnline_Tapped;
            this.StartMenuPage.ButtonContinueGameOnline.PointerEntered += ButtonContinueGameOnline_PointerEntered;
            this.StartMenuPage.ButtonContinueGameOnline.PointerExited += ButtonContinueGameOnline_PointerExited;
        }

        private void ButtonContinueGameOnline_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.StartMenuPage.ButtonContinueGameOnline.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonContinueGameOnline_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.StartMenuPage.ButtonContinueGameOnline.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonContinueGameOnline_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(ConnexionView));
        }

        private void ButtonStartGameOnline_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.StartMenuPage.ButtonStartGameOnline.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonStartGameOnline_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.StartMenuPage.ButtonStartGameOnline.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonStartGameOnline_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(ChoosePNJView));
        }

    }
}
