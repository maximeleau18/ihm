using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Pokemon : EntityBase
    {
        private String name;
        private String description;
        private String urlPicture;
        private int level;

        private TypePokemon type;

        private Statistics baseStats;
        private Statistics actualStats;
        
        public Pokemon(String _nom, String _description, String _urlPicture, int _niveau, TypePokemon _type)
        {
            this.Name = _nom;
            this.Description = _description;
            this.UrlPicture = _urlPicture;
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

        public String Description
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

        public TypePokemon Type
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

        public String UrlPicture
        {
            get
            {
                return urlPicture;
            }

            set
            {
                urlPicture = value;
            }
        }
    }
}
