﻿using Newtonsoft.Json;
using SQLite.Net.Attributes;
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
        private int professionId;
        private String urlImage;
        private List<Pokemon> pokemons;

        public PersonnageNonJoueur() { }
        
        public PersonnageNonJoueur(int id, string nom, string description, Profession profession)
        {
            this.Id = id;
            this.Nom = nom;
            this.Description = description;
            this.Profession = profession;
        }

        [PrimaryKey, AutoIncrement]
        [Column("id")]
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

        [Column("nom")]
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

        [Column("description")]
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

        [Ignore]
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

        [Column("profession_id")]
        public int ProfessionId
        {
            get
            {
                return professionId;
            }

            set
            {
                professionId = value;
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

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
