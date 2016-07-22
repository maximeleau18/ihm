using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class TypeDePokemon : EntityBase
    {
        private int id;
        private String nom;
        private int attaque;
        private int defense;
        private int pv;
        private int numPokedex;
        private String urlImage;

        public TypeDePokemon() { }

        public TypeDePokemon(int id, String nom, int attaque, int defense, int pv, int numPokedex, String urlImage)
        {
            this.id = id;
            this.nom = nom;
            this.attaque = attaque;
            this.defense = defense;
            this.pv = pv;
            this.numPokedex = numPokedex;
            this.urlImage = urlImage;
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

        public int Attaque
        {
            get
            {
                return attaque;
            }

            set
            {
                attaque = value;
            }
        }

        public int Defense
        {
            get
            {
                return defense;
            }

            set
            {
                defense = value;
            }
        }

        public int Pv
        {
            get
            {
                return pv;
            }

            set
            {
                pv = value;
            }
        }

        public int NumPokedex
        {
            get
            {
                return numPokedex;
            }

            set
            {
                numPokedex = value;
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

        public String ImagePokemonFront
        {
            get { return "ms-appx:///Images/Pokemons/pokemon_front_" + this.NumPokedex.ToString() + ".png"; }
        }
        
        public String ImagePokemonBack
        {
            get { return "ms-appx:///Images/Pokemons/pokemon_back_" + this.NumPokedex.ToString() + ".png"; }
        }
    }
}
