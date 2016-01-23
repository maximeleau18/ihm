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

namespace Pokemon.UserControls.Other
{
    public sealed partial class Console : UserControl
    {
        private String BattleMenuText           = "Choisir une action.";
        private String ObjectCategoryMenuText   = "Choisir une catégorie d'objet.";
        private String ObjectSelectionMenuText  = "Choisir ";
        private String PokemonSelectionMenuText = "Choisir un pokemon.";
        private String AttackMenuText           = "Choisir une attaque.";

        private String displayedText = "";

        public String DisplayedText
        {
            get { return (String)GetValue(ConsoleTextProperty); }
            set { SetValue(ConsoleTextProperty, value); }
        }

        public static readonly DependencyProperty ConsoleTextProperty = DependencyProperty.Register
            (
                "DisplayedText",
                typeof(String),
                typeof(Console),
                new PropertyMetadata(null)
            );

        public Console()
        {
            this.InitializeComponent();            
            this.console.DataContext = this;

            setMessageBattleMenuText();
        }

        public void setMessageBattleMenuText()
        {
            DisplayedText = BattleMenuText;
        }
        public void setMessageObjectCategoryMenuText()
        {
            DisplayedText = ObjectCategoryMenuText;
        }
        public void setMessageObjectSelectionMenuText(String category)
        {
            DisplayedText = ObjectSelectionMenuText + category;
        }
        public void setMessagePokemonSelectionMenuText()
        {
            DisplayedText = PokemonSelectionMenuText;
        }
        public void setMessageAttackMenuText()
        {
            DisplayedText = AttackMenuText;
        }
    }
}
