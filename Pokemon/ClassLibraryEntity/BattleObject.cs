using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class BattleObject : PokemonObject
    {
        private Statistics modifiedStats;

        public Statistics ModifiedStats
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
