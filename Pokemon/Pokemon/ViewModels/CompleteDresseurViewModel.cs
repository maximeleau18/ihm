using ClassLibraryEntity;
using Newtonsoft.Json;
using Pokemon.Pages.Views;
using Pokemon.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using Windows.UI.Xaml.Media;

namespace Pokemon.ViewModels
{
    public class CompleteDresseurViewModel
    {
        private CompleteDresseurView completeDresseurView;
        private Dresseur dresseur;
        private MessageErreur errorsForm;
        private String responseApi;

        public CompleteDresseurView CompleteDresseurView
        {
            get
            {
                return completeDresseurView;
            }

            set
            {
                completeDresseurView = value;
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

        public CompleteDresseurViewModel(CompleteDresseurView completeDresseurView)
        {
            this.CompleteDresseurView = completeDresseurView;
            this.CompleteDresseurView.FormValid = FormValid();
            this.Bind();
        }

        private void Bind()
        {
            this.CompleteDresseurView.Loaded += CompleteDresseurView_Loaded;
            this.CompleteDresseurView.ButtonBack.Tapped += ButtonBack_Tapped;
            this.CompleteDresseurView.ButtonBack.PointerEntered += ButtonBack_PointerEntered;
            this.CompleteDresseurView.ButtonBack.PointerExited += ButtonBack_PointerExited;
            this.CompleteDresseurView.ButtonValidate.Tapped += ButtonValidate_Tapped;
            this.CompleteDresseurView.ButtonValidate.PointerEntered += ButtonValidate_PointerEntered;
            this.CompleteDresseurView.ButtonValidate.PointerExited += ButtonValidate_PointerExited;
            this.CompleteDresseurView.TextBoxLastName.KeyUp += TextBoxLastName_KeyUp;
            this.CompleteDresseurView.TextBoxFirstName.KeyUp += TextBoxFirstName_KeyUp;
            this.CompleteDresseurView.TextBoxLogin.KeyUp += TextBoxLogin_KeyUp;
            this.CompleteDresseurView.TextBoxPassword.KeyUp += TextBoxPassword_KeyUp;
            this.CompleteDresseurView.TextBoxConfirmation.KeyUp += TextBoxConfirmation_KeyUp;
        }

        private void CompleteDresseurView_Loaded(object sender, RoutedEventArgs e)
        {
            this.CompleteDresseurView.TextBoxLastName.Focus(FocusState.Keyboard);
        }        

        private Boolean ValidateDresseur()
        {
            String strLastname = "";
            String strFirstname = "";
            String strLogin = "";
            String strPassword = "";
            String strConfirmation = "";

            strLastname = this.CompleteDresseurView.TextBoxLastName.Text;
            strFirstname = this.CompleteDresseurView.TextBoxFirstName.Text;
            strLogin = this.CompleteDresseurView.TextBoxLogin.Text;
            strPassword = this.CompleteDresseurView.TextBoxPassword.Password;
            strConfirmation = this.CompleteDresseurView.TextBoxConfirmation.Password;

            if (String.IsNullOrEmpty(strLastname.Trim()))
            {
                return false;
            }
            if (String.IsNullOrEmpty(strFirstname.Trim()))
            {
                return false;
            }
            if (String.IsNullOrEmpty(strLogin.Trim()))
            {
                return false;
            }
            if (String.IsNullOrEmpty(strPassword))
            {
                return false;
            }
            if (String.IsNullOrEmpty(strConfirmation))
            {
                return false;
            }
            if (!strConfirmation.Equals(strPassword))
            {
                this.CompleteDresseurView.TextBlockPasswordError.Text = "Les mots de passes doivent correspondrent !";
                this.CompleteDresseurView.TextBlockConfirmationError.Text = "Les mots de passes doivent correspondrent !";
                this.CompleteDresseurView.TextBoxPassword.Background = new SolidColorBrush(Colors.DarkRed);
                this.CompleteDresseurView.TextBoxConfirmation.Background = new SolidColorBrush(Colors.DarkRed);
                return false;
            }


            return true;
        }

        private Visibility FormValid()
        {
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxLastName.Text.Trim()))
            {
                return Visibility.Collapsed;
            }
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxFirstName.Text.Trim()))
            {
                return Visibility.Collapsed;
            }
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxLogin.Text.Trim()))
            {
                return Visibility.Collapsed;
            }
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxPassword.Password))
            {
                return Visibility.Collapsed;
            }
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxConfirmation.Password))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        private void TextBoxConfirmation_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
           this.CompleteDresseurView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxConfirmation.Password))
            {
                this.CompleteDresseurView.TextBlockConfirmationError.Text = "Confirmation obligatoire !";
                this.CompleteDresseurView.TextBoxConfirmation.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.CompleteDresseurView.TextBlockConfirmationError.Text = "";
                this.CompleteDresseurView.TextBoxConfirmation.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBoxPassword_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            this.CompleteDresseurView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxPassword.Password))
            {
                this.CompleteDresseurView.TextBlockPasswordError.Text = "Mot de passe obligatoire !";
                this.CompleteDresseurView.TextBoxPassword.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.CompleteDresseurView.TextBlockPasswordError.Text = "";
                this.CompleteDresseurView.TextBoxPassword.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBoxLogin_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            this.CompleteDresseurView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxLogin.Text.Trim()))
            {
                this.CompleteDresseurView.TextBlockLoginError.Text = "Login obligatoire !";
                this.CompleteDresseurView.TextBoxLogin.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.CompleteDresseurView.TextBlockLoginError.Text = "";
                this.CompleteDresseurView.TextBoxLogin.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBoxFirstName_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            this.CompleteDresseurView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxFirstName.Text.Trim()))
            {
                this.CompleteDresseurView.TextBlockFirstNameError.Text = "Prénom obligatoire !";
                this.CompleteDresseurView.TextBoxFirstName.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.CompleteDresseurView.TextBlockFirstNameError.Text = "";
                this.CompleteDresseurView.TextBoxFirstName.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBoxLastName_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            this.CompleteDresseurView.FormValid = FormValid();
            if (String.IsNullOrEmpty(this.CompleteDresseurView.TextBoxLastName.Text.Trim()))
            {
                this.CompleteDresseurView.TextBlockLastNameError.Text = "Nom obligatoire !";
                this.CompleteDresseurView.TextBoxLastName.Background = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                this.CompleteDresseurView.TextBlockLastNameError.Text = "";
                this.CompleteDresseurView.TextBoxLastName.Background = new SolidColorBrush(Colors.White);
            }
        }
                        
        private void ButtonValidate_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.CompleteDresseurView.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonValidate_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.CompleteDresseurView.ButtonValidate.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private async void ButtonValidate_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.CompleteDresseurView.MainGrid.Visibility = Visibility.Collapsed;
            this.CompleteDresseurView.RingLoader.ProgressRingText.Text = "Création du compte...";
            this.CompleteDresseurView.RingLoader.Visibility = Visibility.Visible;
            if (ValidateDresseur())
            {                
                Dresseur dresseur = new Dresseur();
                dresseur.Nom = this.CompleteDresseurView.TextBoxLastName.Text.Trim();
                dresseur.Prenom = this.CompleteDresseurView.TextBoxFirstName.Text.Trim();
                dresseur.Login = this.CompleteDresseurView.TextBoxLogin.Text.Trim();
                dresseur.Password = this.CompleteDresseurView.TextBoxPassword.Password.Trim();
                dresseur.PersonnageNonJoueur = this.CompleteDresseurView.PersonnageNonJoueur;
                ClassLibraryEntity.API.ApiManager manager = new ClassLibraryEntity.API.ApiManager();
                this.ResponseApi = await manager.PostToApiAndReceiveDataAsync<Dresseur>(dresseur);
                this.GetResults();
            }
        }

        private void GetResults()
        {
            // Check if errors exist
            if (this.ResponseApi.Contains("errors_login"))
            {
                this.CompleteDresseurView.MainGrid.Visibility = Visibility.Visible;
                this.CompleteDresseurView.RingLoader.Visibility = Visibility.Collapsed;
                this.ErrorsForm = JsonConvert.DeserializeObject<MessageErreur>(this.ResponseApi);
                this.CompleteDresseurView.TextBlockLoginError.Text = this.ErrorsForm.messagesErreursLogin[0];
                this.CompleteDresseurView.TextBoxLogin.Background = new SolidColorBrush(Colors.DarkRed);
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
        
        private void ButtonBack_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.CompleteDresseurView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBack_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.CompleteDresseurView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBack_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(ChoosePNJView));
        }
    }
}
