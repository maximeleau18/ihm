using ClassLibraryEntity;
using Microsoft.Azure.Engagement.Overlay;
using Pokemon.Utils;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokemon.Pages.Views
{    
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MapView : EngagementPageOverlay
    {
        private GridManager gridManager;
        private SplitView splitView;
        private StackPanel menuSP;
        private StackPanel menuPokedexSP;
        private StackPanel menuQuitSP;
        private StackPanel menuDuelSP;
        private Grid mapGrid;
        private Grid playerGrid;
        private MapViewModel mapViewModel;

        public GridManager GridManager
        {
            get
            {
                return gridManager;
            }

            set
            {
                gridManager = value;
            }
        }

        public SplitView SplitView
        {
            get
            {
                return splitView;
            }

            set
            {
                splitView = value;
            }
        }

        public Grid MapGrid
        {
            get
            {
                return mapGrid;
            }

            set
            {
                mapGrid = value;
            }
        }

        public Grid PlayerGrid
        {
            get
            {
                return playerGrid;
            }

            set
            {
                playerGrid = value;
            }
        }

        public StackPanel MenuSP
        {
            get
            {
                return menuSP;
            }

            set
            {
                menuSP = value;
            }
        }

        public StackPanel MenuPokedexSP
        {
            get
            {
                return menuPokedexSP;
            }

            set
            {
                menuPokedexSP = value;
            }
        }

        public StackPanel MenuQuitSP
        {
            get
            {
                return menuQuitSP;
            }

            set
            {
                menuQuitSP = value;
            }
        }

        public MapViewModel MapViewModel
        {
            get
            {
                return mapViewModel;
            }

            set
            {
                mapViewModel = value;
            }
        }

        public StackPanel MenuDuelSP
        {
            get
            {
                return menuDuelSP;
            }

            set
            {
                menuDuelSP = value;
            }
        }

        public MapView()
        {
            this.InitializeComponent();
            this.MapGrid = this.mapViewGrid;
            this.PlayerGrid = this.playerGridMap;
            this.SplitView = this.menuSplitView;
            this.MenuSP = this.menuStackPanel;
            this.MenuPokedexSP = this.menuPokedexStackPanel;
            this.MenuQuitSP = this.menuQuitStackPanel;
            this.MenuDuelSP = this.menuDuelStackPanel;
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.GridManager = (GridManager)e.Parameter;
            this.MapViewModel = new MapViewModel(this);
        }        
        
    }
}
