using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Objet : EntityBase
    {
        private int id;
        private String nom;
        private int quantite;
        private TypeObjet typeObjet;
        private PersonnageNonJoueur personnageNonJoueur;
        private String urlImage;

        public Objet() { }

        public Objet(int id, String nom, int quantite, TypeObjet typeObjet, PersonnageNonJoueur personnageNonJoueur)
        {
            this.Id = id;
            this.Nom = nom;
            this.Quantite = quantite;
            this.TypeObjet = typeObjet;
            this.PersonnageNonJoueur = personnageNonJoueur;
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

        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
            }
        }

        public TypeObjet TypeObjet
        {
            get
            {
                return typeObjet;
            }

            set
            {
                typeObjet = value;
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
    }
}
