﻿using Pokemon.Entity;
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
    public sealed partial class MedicObjectSelectionMenu : UserControl
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
        public MedicObjectSelectionMenu()
        {
            this.InitializeComponent();
            LoadContent();
            this.ListObjectCategory.ItemsSource = this.CategoryObjectList;
        }

        private void LoadContent()
        {
            MedicObject medocs01 = new MedicObject("Potion", "ms-appx:///Images/ObjectsCategory/Medic.png");
            MedicObject medocs02 = new MedicObject("Super Potion", "ms-appx:///Images/ObjectsCategory/Medic.png");
            MedicObject medocs03 = new MedicObject("Hyper Potion", "ms-appx:///Images/ObjectsCategory/Medic.png");
            MedicObject medocs04 = new MedicObject("Potion Max", "ms-appx:///Images/ObjectsCategory/Medic.png");

            this.CategoryObjectList.Add(medocs01);
            this.CategoryObjectList.Add(medocs02);
            this.CategoryObjectList.Add(medocs03);
            this.CategoryObjectList.Add(medocs04);
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
