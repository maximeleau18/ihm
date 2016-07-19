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

        public Attaque(int id, string nom, int puissance, int degats, TypeAttaque typeAttaque)
        {
            this.id = id;
            this.nom = nom;
            this.puissance = puissance;
            this.degats = degats;
            this.typeAttaque = typeAttaque;
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
