using ClassLibraryEntity;
using Pokemon.UserControls.Buttons;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon.UserControls.Menus
{
    public sealed partial class StatusObjectSelectionMenu : UserControl
    {
        private ObservableCollection<PokemonObject> categoryObjectList = new ObservableCollection<PokemonObject>();
        
        internal ObservableCollection<PokemonObject> CategoryObjectList
        {
            get
            {
                return categoryObjectList;
            }
        }
        private Console myConsole;

        public void setConsole(ref Console console)
        {
            myConsole = console;

            //SetConsole to Object Button
        }

        public StatusObjectSelectionMenu()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            StatusObject statusObject01 = new StatusObject("Anti-Para", "ms-appx:///Images/ObjectsCategory/status.png");
            StatusObject statusObject02 = new StatusObject("Réveil", "ms-appx:///Images/ObjectsCategory/status.png");
            StatusObject statusObject03 = new StatusObject("Antidote", "ms-appx:///Images/ObjectsCategory/status.png");
            StatusObject statusObject04 = new StatusObject("Rappel", "ms-appx:///Images/ObjectsCategory/status.png");

            this.CategoryObjectList.Add(statusObject01);
            this.CategoryObjectList.Add(statusObject02);
            this.CategoryObjectList.Add(statusObject03);
            this.CategoryObjectList.Add(statusObject04);
        }

        private void btnBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myConsole.setMessageObjectCategoryMenuText();
            foreach (CategoryObjectMenu item in Helper.FindVisualChildren<CategoryObjectMenu>(this.Parent as Grid))
            {
                item.Visibility = Visibility.Visible;
                Visibility = Visibility.Collapsed;
            }
        }

    }
}
