using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class BattleObject : PokemonObject, ObjectAsTarget
    {
        private Statistics modifiedStats;

        internal Statistics ModifiedStats
        {
            get
            {
                return modifiedStats;
            }

            set
            {
                modifiedStats = value;
            }
        }

        public BattleObject(String name, String urlPicture) : base (name, urlPicture)
        {

        }
    } 
}
