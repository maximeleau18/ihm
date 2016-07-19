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

        public Objet() { }

        public Objet(int id, string nom, int quantite, TypeObjet typeObjet, PersonnageNonJoueur personnageNonJoueur)
        {
            this.id = id;
            this.nom = nom;
            this.quantite = quantite;
            this.typeObjet = typeObjet;
            this.personnageNonJoueur = personnageNonJoueur;
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
    }
}
