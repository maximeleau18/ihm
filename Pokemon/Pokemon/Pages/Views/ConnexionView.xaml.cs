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
    public sealed partial class ConnexionView : EngagementPageOverlay, INotifyPropertyChanged
    {
        private Grid mainGrid;
        private RingLoader ringLoader;
        private Button buttonValidate;
        private Button buttonBack;
        private TextBox textBoxLogin;
        private PasswordBox textBoxPassword;
        private TextBlock textBlockPasswordError;
        private TextBlock textBlockLoginError;
        private ConnexionViewModel connexionViewModel;
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
        public ConnexionViewModel ConnexionViewModel
        {
            get
            {
                return connexionViewModel;
            }

            set
            {
                connexionViewModel = value;
            }
        }

        public ConnexionView()
        {
            this.InitializeComponent();
            this.ButtonBack = this.btnBack;
            this.ButtonValidate = this.btnValidate;
            this.TextBoxLogin = this.loginTxtB;
            this.TextBoxPassword = this.passwordTxtB;
            this.TextBlockLoginError = this.errorLoginTxtB;
            this.TextBlockPasswordError = this.errorPasswordTxtB;
            this.RingLoader = this.ucRingLoader;
            this.MainGrid = this.currentGrid;

            this.ConnexionViewModel = new ConnexionViewModel(this);
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
    }
}
