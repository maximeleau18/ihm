using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class StatusObject : PokemonObject 
    {
        private Status healedStatus;

        internal Status HealedStatus
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

        public StatusObject(String name, String urlPicture) : base(name, urlPicture)
        {

        }
    }
}
