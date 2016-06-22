using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class StatusObject : PokemonObject
    {
        private StatusPokemon healedStatus;

        public StatusObject(String name, String urlPicture, StatusPokemon status) : base(name, urlPicture)
        {
            healedStatus = status;
        }

        public StatusObject(String name, String urlPicture) : base(name, urlPicture)
        {
        }

        internal StatusPokemon HealedStatus
        {
            get
            {
                return healedStatus;
            }

            set
            {
                healedStatus = value;
            }
        }

        
    }
}
