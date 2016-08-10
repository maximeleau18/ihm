using ClassLibraryEntity.API;
using Microsoft.Azure.Engagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Dresseur dresseur;
        private int combatId;
        private int attaqueId;
        private int dresseurId;
        private int actualPvPokemon;
        private int dresseurActualTurnId;
        private String console;
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
        public Dresseur Dresseur
        {
            get
            {
                return dresseur;
            }

            set
            {
                dresseur = value;
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

        [JsonProperty(PropertyName = "attaque", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public int AttaqueId
        {
            get
            {
                if (this.Attaque == null)
                {
                    return 0;
                }
                else
                {
                    return this.Attaque.Id;
                }
            }

            set
            {
                attaqueId = value;
            }
        }

        [JsonProperty(PropertyName = "dresseur", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public int DresseurId
        {
            get
            {
                if (this.Dresseur == null)
                {
                    return 0;
                }
                else
                {
                    return this.Dresseur.Id;
                }
            }

            set
            {
                dresseurId = value;
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

        [JsonProperty(PropertyName = "dresseurActualTurnId")]
        public int DresseurActualTurnId
        {
            get
            {
                return dresseurActualTurnId;
            }

            set
            {
                dresseurActualTurnId = value;
            }
        }

        [JsonProperty(PropertyName = "console")]
        public String Console
        {
            get
            {
                return console;
            }

            set
            {
                console = value;
            }
        }

        public CombatManager() { }
                
        [JsonConstructor]
        public CombatManager(Combat combat, Attaque attaque, Dresseur dresseur, int actualPv, int dressseurActualTurnId, String console)
        {
            this.Combat = combat;
            this.Attaque = attaque;
            this.Dresseur = dresseur;
            this.ActualPvPokemon = actualPv;
            this.DresseurActualTurnId = dresseurActualTurnId;
            this.Console = console;
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
        
        public async Task<String> SearchEmptyFight(Dresseur dresseur2, ClassLibraryEntity.Pokemon pokemon2)
        {
            Combat combat = new Combat();
            combat.Dresseur2 = dresseur2;
            combat.Pokemon2 = pokemon2;
            // Set deviceid for dresseur2
            combat.Dresseur2DeviceId = EngagementAgent.Instance.GetDeviceId();

            ApiManager manager = new ApiManager();
            return await manager.PostToApiSearchEmptyFightAsync<Combat>(combat);
        }

        public async Task<Combat> WaitingForDressseur2(Combat combat)
        {
            ApiManager manager = new ApiManager();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed < TimeSpan.FromSeconds(30) && combat.Dresseur2 == null)
            {
                combat = await manager.GetFromApi<Combat>(combat.Id);
            }

            stopWatch.Stop();

            return combat;
        }

        public async Task<Combat> FinishFight(CombatManager combatManager)
        {
            ApiManager manager = new ApiManager();
            combatManager.Combat = await manager.PutToApiDesertFightAndReceiveData(combatManager, combatManager.Combat.Id);            

            return combatManager.Combat;
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
