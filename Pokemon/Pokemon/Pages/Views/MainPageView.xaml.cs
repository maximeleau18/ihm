using ClassLibraryEntity;
using Microsoft.Azure.Engagement;
using Microsoft.Azure.Engagement.Overlay;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pokemon.Pages.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPageView : EngagementPageOverlay
    {
        public MainPageView()
        {
            this.InitializeComponent();
            //String deviceId = EngagementAgent.Instance.GetDeviceId();
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPageView));
        }

        //private void InitializeDb()
        //{
        //    SQLiteManager<Profession> managerProfession = new SQLiteManager<Profession>();
        //    Profession professionChampion = new Profession();
        //    professionChampion.Nom = "Champion";
        //    managerProfession.Insert(professionChampion);

        //    SQLiteManager<PersonnageNonJoueur> managerPnj = new SQLiteManager<PersonnageNonJoueur>();
        //    PersonnageNonJoueur pnj = new PersonnageNonJoueur();
        //    pnj.Id = 8000;
        //    pnj.Nom = "Sacha2";
        //    pnj.Description = "J'aime les pokémons2";
        //    pnj.ProfessionId = managerProfession.Get(professionChampion).Id;
        //    managerPnj.Insert(pnj);

        //}
    }
}
