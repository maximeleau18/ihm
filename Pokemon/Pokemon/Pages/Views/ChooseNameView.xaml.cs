using ClassLibraryEntity;
using Pokemon.Utils;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokemon.Pages.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ChooseNameView : Page
    {
        private Player player;

        public ChooseNameView()
        {
            this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(ChooseName_Loaded);
        }

        void ChooseName_Loaded(object sender, RoutedEventArgs e)
        {
            this.TxtBoxName.Focus(FocusState.Keyboard);
        }     

        internal Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.TxtBoxName.Focus(FocusState.Keyboard);
            this.Player = (Player)e.Parameter;

            if (Player.Sexe.Equals("M"))
            {
                this.ImgCharacter.Source = ((Image)Application.Current.Resources["ImageManIcone"]).Source;
            }

            if (Player.Sexe.Equals("F"))
            {
                this.ImgCharacter.Source = ((Image)Application.Current.Resources["ImageWomanIcone"]).Source;
            }

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

        private void btnValidate_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.btnValidate.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void btnValidate_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.btnValidate.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void btnValidate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            String name = this.TxtBoxName.Text.Trim();
            // Effectuer les tests sur la chaine de caractères
            if (String.IsNullOrEmpty(name))
            {

            }
            // On chare le nom du joueur
            this.Player.Name = name.ToUpper();
            // On définit la position initiale du joueur
            //this.Player.PosX = 0;
            //this.Player.PosY = 0;
            this.Player.PosX = 31;
            this.Player.PosY = 14;

            GridManager gridManager = new GridManager(26, 46, 15, 27, 11, 19, this.Player);
            // On charge la page map
            (Window.Current.Content as Frame).Navigate(typeof(MapView), gridManager);
        }
    }
}
