using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Badge
    {
        private int id;
        private String nom;

        public Badge() { }

        public Badge(int id, String nom)
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
    }
}
