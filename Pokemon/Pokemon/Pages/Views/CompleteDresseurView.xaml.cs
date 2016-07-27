using ClassLibraryEntity;
using Microsoft.Azure.Engagement.Overlay;
using Pokemon.UserControls.Other;
using Pokemon.ViewModels;
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
    public sealed partial class CompleteDresseurView : EngagementPageOverlay, INotifyPropertyChanged
    {
        private Grid mainGrid;
        private RingLoader ringLoader;
        private Button buttonValidate;
        private Button buttonBack;
        private TextBox textBoxLastName;
        private TextBox textBoxFirstName;
        private TextBox textBoxLogin;
        private PasswordBox textBoxPassword;
        private PasswordBox textBoxConfirmation;
        private CompleteDresseurViewModel completeDresseurViewModel;
        private TextBlock textBlockPasswordError;
        private TextBlock textBlockConfirmationError;
        private TextBlock textBlockFirstNameError;
        private TextBlock textBlockLastNameError;
        private TextBlock textBlockLoginError;
        private PersonnageNonJoueur personnageNonJoueur;
        private Visibility formValid;
        public event PropertyChangedEventHandler PropertyChanged;

        public Button ButtonValidate
        {
            get
            {
                return buttonValidate;
            }

            set
            {
                buttonValidate = value;
            }
        }
        public Button ButtonBack
        {
            get
            {
                return buttonBack;
            }

            set
            {
                buttonBack = value;
            }
        }
        public TextBox TextBoxLastName
        {
            get
            {
                return textBoxLastName;
            }

            set
            {
                textBoxLastName = value;
            }
        }
        public TextBox TextBoxFirstName
        {
            get
            {
                return textBoxFirstName;
            }

            set
            {
                textBoxFirstName = value;
            }
        }
        public TextBox TextBoxLogin
        {
            get
            {
                return textBoxLogin;
            }

            set
            {
                textBoxLogin = value;
            }
        }
        public PasswordBox TextBoxPassword
        {
            get
            {
                return textBoxPassword;
            }

            set
            {
                textBoxPassword = value;
            }
        }
        public PasswordBox TextBoxConfirmation
        {
            get
            {
                return textBoxConfirmation;
            }

            set
            {
                textBoxConfirmation = value;
            }
        }
        public CompleteDresseurViewModel CompleteDresseurViewModel
        {
            get
            {
                return completeDresseurViewModel;
            }

            set
            {
                completeDresseurViewModel = value;
            }
        }
        public TextBlock TextBlockPasswordError
        {
            get
            {
                return textBlockPasswordError;
            }

            set
            {
                textBlockPasswordError = value;
            }
        }
        public TextBlock TextBlockConfirmationError
        {
            get
            {
                return textBlockConfirmationError;
            }

            set
            {
                textBlockConfirmationError = value;
            }
        }
        public Visibility FormValid
        {
            get
            {
                return formValid;
            }

            set
            {
                formValid = value;
                OnPropertyChanged("FormValid");
            }
        }
        public TextBlock TextBlockFirstNameError
        {
            get
            {
                return textBlockFirstNameError;
            }

            set
            {
                textBlockFirstNameError = value;
            }
        }
        public TextBlock TextBlockLastNameError
        {
            get
            {
                return textBlockLastNameError;
            }

            set
            {
                textBlockLastNameError = value;
            }
        }
        public TextBlock TextBlockLoginError
        {
            get
            {
                return textBlockLoginError;
            }

            set
            {
                textBlockLoginError = value;
            }
        }
        public PersonnageNonJoueur PersonnageNonJoueur
        {
            get
            {
                return personnageNonJoueur;
            }

            set
            {
                personnageNonJoueur = value;
            }
        }
        public Grid MainGrid
        {
            get
            {
                return mainGrid;
            }

            set
            {
                mainGrid = value;
            }
        }
        public RingLoader RingLoader
        {
            get
            {
                return ringLoader;
            }

            set
            {
                ringLoader = value;
            }
        }

        public CompleteDresseurView()
        {
            this.InitializeComponent();
            this.ButtonBack = this.btnBack;
            this.ButtonValidate = this.btnValidate;
            this.TextBoxLastName = this.nomTxtB;
            this.TextBoxFirstName = this.prenomTxtB;
            this.TextBoxLogin = this.loginTxtB;
            this.TextBoxPassword = this.passwordTxtB;
            this.TextBoxConfirmation = this.confirmationTxtB;
            this.TextBlockLastNameError = this.errorNomTxtB;
            this.TextBlockFirstNameError = this.errorPrenomTxtB;
            this.TextBlockLoginError = this.errorLoginTxtB;
            this.TextBlockPasswordError = this.errorPasswordTxtB;
            this.TextBlockConfirmationError = this.errorConfirmationTxtB;
            this.RingLoader = this.ucRingLoader;
            this.MainGrid = this.currentGrid;

            this.CompleteDresseurViewModel = new CompleteDresseurViewModel(this);
            this.DataContext = this;
        }

        public void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.PersonnageNonJoueur = (PersonnageNonJoueur)e.Parameter;
        }
    }
}
