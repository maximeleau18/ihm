using ClassLibraryEntity;
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

namespace Pokemon.UserControls.Pokemons
{
    public sealed partial class PnjPokemonsAttacks : BaseUserControl
    {
        public Button AttackButton1 { get; set; }
        public Button AttackButton2 { get; set; }
        public Button AttackButton3 { get; set; }
        public Button AttackButton4 { get; set; }
        public Button ButtonBack { get; set; }
        private Attaque attaque01;
        private Attaque attaque02;
        private Attaque attaque03;
        private Attaque attaque04;
        public Attaque Attaque01
        {
            get
            {
                return attaque01;
            }

            set
            {
                attaque01 = value;
                base.OnPropertyChanged("Attaque01");
            }
        }
        public Attaque Attaque02
        {
            get
            {
                return attaque02;
            }

            set
            {
                attaque02 = value;
                base.OnPropertyChanged("Attaque02");
            }
        }
        public Attaque Attaque03
        {
            get
            {
                return attaque03;
            }

            set
            {
                attaque03 = value;
                base.OnPropertyChanged("Attaque03");
            }
        }
        public Attaque Attaque04
        {
            get
            {
                return attaque04;
            }

            set
            {
                attaque04 = value;
                base.OnPropertyChanged("Attaque04");
            }
        }

        public PnjPokemonsAttacks()
        {
            this.InitializeComponent();
            this.AttackButton1 = this.buttonAttack01;
            this.AttackButton2 = this.buttonAttack02;
            this.AttackButton3 = this.buttonAttack03;
            this.AttackButton4 = this.buttonAttack04;
            this.DataContext = this;
        }
    }
}
