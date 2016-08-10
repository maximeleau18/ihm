using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Combat : EntityBase
    {
        private int id;
        private DateTime lanceLe;
        private int duree;
        private bool pokemon1Vainqueur;
        private bool pokemon2Vainqueur;
        private bool dresseur1Vainqueur;
        private bool dresseur2Vainqueur;
        private Dresseur dresseur1;
        private Dresseur dresseur2;
        private Pokemon pokemon1;
        private Pokemon pokemon2;
        private int pokemonId1;
        private int pokemonId2;
        private int dresseurId1;
        private int dresseurId2;
        private String dresseur1DeviceId;
        private String dresseur2DeviceId;


        public Combat() { }
        
        [JsonConstructor]
        public Combat(int id,  DateTime lanceLe, int duree, bool pokemon1Vainqueur, bool pokemon2Vainqueur, bool dresseur1Vainqueur, bool dresseur2Vainqueur, 
                                Dresseur dresseur1, Dresseur dresseur2, Pokemon pokemon1, Pokemon pokemon2, String dresseur1DeviceId, String dresseur2DeviceId)
        {
            this.Id = id;
            this.LanceLe = lanceLe;
            this.Duree = duree;
            this.Pokemon1Vainqueur = pokemon1Vainqueur;
            this.Pokemon2Vainqueur = pokemon2Vainqueur;
            this.Dresseur1Vainqueur = dresseur1Vainqueur;
            this.Dresseur2Vainqueur = dresseur2Vainqueur;
            this.Dresseur1 = dresseur1;
            this.Dresseur2 = dresseur2;
            this.Pokemon1 = pokemon1;
            this.Pokemon2 = pokemon2;
            this.Dresseur1DeviceId = dresseur1DeviceId;
            this.Dresseur2DeviceId = dresseur2DeviceId;
        }


        [JsonProperty(PropertyName = "id")]
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


        [JsonProperty(PropertyName = "lanceLe")]
        [JsonConverter(typeof(MyDateTimeConverter))]
        public DateTime LanceLe
        {
            get
            {
                return lanceLe;
            }

            set
            {
                lanceLe = value;
            }
        }


        [JsonProperty(PropertyName = "duree")]
        public int Duree
        {
            get
            {
                return duree;
            }

            set
            {
                duree = value;
            }
        }
        
        [JsonProperty(PropertyName = "pokemon1Vainqueur")]
        public bool Pokemon1Vainqueur
        {
            get
            {
                return pokemon1Vainqueur;
            }

            set
            {
                pokemon1Vainqueur = value;
            }
        }

        [JsonProperty(PropertyName = "pokemon2Vainqueur")]
        public bool Pokemon2Vainqueur
        {
            get
            {
                return pokemon2Vainqueur;
            }

            set
            {
                pokemon2Vainqueur = value;
            }
        }

        [JsonProperty(PropertyName = "dresseur1Vainqueur")]
        public bool Dresseur1Vainqueur
        {
            get
            {
                return dresseur1Vainqueur;
            }

            set
            {
                dresseur1Vainqueur = value;
            }
        }

        [JsonProperty(PropertyName = "dresseur2Vainqueur")]
        public bool Dresseur2Vainqueur
        {
            get
            {
                return dresseur2Vainqueur;
            }

            set
            {
                dresseur2Vainqueur = value;
            }
        }

        public Dresseur Dresseur1
        {
            get
            {
                return dresseur1;
            }

            set
            {
                dresseur1 = value;
            }
        }

        public Dresseur Dresseur2
        {
            get
            {
                return dresseur2;
            }

            set
            {
                dresseur2 = value;
            }
        }

        public Pokemon Pokemon1
        {
            get
            {
                return pokemon1;
            }

            set
            {
                pokemon1 = value;
            }
        }

        public Pokemon Pokemon2
        {
            get
            {
                return pokemon2;
            }

            set
            {
                pokemon2 = value;
            }
        }

        [JsonProperty(PropertyName = "pokemon1", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public int PokemonId1
        {
            get
            {
                if (this.Pokemon1 == null)
                {
                    return 0;
                }
                else
                {
                    return this.Pokemon1.Id;
                }
            }

            set
            {
                pokemonId1 = value;
            }
        }


        [JsonProperty(PropertyName = "pokemon2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public int PokemonId2
        {
            get
            {
                if (this.Pokemon2 == null)
                {
                    return 0;
                }
                else
                {
                    return this.Pokemon2.Id;
                }
            }

            set
            {
                pokemonId2 = value;
            }
        }


        [JsonProperty(PropertyName = "dresseur1", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public int DresseurId1
        {
            get
            {
                if (this.Dresseur1 == null)
                {
                    return 0;
                }
                else
                {
                    return this.Dresseur1.Id;
                }
            }

            set
            {
                dresseurId1 = value;
            }
        }


        [JsonProperty(PropertyName = "dresseur2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public int DresseurId2
        {
            get
            {
                if (this.Dresseur2 == null)
                {
                    return 0;
                }
                else
                {
                    return this.Dresseur2.Id;
                }
            }

            set
            {
                dresseurId2 = value;
            }
        }

        [JsonProperty(PropertyName = "dresseur1DeviceId")]
        public String Dresseur1DeviceId
        {
            get
            {
                return dresseur1DeviceId;
            }

            set
            {
                dresseur1DeviceId = value;
            }
        }

        [JsonProperty(PropertyName = "dresseur2DeviceId")]
        public String Dresseur2DeviceId
        {
            get
            {
                return dresseur2DeviceId;
            }

            set
            {
                dresseur2DeviceId = value;
            }
        }
    }
}
