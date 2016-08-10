using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class TypeDePokemonZone : EntityBase
    {
        private int id;
        private Zone zone;
        private TypeDePokemon typeDePokemon;
        
        public TypeDePokemonZone() { }

        public TypeDePokemonZone(int id, Zone zone, TypeDePokemon typeDePokemon)
        {
            this.Id = id;
            this.Zone = zone;
            this.TypeDePokemon = typeDePokemon;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Zone Zone
        {
            get
            {
                return zone;
            }

            set
            {
                zone = value;
            }
        }

        public TypeDePokemon TypeDePokemon
        {
            get
            {
                return typeDePokemon;
            }

            set
            {
                typeDePokemon = value;
            }
        }
    }
}
