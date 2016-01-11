using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class StatusObject : PokemonObject 
    {
        private StatusPokemon healedStatus;

        public StatusObject(String name, String urlPicture, StatusPokemon status) : base(name, urlPicture)
        {
            healedStatus = status;
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
