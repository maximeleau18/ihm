using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ClassLibraryEntity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pokemon.Utils;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class ObjectMenu : UserControl
    {
        private ObservableCollection<ClassLibraryEntity.Objet> objets;

        public ObservableCollection<Objet> Objets
        {
            get
            {
                return objets;
            }

            set
            {
                objets = value;
            }
        }

        private ListView itemsListObjets;

        public ListView ItemsListObjets
        {
            get
            {
                return itemsListObjets;
            }

            set
            {
                itemsListObjets = value;
            }
        }


        public ObjectMenu()
        {
            this.InitializeComponent();
            this.objets = new ObservableCollection<ClassLibraryEntity.Objet>();
            this.listObjet.ItemsSource = this.objets;
            this.ItemsListObjets = this.listObjet;
        }

        public void LoadItems(List<ClassLibraryEntity.Objet> objets)
        {
            this.objets.Clear();
            foreach (var item in objets)
            {
                this.objets.Add(item);
            }
        }
        
        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (BattleMenu item in Helper.FindVisualChildren<BattleMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
