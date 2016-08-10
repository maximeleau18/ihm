using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class TypeDePokemonEvolution : EntityBase
    {
        private int id;
        private TypeDePokemon evolueEn;
        private TypeDePokemon estEvolueEn;

        public TypeDePokemonEvolution() { }

        public TypeDePokemonEvolution(int id, TypeDePokemon evolueEn, TypeDePokemon estEvolueEn)
        {
            this.Id = id;
            this.EvolueEn = evolueEn;
            this.EstEvolueEn = estEvolueEn;
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

        public TypeDePokemon EvolueEn
        {
            get
            {
                return evolueEn;
            }

            set
            {
                evolueEn = value;
            }
        }

        public TypeDePokemon EstEvolueEn
        {
            get
            {
                return estEvolueEn;
            }

            set
            {
                estEvolueEn = value;
            }
        }
    }
}
