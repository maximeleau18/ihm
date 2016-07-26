using ClassLibraryEntity;
using Newtonsoft.Json;
using Pokemon.Pages.Views;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Pokemon.ViewModels
{
    public class ConnexionViewModel
    {
        private ConnexionView connexionView;
        private Dresseur dresseur;
        private MessageErreur errorsForm;
        private String responseApi;

        public ConnexionView ConnexionView
        {
            get
            {
                return connexionView;
            }

            set
            {
                connexionView = value;
            }
        }
        public Dresseur Dresseur
        {
            get
            {
                return dresseur;
            }

            set
            {
                dresseur = value;
            }
        }
        public MessageErreur ErrorsForm
        {
            get
            {
                return errorsForm;
            }

            set
            {
                errorsForm = value;
            }
        }
        public String ResponseApi
        {
            get
            {
                return responseApi;
            }

            set
            {
                responseApi = value;
            }
        }

        public ConnexionViewModel(ConnexionView connexionView)
        {
            this.ConnexionView = connexionView;
            this.ConnexionView.FormValid = FormValid();
            this.Bind();
        }

        private void Bind()
        {
            this.ConnexionView.ButtonBack.PointerEntered += ButtonBack_PointerEntered;
            this.ConnexionView.ButtonBack.PointerExited += ButtonBack_PointerExited;
            this.ConnexionView.ButtonBack.Tapped += ButtonBack_Tapped;

            this.ConnexionView.ButtonValidate.PointerExited += ButtonValidate_PointerExited;
            this.ConnexionView.ButtonValidate.PointerEntered += ButtonValidate_PointerEntered;
            this.ConnexionView.ButtonValidate.Tapped += ButtonValidate_Tapped;

            this.ConnexionView.TextBoxLogin.KeyUp += TextBoxLogin_KeyUp;
            this.ConnexionView.TextBoxPassword.KeyUp += TextBoxPassword_KeyUp;
        }

        private void TextBoxPassword_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            this.ConnexionView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.ConnexionView.TextBoxPassword.Password.Trim()))
            {
                this.ConnexionView.TextBlockPasswordError.Text = "Mot de passe obligatoire !";
                this.ConnexionView.TextBoxPassword.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.ConnexionView.TextBlockPasswordError.Text = "";
                this.ConnexionView.TextBoxPassword.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBoxLogin_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            this.ConnexionView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.ConnexionView.TextBoxLogin.Text.Trim()))
            {
                this.ConnexionView.TextBlockLoginError.Text = "Login obligatoire !";
                this.ConnexionView.TextBoxLogin.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.ConnexionView.TextBlockLoginError.Text = "";
                this.ConnexionView.TextBoxLogin.Background = new SolidColorBrush(Colors.White);
            }
        }

        private Visibility FormValid()
        {
            if (String.IsNullOrEmpty(this.ConnexionView.TextBoxLogin.Text.Trim()))
            {
                return Visibility.Collapsed;
            }
            if (String.IsNullOrEmpty(this.ConnexionView.TextBoxPassword.Password))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        private async void ButtonValidate_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.ConnexionView.MainGrid.Visibility = Visibility.Collapsed;
            this.ConnexionView.RingLoader.ProgressRingText.Text = "Connexion...";
            this.ConnexionView.RingLoader.Visibility = Visibility.Visible;

            Dresseur dresseur = new Dresseur(0, "", "", this.ConnexionView.TextBoxLogin.Text.Trim(), this.ConnexionView.TextBoxPassword.Password.Trim(), 
                        new PersonnageNonJoueur());

            ClassLibraryEntity.API.ApiManager manager = new ClassLibraryEntity.API.ApiManager();
            this.ResponseApi = await manager.PostToApiCheckCredentialsAsync<Dresseur>(dresseur);
            this.GetResults();
        }

        private void GetResults()
        {
            // Check if errors exist
            if (this.ResponseApi.Contains("errors_login"))
            {
                this.ConnexionView.MainGrid.Visibility = Visibility.Visible;
                this.ConnexionView.RingLoader.Visibility = Visibility.Collapsed;
                this.ErrorsForm = JsonConvert.DeserializeObject<MessageErreur>(this.ResponseApi);
                this.ConnexionView.TextBlockLoginError.Text = this.ErrorsForm.messagesErreursLogin[0];
                this.ConnexionView.TextBoxLogin.Background = new SolidColorBrush(Colors.DarkRed);

            }
            else if (this.ResponseApi.Contains("errors_password"))
            {
                this.ConnexionView.MainGrid.Visibility = Visibility.Visible;
                this.ConnexionView.RingLoader.Visibility = Visibility.Collapsed;
                this.ErrorsForm = JsonConvert.DeserializeObject<MessageErreur>(this.ResponseApi);
                this.ConnexionView.TextBlockPasswordError.Text = this.ErrorsForm.messagesErreursPassword[0];
                this.ConnexionView.TextBoxPassword.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.Dresseur = JsonConvert.DeserializeObject<Dresseur>(this.ResponseApi);
                Player player = new Player();
                player.Name = dresseur.PersonnageNonJoueur.Nom.ToUpper();
                // On définit la position initiale du joueur
                //this.Player.PosX = 0;
                //this.Player.PosY = 0;
                player.PosX = 31;
                player.PosY = 14;

                GridManager gridManager = new GridManager(26, 46, 15, 27, 11, 19, player, dresseur.PersonnageNonJoueur);
                // On charge la page map
                (Window.Current.Content as Frame).Navigate(typeof(MapView), gridManager);
            }
        }

        private void ButtonValidate_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ConnexionView.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonValidate_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ConnexionView.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBack_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPageView));
        }

        private void ButtonBack_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ConnexionView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBack_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.ConnexionView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }
    }
}
