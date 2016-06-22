using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class PokemonObject : EntityBase
    {
        private String name;
        private String urlPicture;

        
        public PokemonObject()
        {

        }

        public PokemonObject(String name, String urlPicture)
        {
            this.Name = name;
            this.UrlPicture = urlPicture;
        }

        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public String UrlPicture
        {
            get
            {
                return urlPicture;
            }

            set
            {
                urlPicture = value;
            }
        }

    }
}
