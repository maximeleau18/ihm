using Pokemon.Entity;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class ObjectSelectionMenuStatus : UserControl
    {
        private ObservableCollection<PokemonObject> categoryObjectList = new ObservableCollection<PokemonObject>();
        
        internal ObservableCollection<PokemonObject> CategoryObjectList
        {
            get
            {
                return categoryObjectList;
            }
        }
        
        public ObjectSelectionMenuStatus()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            StatusObject statusObject01 = new StatusObject("Objet status 01", "ms-appx:///Images/ObjectsCategory/status.png");
            StatusObject statusObject02 = new StatusObject("Objet status 02", "ms-appx:///Images/ObjectsCategory/status.png");
            StatusObject statusObject03 = new StatusObject("Objet status 03", "ms-appx:///Images/ObjectsCategory/status.png");
            StatusObject statusObject04 = new StatusObject("Objet status 04", "ms-appx:///Images/ObjectsCategory/status.png");

            this.CategoryObjectList.Add(statusObject01);
            this.CategoryObjectList.Add(statusObject02);
            this.CategoryObjectList.Add(statusObject03);
            this.CategoryObjectList.Add(statusObject04);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            foreach (ObjectCategoryMenu item in Helper.FindVisualChildren<ObjectCategoryMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

    }
}
