using Pokemon.UserControls.Other;
using Pokemon.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ClassLibraryEntity;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class CategoryObjectMenu : UserControl
    {
        private ObservableCollection<ClassLibraryEntity.TypeObjet> typesObjets;

        public ObservableCollection<TypeObjet> TypesObjets
        {
            get
            {
                return typesObjets;
            }

            set
            {
                typesObjets = value;
            }
        }

        private ListView itemsListTypesObjets;
        
        public ListView ItemsListTypesObjets
        {
            get
            {
                return itemsListTypesObjets;
            }

            set
            {
                itemsListTypesObjets = value;
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

        private Button buttonBack;
        
        public CategoryObjectMenu()
        {
            this.InitializeComponent();
            this.typesObjets = new ObservableCollection<TypeObjet>();
            this.listTypeObjet.ItemsSource = this.typesObjets;
            this.ItemsListTypesObjets = this.listTypeObjet;
            this.ButtonBack = this.btnBack;
        }

        public void LoadItems(List<ClassLibraryEntity.TypeObjet> typesObjets)
        {
            this.typesObjets.Clear();
            foreach (var item in typesObjets)
            {
                this.typesObjets.Add(item);
            }
        }
     
    }
}
