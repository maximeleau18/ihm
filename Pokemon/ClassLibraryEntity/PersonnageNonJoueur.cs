using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class PersonnageNonJoueur : EntityBase
    {
        private int id;
        private String nom;
        private String description;
        private Profession profession;
        private String urlImage;
        private List<Pokemon> pokemons;

        public PersonnageNonJoueur() { }
        
        public PersonnageNonJoueur(int id, String nom, String description, Profession profession)
        {
            this.Id = id;
            this.Nom = nom;
            this.Description = description;
            this.Profession = profession;
        }

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
        
        public String Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        
        public Profession Profession
        {
            get
            {
                return profession;
            }

            set
            {
                profession = value;
            }
        }
        
        public String UrlImage
        {
            get
            {
                return urlImage;
            }

            set
            {
                urlImage = value;
            }
        }
                
        public List<Pokemon> Pokemons
        {

            get
            {
                return pokemons;
            }
            set
            {
                pokemons = value;
            }
        }
        
        public List<Objet> Objets { get; set; }

        [JsonIgnore]
        public String UrlImagePNJ
        {
            get { return "ms-appx:///Images/PNJ/" + this.Nom + ".png"; }
        }        
    }
}
