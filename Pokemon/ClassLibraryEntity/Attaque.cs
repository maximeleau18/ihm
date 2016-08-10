using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Attaque : EntityBase
    {
        private int id;
        private String nom;
        private int puissance;
        private int degats;
        private TypeAttaque typeAttaque;

        public Attaque() { }

        public Attaque(int id, String nom, int puissance, int degats, TypeAttaque typeAttaque)
        {
            this.Id = id;
            this.Nom = nom;
            this.Puissance = puissance;
            this.Degats = degats;
            this.TypeAttaque = typeAttaque;
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

        public int Puissance
        {
            get
            {
                return puissance;
            }

            set
            {
                puissance = value;
            }
        }

        public int Degats
        {
            get
            {
                return degats;
            }

            set
            {
                degats = value;
            }
        }

        public TypeAttaque TypeAttaque
        {
            get
            {
                return typeAttaque;
            }

            set
            {
                typeAttaque = value;
            }
        }
    }
}
