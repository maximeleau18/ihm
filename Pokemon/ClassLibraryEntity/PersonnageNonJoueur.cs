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

        public PersonnageNonJoueur() { }

        public PersonnageNonJoueur(int id, string nom, string description, Profession profession)
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

        public string Description
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
    }
}
