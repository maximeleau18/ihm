using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class TypePokemon
    {
        private String name;

        private List<TypePokemon> weekAgainst;
        private List<TypePokemon> stringAgainst;

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

        public TypePokemon(String name)
        {
            this.Name = name;
        }
    }
}
