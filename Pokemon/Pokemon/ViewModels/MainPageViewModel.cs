using Microsoft.Azure.Engagement;
using Pokemon.Pages.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokemon.ViewModels
{

    public class MainPageViewModel
    {
        private MainPageView mainPageView;

        public MainPageView MainPageView
        {
            get
            {
                return mainPageView;
            }

            set
            {
                mainPageView = value;
            }
        }

        public MainPageViewModel(MainPageView mainPageView)
        {
            this.MainPageView = mainPageView;
            this.Bind();
            //String deviceId = EngagementAgent.Instance.GetDeviceId();
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

        private void Bind()
        {
            this.MainPageView.StartImage.Tapped += StartImage_Tapped;
        }

        private void StartImage_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(StartMenuPageView));
        }

    }
}
