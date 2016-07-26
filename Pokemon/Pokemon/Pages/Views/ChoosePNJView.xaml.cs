using Pokemon.UserControls.Other;
using Pokemon.UserControls.Pokemons;
using Pokemon.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ChoosePNJView : Page, INotifyPropertyChanged
    {
        private PnjPokemons pnjPokemons;

        private PnjPokemonsAttacks pnjPokemonsAttacks;

        private RingLoader ringLoader;

        private Grid mainGrid;

        private Visibility selectedPnj;

        public event PropertyChangedEventHandler PropertyChanged;

        private ChoosePNJViewModel choosePNJViewModel;

        public ChoosePNJViewModel ChoosePNJViewModel
        {
            get
            {
                return choosePNJViewModel;
            }

            set
            {
                choosePNJViewModel = value;
            }
        }

        private ObservableCollection<ClassLibraryEntity.PersonnageNonJoueur> pnjs;

        public ObservableCollection<ClassLibraryEntity.PersonnageNonJoueur> PNJs
        {
            get
            {
                return pnjs;
            }
            set
            {
                pnjs = value;
            }
        }

        private ListView itemsListPnjs;

        public ListView ItemsListPnjs
        {
            get
            {
                return itemsListPnjs;
            }

            set
            {
                itemsListPnjs = value;
            }
        }

        private Console console;

        public Console Console
        {
            get
            {
                return console;
            }

            set
            {
                console = value;
            }
        }

        private Button buttonBack;

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

        private Button buttonValidate;

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

        public Visibility SelectedPnj
        {
            get
            {
                return selectedPnj;
            }

            set
            {
                selectedPnj = value;
                OnPropertyChanged("SelectedPnj");
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

        public PnjPokemons PnjPokemons
        {
            get
            {
                return pnjPokemons;
            }

            set
            {
                pnjPokemons = value;
            }
        }

        public PnjPokemonsAttacks PnjPokemonsAttacks
        {
            get
            {
                return pnjPokemonsAttacks;
            }

            set
            {
                pnjPokemonsAttacks = value;
            }
        }

        public ChoosePNJView()
        {
            this.InitializeComponent();
            this.ButtonBack = this.btnBack;
            this.ButtonValidate = this.btnValidate;
            this.pnjs = new ObservableCollection<ClassLibraryEntity.PersonnageNonJoueur>();
            this.listPNJ.ItemsSource = this.pnjs;
            this.ItemsListPnjs = this.listPNJ;
            this.Console = this.ucConsole;
            this.RingLoader = this.ucRingLoader;
            this.MainGrid = this.currentGrid;
            this.PnjPokemons = this.ucPnjPokemons;
            this.PnjPokemonsAttacks = this.ucPnjPokemonsAttacks;
            this.ChoosePNJViewModel = new ChoosePNJViewModel(this);
            this.DataContext = this;
        }

        public void LoadItems(List<ClassLibraryEntity.PersonnageNonJoueur> pnjs)
        {
            this.pnjs.Clear();
            foreach (var item in pnjs)
            {
                this.pnjs.Add(item);
            }
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
