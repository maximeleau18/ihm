using ClassLibraryEntity;
using Pokemon.Pages.Views;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokemon.ViewModels
{
    public class PokedexViewModel
    {
        private PokedexView pokedexView;
        private GridManager gridManager;


        public PokedexView PokedexView
        {
            get
            {
                return pokedexView;
            }

            set
            {
                pokedexView = value;
            }
        }

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

        public PokedexViewModel(PokedexView pokedexView)
        {
            this.PokedexView = pokedexView;
            this.GridManager = this.PokedexView.GridManager;
            this.Bind();
        }

        private void Bind()
        {
            this.PokedexView.ButtonBack.Tapped += ButtonBack_Tapped;
            this.PokedexView.ButtonBack.PointerEntered += ButtonBack_PointerEntered;
            this.PokedexView.ButtonBack.PointerExited += ButtonBack_PointerExited;
        }

        private void ButtonBack_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.PokedexView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParams"];
        }

        private void ButtonBack_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.PokedexView.ButtonBack.Style = (Style)Application.Current.Resources["ButtonParamsSelected"];
        }

        private void ButtonBack_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(MapView), this.GridManager);
        }

    }
}
