using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class BattleObject : PokemonObject
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
    }
}
