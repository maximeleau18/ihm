using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Dresseur : EntityBase
    {
        private int id;
        private String nom;
        private String prenom;
        private String login;
        private String password;
        private PersonnageNonJoueur personnageNonJoueur;

        
        public Dresseur() { }

        [JsonConstructor]
        public Dresseur(int id, string nom, string prenom, string login, string password, PersonnageNonJoueur personnageNonJoueur)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.password = password;
            this.personnageNonJoueur = personnageNonJoueur;
        }        

        
        [JsonProperty(PropertyName = "id")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        [JsonProperty(PropertyName = "nom")]
        public String Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        [JsonProperty(PropertyName = "prenom")]
        public String Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        [JsonProperty(PropertyName = "login")]
        public String Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        [JsonProperty(PropertyName = "motDePasse")]
        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        
        public PersonnageNonJoueur PersonnageNonJoueur
        {
            get
            {
                return personnageNonJoueur;
            }

            set
            {
                personnageNonJoueur = value;
            }
        }
        
        [JsonProperty(PropertyName = "personnageNonJoueur")]
        public int personnageNonJoueurId
        {
            get
            {
                return this.PersonnageNonJoueur.Id;
            }

            set
            {
                id = value;
            }
        }
    }
}
