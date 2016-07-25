using ClassLibraryEntity;
using Pokemon.ViewModels;
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
    public sealed partial class StartMenuPageView : Page
    {
        private Button buttonStartGameOnline;
        private Button buttonContinueGameOnline;
        private StartMenuPageViewModel startMenuPageViewModel;
        
        public Button ButtonStartGameOnline
        {
            get
            {
                return buttonStartGameOnline;
            }

            set
            {
                buttonStartGameOnline = value;
            }
        }
        public Button ButtonContinueGameOnline
        {
            get
            {
                return buttonContinueGameOnline;
            }

            set
            {
                buttonContinueGameOnline = value;
            }
        }
        public StartMenuPageViewModel StartMenuPageViewModel
        {
            get
            {
                return startMenuPageViewModel;
            }

            set
            {
                startMenuPageViewModel = value;
            }
        }

        public StartMenuPageView()
        {
            this.InitializeComponent();
            this.ButtonStartGameOnline = this.btnStartGameOnline;
            this.ButtonContinueGameOnline = this.btnContinueGameOnline;

            this.StartMenuPageViewModel = new StartMenuPageViewModel(this);
        }
    }
}
