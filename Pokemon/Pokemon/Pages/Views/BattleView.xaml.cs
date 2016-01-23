using Pokemon.Entity;
using Pokemon.UserControls;
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
    public sealed partial class BattleView : Page
    {
        private Player player;

        public BattleView()
        {
            this.InitializeComponent();
            this.BattleMenu.RunawayButtonClick += new RoutedEventHandler(RunawayButton_Click);
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
        }

        public void CreateNeededObjectsTemporary()
        {
            Entity.Pokemon kaiminus = new Entity.Pokemon("Kaiminus", "C'est un pokemon eau", 6, 1, 1, 1);

            this.Player.Team.Add(kaiminus);
        }
        
        private void RunawayButton_Click(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.Player);
        }
    }
}
