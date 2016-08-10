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
        private String urlImage;

        public TypeObjet() { }
        
        public TypeObjet(int id, String nom)
        {
            this.Id = id;
            this.Nom = nom;
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
