using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Pokemon : EntityBase
    {
        private int id;
        private String surnom;
        private int niveau;
        private DateTime captureLe;
        private TypeDePokemon typeDePokemon;
        private PersonnageNonJoueur personnageNonJoueur;
        private Attaque attaque1;
        private Attaque attaque2;
        private Attaque attaque3;
        private Attaque attaque4;

        public Pokemon() { }
        
        public Pokemon(int id, string surnom, int niveau, DateTime captureLe, TypeDePokemon typeDePokemon, PersonnageNonJoueur personnageNonJoueur, Attaque attaque1, Attaque attaque2, Attaque attaque3, Attaque attaque4)
        {
            this.id = id;
            this.surnom = surnom;
            this.niveau = niveau;
            this.captureLe = captureLe;
            this.typeDePokemon = typeDePokemon;
            this.personnageNonJoueur = personnageNonJoueur;
            this.attaque1 = attaque1;
            this.attaque2 = attaque2;
            this.attaque3 = attaque3;
            this.attaque4 = attaque4;
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

        public String Surnom
        {
            get
            {
                return surnom;
            }

            set
            {
                surnom = value;
            }
        }

        public int Niveau
        {
            get
            {
                return niveau;
            }

            set
            {
                niveau = value;
            }
        }

        public DateTime CaptureLe
        {
            get
            {
                return captureLe;
            }

            set
            {
                captureLe = value;
            }
        }

        public TypeDePokemon TypeDePokemon
        {
            get
            {
                return typeDePokemon;
            }

            set
            {
                typeDePokemon = value;
            }
        }

        [JsonIgnore]
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

        public Attaque Attaque1
        {
            get
            {
                return attaque1;
            }

            set
            {
                attaque1 = value;
            }
        }

        public Attaque Attaque2
        {
            get
            {
                return attaque2;
            }

            set
            {
                attaque2 = value;
            }
        }

        public Attaque Attaque3
        {
            get
            {
                return attaque3;
            }

            set
            {
                attaque3 = value;
            }
        }

        public Attaque Attaque4
        {
            get
            {
                return attaque4;
            }

            set
            {
                attaque4 = value;
            }
        }
    }
}
