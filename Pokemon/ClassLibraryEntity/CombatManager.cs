using ClassLibraryEntity.API;
using Microsoft.Azure.Engagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class CombatManager
    {
        private Combat combat;
        private Attaque attaque;
        private Pokemon pokemon;
        private int combatId;
        private int attaqueId;
        private int pokemonId;
        private int actualPvPokemon;
        private int pokemonActualTurnId;
        public Combat Combat
        {
            get
            {
                return combat;
            }

            set
            {
                combat = value;
            }
        }
        public Attaque Attaque
        {
            get
            {
                return attaque;
            }

            set
            {
                attaque = value;
            }
        }
        public Pokemon Pokemon
        {
            get
            {
                return pokemon;
            }

            set
            {
                pokemon = value;
            }
        }


        [JsonProperty(PropertyName = "combat")]
        public int CombatId
        {
            get
            {
                return this.Combat.Id;
            }

            set
            {
                combatId = value;
            }
        }

        [JsonProperty(PropertyName = "attaque")]
        public int AttaqueId
        {
            get
            {
                return this.Attaque.Id;
            }

            set
            {
                attaqueId = value;
            }
        }

        [JsonProperty(PropertyName = "pokemon")]
        public int PokemonId
        {
            get
            {
                return this.Pokemon.Id;
            }

            set
            {
                pokemonId = value;
            }
        }
        
        [JsonProperty(PropertyName = "actualPv")]
        public int ActualPvPokemon
        {
            get
            {
                return actualPvPokemon;
            }

            set
            {
                actualPvPokemon = value;
            }
        }

        [JsonProperty(PropertyName = "pokemonActualTurnId")]
        public int PokemonActualTurnId
        {
            get
            {
                return pokemonActualTurnId;
            }

            set
            {
                pokemonActualTurnId = value;
            }
        }
               
        public CombatManager() { }
                
        [JsonConstructor]
        public CombatManager(Combat combat, Attaque attaque, Pokemon pokemon, int actualPv, int pokemonActualTurnId)
        {
            this.Combat = combat;
            this.Attaque = attaque;
            this.Pokemon = pokemon;
            this.ActualPvPokemon = actualPv;
            this.PokemonActualTurnId = pokemonActualTurnId;
        }
        
        public async Task<Combat> StartNewFight(Dresseur dresseur1, ClassLibraryEntity.Pokemon pokemon1)
        {
            Combat combat = new Combat();
            combat.Dresseur1 = dresseur1;
            combat.Pokemon1 = pokemon1;
            combat.LanceLe = DateTime.Now;
            combat.Dresseur1Vainqueur = false;
            combat.Pokemon1Vainqueur = false;
            combat.Dresseur2Vainqueur = false;
            combat.Pokemon2Vainqueur = false;
            // Set deviceid for dresseur1
            combat.Dresseur1DeviceId = EngagementAgent.Instance.GetDeviceId();

            ApiManager manager = new ApiManager();
            return combat = await manager.PostToApiAndReceiveData<Combat>(combat);
        }

        public async Task<Combat> WaitingForDressseur2(Combat combat)
        {
            ApiManager manager = new ApiManager();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(30) && combat.Dresseur2 == null)
            {
                combat = await manager.GetFromApi<Combat>(combat.Id);
            }

            s.Stop();

            return combat;
        }

        public async Task<Combat> FinishFight(Combat combat)
        {
            ApiManager manager = new ApiManager();
            combat = await manager.PutToApiAndReceiveData<Combat>(combat, combat.Id);            

            return combat;
        }

        public async Task<Boolean> DeleteFight(Combat combat)
        {
            ApiManager manager = new ApiManager();
            return await manager.DeleteToApi(combat, combat.Id);
        }
                
        public void LaunchAttackAgainstOpponent(CombatManager combatManager)
        {
            ApiManager manager = new ApiManager();
            manager.PostToApiLaunchAttackAndReceiveData<CombatManager>(combatManager);
        }
    }
}
