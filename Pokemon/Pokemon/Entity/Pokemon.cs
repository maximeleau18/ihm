using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class Pokemon
    {
        private String name;
        private String description;
        private int level;

        private TypePokemon type;

        private Statistics baseStats;
        private Statistics actualStats;
        
        public Pokemon(String _nom, String _description, int _niveau, TypePokemon _type)
        {
            this.Name = _nom;
            this.Description = _description;
            this.Level = _niveau;
            this.Type = _type;
        }

        public void UpdateActualStats(Statistics stats, Boolean replace = false)
        {
            if (replace)
            {
                actualStats = stats;
            }
            else
            {

            }
        }

        public string Name
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        internal TypePokemon Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
