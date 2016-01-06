using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class MedicObject : PokemonObject
    {
        private int pvHeal;

        public int PvHeal
        {
            get
            {
                return pvHeal;
            }

            set
            {
                pvHeal = value;
            }
        }

        public MedicObject(String name, String urlPicture) : base (name, urlPicture)
        {

        }
    }    
}
