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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Fight
{
    public sealed partial class PokemonBattleDisplayOpponent : BaseUserControl
    {
        private int actualPv;

        public int ActualPv
        {
            get
            {
                return actualPv;
            }

            set
            {
                actualPv = value;
                base.OnPropertyChanged("ActualPv");
            }
        }

        private ClassLibraryEntity.Pokemon pokemon;

        public ClassLibraryEntity.Pokemon Pokemon
        {
            get { return pokemon; }
            set
            {
                pokemon = value;
                base.OnPropertyChanged("Pokemon");
            }
        }

        public PokemonBattleDisplayOpponent()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    }
}
