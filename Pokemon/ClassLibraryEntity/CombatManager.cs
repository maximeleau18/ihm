using ClassLibraryEntity.API;
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
        
        [JsonProperty(PropertyName = "actual_pv")]
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

        [JsonProperty(PropertyName = "pokemon_actual_turn_id")]
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

            ApiManager manager = new ApiManager();
            return combat = await manager.PostToApiAndReceiveData<Combat>(combat);
        }

        //public async Task<Combat> WaitingForDressseur2(Combat combat)
        //{
        //    ApiManager manager = new ApiManager();
        //    Stopwatch s = new Stopwatch();
        //    s.Start();
        //    while (s.Elapsed < TimeSpan.FromSeconds(10) && combat.Dresseur2 == null)
        //    {
        //        combat = await manager.GetFromApi<Combat>(combat.Id);
        //    }

        //    s.Stop();

        //    if (combat.Dresseur2 == null)
        //    {
        //        // Get the opponent which join fight
        //        Dresseur opponentPlayer = await manager.GetFromApi<Dresseur>(2);
        //        Pokemon opponentPokemon = await manager.GetFromApi<Pokemon>(12);

        //        combat.Dresseur2 = opponentPlayer;
        //        combat.Pokemon2 = opponentPokemon;
        //        // Put updated dresseur2 and pokemon2 
        //        combat = await manager.PutToApiAndReceiveData<Combat>(combat, combat.Id);
        //    }

        //    return combat;
        //}
        
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
                
        public void LaunchAttackAgainstOpponent(CombatManager fightManager)
        {
            ApiManager manager = new ApiManager();
            manager.PostToApiAndReceiveData<CombatManager>(this);
        }
    }
}
