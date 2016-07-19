using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class TypeObjet : EntityBase
    {
        private int id;
        private String nom;

        public TypeObjet() { }
        
        public TypeObjet(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
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


    }
}
