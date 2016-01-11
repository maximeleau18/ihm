using Pokemon.Entity;
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
    public sealed partial class TrainerCardView : Page
    {
        private Player player;

        public TrainerCardView()
        {
            this.InitializeComponent();
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
            this.Player = (Player)e.Parameter;
            this.TxtblockNameCharacter.Text = this.Player.Name.ToUpper();

            if (Player.Sexe.Equals("M"))
            {
                this.ImgCharacter.Source = new BitmapImage(new Uri("ms-appx:///Images/Man.png"));
            }

            if (Player.Sexe.Equals("F"))
            {
                this.ImgCharacter.Source = new BitmapImage(new Uri("ms-appx:///Images/Woman.png"));
            }
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
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.Player);
        }       

        //private void PokeContentBlock_PointerEntered(object sender, PointerRoutedEventArgs e)
        //{
        //    this.PokeContentBlock.Style = (Style)Application.Current.Resources["BorderPokeBlockSelected"];
        //}

        //private void PokeContentBlock_PointerExited(object sender, PointerRoutedEventArgs e)
        //{
        //    this.PokeContentBlock.Style = (Style)Application.Current.Resources["BorderPokeBlock"];
        //}
    }
}
