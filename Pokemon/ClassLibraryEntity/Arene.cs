using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Arene : EntityBase
    {       
        private int id;
        private String nom;
        private Position position;
        private Badge badge;
        private PersonnageNonJoueur maitre;

        public Arene() { }

        public Arene(int id, string nom, Position position, Badge badge, PersonnageNonJoueur maitre)
        {
            this.id = id;
            this.nom = nom;
            this.position = position;
            this.badge = badge;
            this.maitre = maitre;
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

        public Position Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Badge Badge
        {
            get
            {
                return badge;
            }

            set
            {
                badge = value;
            }
        }

        public PersonnageNonJoueur Maitre
        {
            get
            {
                return maitre;
            }

            set
            {
                maitre = value;
            }
        }
    }
}
