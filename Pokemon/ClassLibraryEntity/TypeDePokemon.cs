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

        public TypeDePokemon() { }

        public TypeDePokemon(int id, string nom, int attaque, int defense, int pv, int numPokedex)
        {
            this.id = id;
            this.nom = nom;
            this.attaque = attaque;
            this.defense = defense;
            this.pv = pv;
            this.numPokedex = numPokedex;
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

        public string Nom
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
    }
}
